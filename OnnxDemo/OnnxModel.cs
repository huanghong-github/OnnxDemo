using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using OnnxDemo.Extensions;
using System.Drawing;

namespace OnnxDemo
{
    //功能复用
    public abstract class OnnxModel
    {
        public InferenceSession session;
        public string[] labels;
        private string inputTensorName;
        public float IOUThreshold { get; set; } = 0.4f;
        public float ConfThreshold { get; set; } = 0.25f;
        public int InputWidth { get; set; } = 640;
        public int InputHeight { get; set; } = 640;
        public Draw draw = new(BoxColor: Brushes.Red, LabelColor: Brushes.Red, FontSize: 7f);

        public OnnxModel(string onnxPath, string[] labels)
        {
            SessionOptions options = new();
            options.AppendExecutionProvider_CPU();
            session = new InferenceSession(onnxPath, options);

            this.labels = labels;
            KeyValuePair<string, NodeMetadata> inputMetadata = session.InputMetadata.First();
            inputTensorName = inputMetadata.Key;
            InputHeight = inputMetadata.Value.Dimensions[2];
            InputWidth = inputMetadata.Value.Dimensions[3];
        }

        public virtual Tensor<float> PreProcess(Bitmap bitmap)
        {
            return bitmap.Resize(InputWidth, InputHeight).FastToOnnxTensor_13hw();
        }

        public virtual Tensor<float> Inference(Tensor<float> input)
        {
            List<NamedOnnxValue> container = new()
            {
                NamedOnnxValue.CreateFromTensor(inputTensorName, input)
            };

            DisposableNamedOnnxValue output = Task.Run(() =>
            {
                lock (session)
                {
                    return session.Run(container).First();
                }
            }).Result;

            return output.AsTensor<float>();
        }

        public T Predict<T>(Bitmap bitmap) where T : class
        {
            Tensor<float> input = PreProcess(bitmap);
            Tensor<float> output = Inference(input);
            return PostProcess<T>(output);
        }

        public abstract T PostProcess<T>(Tensor<float> output) where T : class;
    }
}

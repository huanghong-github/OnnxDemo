using Common.Helper;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using OnnxDemo.Extensions;
using OnnxDemo.Interfaces;
using System.Drawing;

namespace OnnxDemo
{
    //功能复用
    public abstract class OnnxModel
    {
        public InferenceSession session;
        public string[] labels;
        public float IOUThreshold { get; set; } = 0.4f;
        public float ConfThreshold { get; set; } = 0.25f;
        public int InputWidth { get; set; } = 640;
        public int InputHeight { get; set; } = 640;
        public Draw draw = new(BoxColor: Brushes.Red, LabelColor: Brushes.Red, FontSize: 7f);

        public OnnxModel(string onnxPath, string[] labels)
        {
            SessionOptions options = new();
            try
            {
                options.AppendExecutionProvider_DML(0);
            }
            catch (Exception exception)
            {
                DefaultFileLogHelper.Error("error", exception);
            }

            session = new(onnxPath, options);
            this.labels = labels;
        }

        public virtual Tensor<float> PreProcess(Bitmap bitmap)
        {
            return bitmap.Resize(InputWidth, InputHeight).FastToOnnxTensor_13hw();
        }

        public virtual Tensor<float> Inference(Tensor<float> input)
        {
            List<NamedOnnxValue> container = new()
            {
                NamedOnnxValue.CreateFromTensor("images", input)
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

        public List<IPrediction> Predict(Bitmap bitmap)
        {
            Tensor<float> input = PreProcess(bitmap);
            Tensor<float> output = Inference(input);
            return PostProcess(output);
        }

        public abstract List<IPrediction> PostProcess(Tensor<float> output);
    }
}

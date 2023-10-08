using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;

namespace OnnxDemo.Classification
{
    public class ClasOnnxModel : OnnxModel, IOnnxModel
    {
        public ClasOnnxModel(string onnxPath, string[] labels) : base(onnxPath, labels)
        {
        }

        public override T PostProcess<T>(Tensor<float> output)
        {
            float maxClassScore = output.Max();
            int maxClassScoreIdx = output.ToList().FindIndex(x => x == maxClassScore);
            return labels[maxClassScoreIdx] as T;
        }

        public new T Predict<T>(Bitmap bitmap) where T : class
        {
            string preds = base.Predict<string>(bitmap);
            return preds as T;
        }
    }
}

using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;

namespace OnnxDemo.Interfaces
{
    // 模型接口
    public interface IOnnxModel
    {
        Tensor<float> PreProcess(Bitmap bitmap);
        float[] Inference(Tensor<float> input);
        List<IPrediction> PostProcess(float[] results);
        Bitmap Predict(Bitmap bitmap);
    }
}

using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;

namespace OnnxDemo.Interfaces
{
    // 模型接口
    public interface IOnnxModel
    {
        Tensor<float> PreProcess(Bitmap bitmap);
        Tensor<float> Inference(Tensor<float> input);
        List<IPrediction> PostProcess(Tensor<float> output);
        Bitmap Predict(Bitmap bitmap);
    }
}

using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;

namespace OnnxDemo
{
    // 模型接口
    public interface IOnnxModel
    {
        Tensor<float> PreProcess(Bitmap bitmap);
        Tensor<float> Inference(Tensor<float> input);
        T PostProcess<T>(Tensor<float> output) where T : class;
        T Predict<T>(Bitmap bitmap) where T : class;
    }
}

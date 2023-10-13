using Emgu.CV.Dnn;
using Emgu.CV.Util;
using Microsoft.ML.OnnxRuntime.Tensors;
using OnnxDemo.Extensions;
using System.Drawing;

namespace OnnxDemo.Detection
{
    public class YoloOnnxModel : OnnxModel, IOnnxModel
    {
        public YoloOnnxModel(string onnxPath, string[] labels) : base(onnxPath, labels)
        {
        }

        public new T Predict<T>(Bitmap bitmap) where T : class
        {
            List<PredictionBox> preds = base.Predict<List<PredictionBox>>(bitmap);
            bitmap.DrawPrediction(preds, draw);
            return bitmap as T;
        }

        public override T PostProcess<T>(Tensor<float> output) where T : class
        {
            return PostProcess2PredictionBox(output) as T;
        }

        private List<PredictionBox> PostProcess2PredictionBox(Tensor<float> output)
        {
            //IOU_threshold iou阈值
            //conf_threshold 置信度
            //score  置信度* 类别概率
            //output  3维Tensor
            //box format  0,1,2,3 ->box, 4->confidence, 5-85 -> coco classes confidence
            int len = output.Dimensions[2];
            int maxwh = 4096;
            int topK = 50;

            List<Rectangle> bboxes = new();
            List<float> scores = new();
            List<PredictionBox> detections = new();
            foreach (float[] chunk in output.Chunk(len))
            {
                float confidence = chunk[4];
                List<float> classScore = chunk[5..].ToList();
                float maxClassScore = classScore.Max();
                int maxClassScoreIdx = classScore.FindIndex(x => x == maxClassScore);

                if (confidence <= ConfThreshold || maxClassScore <= ConfThreshold)
                {
                    continue;
                }

                int centerX = (int)chunk[0], centerY = (int)chunk[1],
                width = (int)chunk[2], height = (int)chunk[3];

                bboxes.Add(new Rectangle(x: centerX - width / 2 + maxwh * maxClassScoreIdx,
                                         y: centerY - height / 2 + maxwh * maxClassScoreIdx,
                                         width: width,
                                         height: height));
                scores.Add(confidence * maxClassScore);
                detections.Add(new PredictionBox()
                {
                    BBox = new Rectangle(x: centerX - width / 2,
                                         y: centerY - height / 2,
                                         width: width,
                                         height: height),
                    Confidence = confidence,
                    LabelIndex = maxClassScoreIdx,
                    LabelName = labels[maxClassScoreIdx],
                    Score = confidence * maxClassScore,
                    InputWidth = InputWidth,
                    InputHeight = InputHeight
                });

            }

            VectorOfFloat updatedScores = new();
            VectorOfInt indices = new();
            DnnInvoke.SoftNMSBoxes(bboxes: new VectorOfRect(bboxes.ToArray()),
                                   scores: new VectorOfFloat(scores.ToArray()),
                                   updatedScores: updatedScores,
                                   scoreThreshold: ConfThreshold,
                                   nmsThreshold: IOUThreshold,
                                   indices: indices,
                                   topK: topK);

            List<PredictionBox> result = new();
            foreach (int i in indices.ToArray())
            {
                result.Add(detections[i]);
            }
            return result;
        }
    }
}

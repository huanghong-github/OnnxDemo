using OnnxDemo.Extensions;
using OnnxDemo.Interfaces;
using System.Drawing;

namespace OnnxDemo
{
    public class YoloOnnxModel : OnnxModel, IOnnxModel
    {
        public YoloOnnxModel(string onnxPath, string[] labels) : base(onnxPath, labels) { }


        public new Bitmap Predict(Bitmap bitmap)
        {
            List<PredictionBox> preds = base.Predict(bitmap).Cast<PredictionBox>().ToList();
            bitmap.DrawPrediction(preds, draw);
            return bitmap;
        }

        public override List<IPrediction> PostProcess(float[] results)
        {
            return PostProcess2PredictionBox(results).Cast<IPrediction>().ToList();
        }

        private List<PredictionBox> PostProcess2PredictionBox(float[] results)
        {
            //IOU_threshold iou阈值
            //conf_threshold 置信度
            //all_threshold  置信度* 类别概率
            //output  一维列表
            //box format  0,1,2,3 ->box, 4->confidence, 5-85 -> coco classes confidence
            int dimensions = 5 + labels.Length;

            List<PredictionBox> detections = new();
            foreach (float[] chunk in results.Chunk(dimensions))
            {
                float confidence = chunk[4];
                if (confidence <= ConfThreshold)
                {
                    continue;
                }

                for (int i = 5; i < dimensions; i++)
                {
                    if (chunk[i] <= ConfThreshold)
                    {
                        continue;
                    }

                    chunk[i] *= confidence;

                    float center_x = chunk[0], center_y = chunk[1],
                    halfWidth = chunk[2] / 2, halfHeight = chunk[3] / 2;

                    PredictionBox.BBox bbox = new(minX: (center_x - halfWidth) / InputWidth,
                                minY: (center_y - halfHeight) / InputWidth,
                                maxX: (center_x + halfWidth) / InputHeight,
                                maxY: (center_y + halfHeight) / InputHeight);

                    int label_index = i - 5;
                    detections.Add(new PredictionBox()
                    {
                        Box = bbox,
                        Confidence = confidence,
                        LabelIndex = label_index,
                        LabelName = labels[label_index],
                        Score = chunk[i]
                    });
                }
            }
            return PredictionBox.NMS(detections, IOUThreshold);
        }
    }
}

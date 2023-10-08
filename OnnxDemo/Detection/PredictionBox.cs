using System.Drawing;

namespace OnnxDemo.Detection
{
    //预测框
    public class PredictionBox
    {
        public required Rectangle BBox { get; set; }

        public int LabelIndex { get; set; }

        public required string LabelName { get; set; }

        public float Confidence { get; set; }

        public float Score { get; set; }

        public int InputWidth { get; set; } = 640;

        public int InputHeight { get; set; } = 640;


        //public static List<PredictionBox> NMS(List<PredictionBox> predictionBoxs, float IOU_threshold = 0.5f)
        //{
        //    List<PredictionBox> final_predications = new();

        //    foreach (PredictionBox pb in
        //        from pb in predictionBoxs
        //        orderby pb.Score descending
        //        select pb)
        //    {
        //        int j = 0;
        //        for (; j < final_predications.Count; j++)
        //        {
        //            if (ComputeIOU(final_predications[j], pb) > IOU_threshold)
        //            {
        //                break;
        //            }
        //        }
        //        if (j == final_predications.Count)
        //        {
        //            final_predications.Add(pb);
        //        }
        //    }
        //    return final_predications;
        //}

        //private static float ComputeIOU(PredictionBox pBa, PredictionBox pBb)
        ////计算IOU
        //{
        //    {
        //        float ay1 = pBa.Box.MinY;
        //        float ax1 = pBa.Box.MinX;
        //        float ay2 = pBa.Box.MaxY;
        //        float ax2 = pBa.Box.MaxX;
        //        float by1 = pBb.Box.MinY;
        //        float bx1 = pBb.Box.MinX;
        //        float by2 = pBb.Box.MaxY;
        //        float bx2 = pBb.Box.MaxX;

        //        Debug.Assert(ay1 < ay2);
        //        Debug.Assert(ax1 < ax2);
        //        Debug.Assert(by1 < by2);
        //        Debug.Assert(bx1 < bx2);

        //        // determine the coordinates of the intersection rectangle
        //        float x_left = Math.Max(ax1, bx1);
        //        float y_top = Math.Max(ay1, by1);
        //        float x_right = Math.Min(ax2, bx2);
        //        float y_bottom = Math.Min(ay2, by2);

        //        if (x_right < x_left || y_bottom < y_top)
        //        {
        //            return 0;
        //        }

        //        float intersection_area = (x_right - x_left) * (y_bottom - y_top);
        //        float bb1_area = (ax2 - ax1) * (ay2 - ay1);
        //        float bb2_area = (bx2 - bx1) * (by2 - by1);
        //        float iou = intersection_area / (bb1_area + bb2_area - intersection_area);

        //        Debug.Assert(iou is >= 0 and <= 1);
        //        return iou;
        //    }

        //}
    }
}

using System.Drawing;

namespace OnnxDemo
{
    public class MainWindow
    {
        public void Onnx()
        {
            YoloOnnxModel model = new(@"D:\nn\csharp\OnnxDemo\wildfire_yolov5.onnx",
                                    new string[] { "fire", "smoke" });
            string path = "D:\\dataset\\fire\\smoke\\images\\a10.jpg";
            Bitmap bitmap = (Bitmap)Image.FromFile(path);
            bitmap = model.Predict(bitmap);
            Console.WriteLine(bitmap);
        }

        public void Test()
        {
            //Bitmap bitmap = (Bitmap)Image.FromFile(path);
            //Mat mat = bitmap.ToMat();

            //CvInvoke.Resize(mat, mat, new Size(width: 640, height: 640));
            //CvInvoke.Imshow("image", mat);
            //mat.ToBitmap();

            //Image<Bgr, Byte> image = new(path);
            //CvInvoke.Imshow("image", image);
            //CvInvoke.WaitKey();

            //DnnInvoke.SoftNMSBoxes();           

        }
    }

}
using OnnxDemo.Classification;
using OnnxDemo.Detection;
using System.Drawing;

namespace OnnxDemo
{
    public class MainWindow
    {
        public void YoloOnnx()
        {
            YoloOnnxModel model = new(@"D:\nn\csharp\OnnxDemo\wildfire_yolov5.onnx",
                                    new string[] { "fire", "smoke" });
            string path = "D:\\dataset\\fire\\smoke\\images\\a10.jpg";
            Bitmap bitmap = (Bitmap)Image.FromFile(path);
            bitmap = model.Predict<Bitmap>(bitmap);
            Console.WriteLine(bitmap);
        }

        public void ClasOnnx()
        {
            ClasOnnxModel model = new(@"D:\nn\code\ckpt\rope_triangle\mobileone_s4.onnx",
                                    new string[] { "down", "left", "right", "up" });
            string path = "D:\\Downloads\\rope\\triangle\\test\\down\\aug3387.png";
            Bitmap bitmap = (Bitmap)Image.FromFile(path);
            Console.WriteLine(model.Predict<string>(bitmap));
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
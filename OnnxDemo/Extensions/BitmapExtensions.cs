// https://github.com/wanglvhang/OnnxYoloDemo
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace OnnxDemo.Extensions
{
    public static class BitmapExtensions
    {

        public static Tensor<float> ToOnnxTensor_13hw(this Bitmap bitmap)
        {

            Tensor<float> tensor = new DenseTensor<float>(dimensions: new[] { 1, 3, bitmap.Height, bitmap.Width });

            DirectReadBitmap db = new(bitmap);

            //读取bitmap 像素  bytes [B,G,R,A]
            Parallel.For(0, bitmap.Height, (idx, state) =>
            {

                //WriteBitmapToTensor(db, tensor, idx);

                for (int x = 0; x < db.Width; x++)
                {
                    Color pixel = db.GetPixel(x, idx);

                    tensor[0, 0, idx, x] = pixel.B / 255f;
                    tensor[0, 1, idx, x] = pixel.G / 255f;
                    tensor[0, 2, idx, x] = pixel.R / 255f;
                }

            });

            return tensor;

        }

        public static Tensor<float> SimpToOnnxTensor_13hw(this Bitmap bitmap)
        {

            Tensor<float> tensor = new DenseTensor<float>(dimensions: new[] { 1, 3, bitmap.Height, bitmap.Width });

            for (int y = 0; y < bitmap.Height; y++)
            {
                //WriteBitmapToTensor(db, tensor, idx);

                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);

                    tensor[0, 0, y, x] = pixel.B / 255f;
                    tensor[0, 1, y, x] = pixel.G / 255f;
                    tensor[0, 2, y, x] = pixel.R / 255f;
                }

            }

            return tensor;

        }

        public static Tensor<float> ToOnnxTensor_13wh(this Bitmap bitmap)
        {

            Tensor<float> tensor = new DenseTensor<float>(dimensions: new[] { 1, 3, bitmap.Width, bitmap.Height });

            DirectReadBitmap db = new(bitmap);

            //读取bitmap 像素  bytes [B,G,R,A]
            Parallel.For(0, bitmap.Height, (idx, state) =>
            {

                //WriteBitmapToTensor(db, tensor, idx);

                for (int x = 0; x < db.Width; x++)
                {
                    Color pixel = db.GetPixel(x, idx);

                    tensor[0, 0, x, idx] = pixel.B / 255f;
                    tensor[0, 1, x, idx] = pixel.G / 255f;
                    tensor[0, 2, x, idx] = pixel.R / 255f;
                }

            });

            return tensor;

        }

        public static Tensor<float> ToOnnxTensor_1hw3(this Bitmap bitmap)
        {
            Tensor<float> tensor = new DenseTensor<float>(dimensions: new[] { 1, bitmap.Height, bitmap.Width, 3 });

            DirectReadBitmap db = new(bitmap);

            //读取bitmap 像素  bytes [B,G,R,A]
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = db.GetPixel(x, y);

                    tensor[0, y, x, 0] = pixel.B / 255f;
                    tensor[0, y, x, 1] = pixel.G / 255f;
                    tensor[0, y, x, 2] = pixel.R / 255f;
                }
            }

            return tensor;
        }

        public static Tensor<float> FastToOnnxTensor_13hw(this Bitmap source)
        {
            float[] floatArray = new float[source.Width * source.Height * 3];

            BitmapData bitmap_data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            byte[] bitmap_bytes = new byte[Math.Abs(bitmap_data.Stride) * source.Height];

            Marshal.Copy(bitmap_data.Scan0, bitmap_bytes, 0, bitmap_bytes.Length);

            int total_pixels_count = source.Width * source.Height;


            Parallel.For(0, total_pixels_count, (p_idx, state) =>
            {

                int g_idx = p_idx + total_pixels_count;
                int b_idx = p_idx + (total_pixels_count * 2);

                floatArray[p_idx] = bitmap_bytes[(p_idx * 3) + 2] / 255f;//R
                floatArray[g_idx] = bitmap_bytes[(p_idx * 3) + 1] / 255f;//G
                floatArray[b_idx] = bitmap_bytes[p_idx * 3] / 255f;//B

            });

            source.UnlockBits(bitmap_data);

            return new DenseTensor<float>(new Memory<float>(floatArray), new int[] { 1, 3, source.Height, source.Width });

        }

        public static Bitmap Resize(this Bitmap source, int new_width, int new_height)
        {

            float w_scale = (float)new_width / source.Width;
            float h_scale = (float)new_height / source.Height;

            float min_scale = Math.Min(w_scale, h_scale);

            int nw = (int)(source.Width * min_scale);
            int nh = (int)(source.Height * min_scale);


            int pad_dims_w = (new_width - nw) / 2;
            int pad_dims_h = (new_height - nh) / 2;


            Bitmap new_bitmap = new(new_width, new_height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(new_bitmap))
            {
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.InterpolationMode = InterpolationMode.Low;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                g.DrawImage(source,
                            new Rectangle(pad_dims_w, pad_dims_h, nw, nh),
                            new Rectangle(0, 0, source.Width, source.Height),
                            GraphicsUnit.Pixel);
            }

            return new_bitmap;
        }


        public static Bitmap ResizeWithoutPadding(this Bitmap source, int new_width, int new_height)
        {

            Bitmap new_bitmap = new(new_width, new_height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(new_bitmap))
            {
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.CompositingMode = CompositingMode.SourceCopy;
                g.InterpolationMode = InterpolationMode.Low;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                g.DrawImage(image: source,
                            destRect: new Rectangle(0, 0, new_width, new_height),
                            srcRect: new Rectangle(0, 0, source.Width, source.Height),
                            srcUnit: GraphicsUnit.Pixel);
            }

            return new_bitmap;

        }

        public static void DrawPrediction(this Bitmap source, List<PredictionBox> predictionBoxs, Draw draw)
        //将BBox按比例缩小，根据bitmap大小画锚框
        {
            if (predictionBoxs is null || predictionBoxs.Count == 0)
            {
                return;
            }

            using Graphics g = Graphics.FromImage(source);
            foreach (PredictionBox p in predictionBoxs)
            {
                int top = (int)((float)p.BBox.Top / p.InputHeight * source.Height);
                int left = (int)((float)p.BBox.Left / p.InputWidth * source.Width);
                int bottom = (int)((float)p.BBox.Bottom / p.InputHeight * source.Height);
                int right = (int)((float)p.BBox.Right / p.InputWidth * source.Width);

                g.DrawRectangle(pen: new Pen(draw.BoxColor, 3),
                                rect: new Rectangle(left, top, right - left, bottom - top));

                g.DrawString(s: $"{p.LabelName}, {p.Confidence:0.00}",
                             font: new Font("Arial", draw.FontSize, FontStyle.Regular),
                             brush: draw.LabelColor,
                             point: new PointF(left, top));
            }
        }
    }

    public record Draw(Brush BoxColor, Brush LabelColor, float FontSize);

    //参考自: https://stackoverflow.com/questions/24701703/c-sharp-faster-alternatives-to-setpixel-and-getpixel-for-bitmaps-for-windows-f
    public class DirectReadBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Color[] Pixels { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }


        public DirectReadBitmap(Bitmap source)
        {
            Bitmap = source;
            Width = source.Width;
            Height = source.Height;

            Pixels = new Color[source.Width * source.Height];

            BitmapData bitmap_data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            byte[] bitmap_bytes = new byte[Math.Abs(bitmap_data.Stride) * source.Height];

            //copy bytes to pixels
            Marshal.Copy(bitmap_data.Scan0, bitmap_bytes, 0, bitmap_bytes.Length);

            Parallel.For(0, Pixels.Length, (p_idx, state) =>
            {
                Color color = Color.FromArgb(bitmap_bytes[(p_idx * 3) + 2], bitmap_bytes[(p_idx * 3) + 1], bitmap_bytes[p_idx * 3]);
                Pixels[p_idx] = color;

            });


            source.UnlockBits(bitmap_data);

            //var stream = new MemoryStream(bitmap_bytes);
            //var bmp = new Bitmap(stream);
            //bmp.Save($".\\result_images\\{new Random().Next()}.png");

        }


        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);

            return Pixels[index];
        }

        public void Dispose()
        {
            if (Disposed)
            {
                return;
            }

            Disposed = true;
            Bitmap.Dispose();
        }
    }
}

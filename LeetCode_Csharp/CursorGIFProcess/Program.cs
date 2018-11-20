using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApp1
{
    static class Program
    {
        //图片是否帧数过多:是true 不多false
        static bool _isNumberOfFramesTooLarge = true;


        private static void Main()
        {
            //  Mac : /Users/w/Desktop/RWBusy.gif
            //  Win : C:/Users/w/Desktop/RWBusy.gif
            string picPath = "C:/Users/w/Desktop/RWBusy.gif";
            string savePath = "C:/Users/w/Desktop/RWBusy";
            GetFrames(picPath, savePath);
        }

        /// <summary>
        /// 获取图片中的各帧
        /// </summary>
        /// <param name="pPath">图片路径</param>
        /// <param name="pSavePath">保存路径</param>
        private static void GetFrames(string pPath, string pSavePath)
        {
            Console.ReadKey();
            Console.WriteLine("准备读取图片");
            Image gif = Image.FromFile(pPath);
            Console.WriteLine("读取图片成功");

            //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd);

            Console.WriteLine($"帧数{count}\n每帧宽度 {gif.Width}\n每帧高度 {gif.Height}");


            //要是帧数过长
            if (_isNumberOfFramesTooLarge)
            {
                int multi = 2; //缩放倍数

                //生成底图
                Bitmap outputBitmap = new Bitmap(gif.Width, gif.Height * count / multi);
                Graphics g = Graphics.FromImage(outputBitmap);
                //以Jpeg格式保存各帧并操作合成
                for (int i = 0; i < count; i++)
                {
                    //跳过倍数的帧
                    if (i % multi == 0)
                    {
                        continue;
                    }

                    //选择并保存每帧
                    gif.SelectActiveFrame(fd, i);
                    //gif.Save(pSavePath + "/frame_" + i + ".png", ImageFormat.Png);

                    //在相应的起始点上作图
                    g.DrawImage(gif, 0, i / multi * gif.Height);
                }

                //保存底图
                g.Dispose();
                outputBitmap.Save(pSavePath + "/Res.png", ImageFormat.Png);
            }
            //要是帧数不多
            else
            {
                //生成底图
                Bitmap outputBitmap = new Bitmap(gif.Width, gif.Height * count);
                Graphics g = Graphics.FromImage(outputBitmap);
                //以Jpeg格式保存各帧并操作合成
                for (int i = 0; i < count; i++)
                {
                    //选择并保存每帧
                    gif.SelectActiveFrame(fd, i);
                    //gif.Save(pSavePath + "/frame_" + i + ".png", ImageFormat.Png);

                    //在相应的起始点上作图
                    g.DrawImage(gif, 0, i * gif.Height);
                }

                //保存底图
                g.Dispose();
                outputBitmap.Save(pSavePath + "/Res.png", ImageFormat.Png);
            }
        }
    }
}
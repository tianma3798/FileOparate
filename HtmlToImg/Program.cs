using FileOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace HtmlToImg
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThumbnailOperate _operate = new ThumbnailOperate();
            //_operate.TestOne();


            ////获取当前显示器的宽度和高度
            //int width = Screen.PrimaryScreen.Bounds.Width;
            //int height = Screen.PrimaryScreen.Bounds.Height;
            //Console.WriteLine(width + "*" + height);
            ////获取当前桌面工作区域的宽度高度（去除工具栏等）
            //int workWidth = Screen.PrimaryScreen.WorkingArea.Width;
            //int workHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //Console.WriteLine(workWidth + "*" + workHeight);

            TestOne();

            Console.Read();
        }


        public static void TestOne()
        {
            ThumbnailImg img = new ThumbnailImg("e:\\one.png");
            //img.SetToJpeg();
            img.SetToGif();
            ThumbnailOperate _operate = new ThumbnailOperate("http://korea.weilanliuxue.cn", img);
            _operate.GenerateImg();

            Console.WriteLine("保存陈宫");
        }


    }
}

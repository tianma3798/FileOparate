using FileOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            // TestOne();
            TestTwo();

            Console.Read();
        }



        public static void TestTwo()
        {
            Thread thread = new Thread(new ThreadStart(_GenerateImage));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            Console.WriteLine("线程启动");
        }

        private static void _GenerateImage()
        {
            WebBrowser browser = new WebBrowser();
            browser.ScrollBarsEnabled = false; //是否启用滚动条
            browser.ScriptErrorsSuppressed = false; //是否显示脚本错误
            string _url = "http://blog.csdn.net/u011127019/article/category/6152933";
            browser.Navigate(_url);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(_DocumentCompleted);
            while (browser.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();
            Console.WriteLine("线程结束");
        }

        /// <summary>
        /// 页面加载完成事件，放弃使用
        /// </summary>
        private static void _DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            string str = browser.ReadyState.ToString();
            Console.WriteLine(str);
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

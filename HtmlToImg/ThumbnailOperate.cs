using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace HtmlToImg
{
    /// <summary>
    /// 使用操作
    /// </summary>
    public class ThumbnailOperate
    {
        /// <summary>
        /// 网页地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 设置浏览器宽度
        /// </summary>
        public int BrowserWidth { get; set; }
        /// <summary>
        /// 源图片的宽度
        /// </summary>
        public int Width
        {
            get
            {
                if (_bit != null)
                    return _bit.Width;
                return 0;
            }
        }
        /// <summary>
        /// 源图片的高度
        /// </summary>
        public int Height
        {
            get
            {
                if (_bit != null)
                    return _bit.Height;
                return 0;
            }
        }
        /// <summary>
        /// 生成的图片信息定义
        /// </summary>
        public ThumbnailImg TargetImg { get; set; }
        /// <summary>
        /// 生成源图片定义
        /// </summary>
        private Bitmap _bit = null;


        /// <summary>
        /// 初始化构造器
        /// </summary>
        /// <param name="Url">网页地址</param>
        /// <param name="BrowserWidth">设置浏览器宽度</param>
        /// <param name="TargetImg">生成图片定义</param>
        public ThumbnailOperate(string Url, int BrowserWidth, ThumbnailImg TargetImg)
        {
            this.Url = Url;
            this.BrowserWidth = BrowserWidth;
            this.TargetImg = TargetImg;
        }
        /// <summary>
        /// 初始化构造器，使用当前显示器的宽度
        /// </summary>
        /// <param name="Url">网页地址</param>
        /// <param name="TargetImg">生成图片的信息</param>
        public ThumbnailOperate(string Url, ThumbnailImg TargetImg) : this(Url, Screen.PrimaryScreen.Bounds.Width, TargetImg)
        {
        }
        /// <summary>
        /// 生成图片
        /// </summary>
        public void GenerateImg()
        {
            Thumbnail thumg = new Thumbnail(Url, BrowserWidth);
            _bit = thumg.GenerateImage();
            //根据指定的宽度和高度缩放图片
            if (TargetImg.IsCustomer)
            {
                _bit = ImgHelper.ResizeCut(_bit, TargetImg.TargetWidth, TargetImg.TargetHeight);
            }
            //保存图片
            _bit.Save(TargetImg.FullName, TargetImg.Format);
            _bit.Dispose();
        }




        //public void TestOne()
        //{
        //    Thumbnail thumb = new Thumbnail("http://usa.weilanliuxue.cn/", 1440, 900, 600, 600);
        //    Bitmap bit = thumb.GenerateImage();
        //    bit.Save("e:\\index.jpg", ImageFormat.Jpeg);
        //    bit.Dispose();
        //}


    }
}

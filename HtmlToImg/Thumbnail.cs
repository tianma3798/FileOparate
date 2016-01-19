﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Drawing;

using System.Windows.Forms;

namespace HtmlToImg
{
    /// <summary>
    /// 网页生成生成图片帮助类
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// 网页生成的图片
        /// </summary>
        private Bitmap _bitmap;
        private string _url;
        private int _browserWidth, _browserHeight, _tWidth, _tHeight;
        /// <summary>
        /// 是否使用，指定的宽度和高度
        /// </summary>
        public bool IsCustumer { get; set; }
        /// <summary>
        /// 指定网页地址，使用页面的body的高度
        /// 生成图片的，宽度和高度与body相同
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="browserWidth">浏览器宽度</param>
        public Thumbnail(string url, int browserWidth)
        {
            IsCustumer = true;
            _url = url;
            _browserWidth = browserWidth;
        }
        /// <summary>
        /// 初始化构造
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="browserWidth">浏览器宽度</param>
        /// <param name="browserHeight">浏览器高度</param>
        /// <param name="tWidth">生成图片宽度</param>
        /// <param name="tHeight">生成图片高度</param>
        public Thumbnail(string url, int browserWidth, int browserHeight, int tWidth, int tHeight)
        {
            _url = url;
            _browserWidth = browserWidth;
            _browserHeight = browserHeight;
            _tWidth = tWidth;
            _tHeight = tHeight;
        }
        /// <summary>
        /// 获取网页的图片
        /// </summary>
        /// <param name="url">网页地址</param>
        /// <param name="browserWidth">浏览器宽度</param>
        /// <param name="browserHeight">浏览器高度</param>
        /// <param name="tWidth">生成图片宽度</param>
        /// <param name="tHeight">生成图片高度</param>
        public static Bitmap GetThumbnail(string url, int browserWidth, int browserHeight, int tWidth, int tHeight)
        {
            Thumbnail thumb = new Thumbnail(url, browserWidth, browserHeight, tWidth, tHeight);
            return thumb.GenerateImage();
        }
        /// <summary>
        /// 生成图片信息
        /// </summary>
        /// <returns></returns>
        public Bitmap GenerateImage()
        {
            Thread thread = new Thread(new ThreadStart(_GenerateImage));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return _bitmap;
        }
        /// <summary>
        /// 使用WebBrowser生成图片
        /// </summary>
        private void _GenerateImage()
        {
            WebBrowser browser = new WebBrowser();
            browser.ScrollBarsEnabled = false;
            browser.Navigate(_url);
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(_DocumentCompleted);
            while (browser.ReadyState != WebBrowserReadyState.Complete)
                Application.DoEvents();
            browser.Dispose();
        }
        /// <summary>
        /// 页面加载完成事件
        /// </summary>
        private void _DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            if (IsCustumer)
            {
                //生成默认body宽度和高度的图片（最常用）
                Rectangle bodyRect = browser.Document.Body.OffsetRectangle;
                browser.ClientSize = new Size(_browserWidth, bodyRect.Height);
                browser.ScrollBarsEnabled = false;
                _bitmap = new Bitmap(bodyRect.Width, bodyRect.Height);
                browser.BringToFront();
                browser.DrawToBitmap(_bitmap, bodyRect);
                _bitmap = (Bitmap)_bitmap.GetThumbnailImage(bodyRect.Width, bodyRect.Height, null, IntPtr.Zero);
            }
            else
            {
                //生成自定义宽度和高度的图片
                browser.ClientSize = new Size(_browserWidth, _browserHeight);
                _bitmap = new Bitmap(browser.Bounds.Width, browser.Bounds.Height);
                browser.DrawToBitmap(_bitmap, browser.Bounds);
                _bitmap = (Bitmap)_bitmap.GetThumbnailImage(_tWidth, _tHeight, null, IntPtr.Zero);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileOperate
{
    /// <summary>
    /// 生成网页图片定义
    /// </summary>
    public class ThumbnailImg
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="FullName">文件全名称</param>
        public ThumbnailImg(string FullName)
        {
            this.IsCustomer = false;
            this.Format = ImageFormat.Png;
            this.FullName = FullName;
            FileInfo info = new FileInfo(FullName);
            this.Name = info.Name;
            this.Directory = info.DirectoryName;
        }
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="FullName">文件全名称</param>
        /// <param name="width">图片的宽度</param>
        /// <param name="height">图片的高度</param>
        public ThumbnailImg(string FullName, int width, int height)
        {
            this.IsCustomer = true;
            this.FullName = FullName;
            this.TargetWidth = width;
            this.TargetHeight = TargetHeight;

            this.Format = ImageFormat.Png;

            FileInfo info = new FileInfo(FullName);
            this.Name = info.Name;
            this.Directory = info.DirectoryName;
        }


        /// <summary>
        /// 图片格式，默认为png
        /// </summary>
        public ImageFormat Format;
        /// <summary>
        /// 是否使用，指定的宽度和高度
        /// </summary>
        public bool IsCustomer { get; set; }
        /// <summary>
        /// 生成图片的宽度，高度
        /// </summary>
        public int TargetWidth { get; set; }
        /// <summary>
        /// 生成图片的高度
        /// </summary>
        public int TargetHeight { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件目录
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// 文件全名称
        /// </summary>
        public string FullName
        {
            get; set;
        }


        /// <summary>
        /// 设置成jpeg图片
        /// </summary>
        public void SetToJpeg()
        {
            this.Format = ImageFormat.Jpeg;
        }
        public void SetToGif()
        {
            this.Format = ImageFormat.Gif;
        }

    }
}

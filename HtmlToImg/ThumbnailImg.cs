using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToImg
{
    /// <summary>
    /// 生成网页图片定义
    /// </summary>
    public class ThumbnailImg
    {
        /// <summary>
        /// 图片格式，默认为jpeg
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
            get
            {
                return Directory + Name;
            }
        }

    }
}

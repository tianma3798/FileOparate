using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms;

using FileOperate;

namespace HtmlToImg_Tool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        // ThumbnailOperate _operate = null;
        public MainWindow()
        {
            InitializeComponent();
            _init();
        }
        /// <summary>
        /// 初始化加载 
        /// </summary>
        private void _init()
        {
            txtUrl.Focus();
            txtName.Text = "image1.png";
            lblDiretory.Content = Common.LocalPathHelper.DesktopPath;
        }

        //生成图片
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string fullname = lblDiretory.Content + "\\" + txtName.Text;
            ThumbnailImg img = new ThumbnailImg(fullname);
            ThumbnailOperate _operate = new ThumbnailOperate(txtUrl.Text, img);

            _operate.GenerateImg();

            System.Windows.MessageBox.Show("生成图片成功");
        }

        //打开文件夹
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", lblDiretory.Content.ToString());
        }

        //选择设置目录
        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            lblDiretory.Content = folderDialog.SelectedPath.Trim();
        }
    }
}

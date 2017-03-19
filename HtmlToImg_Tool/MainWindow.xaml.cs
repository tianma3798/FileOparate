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

            //判断是否是IE11模式
            WebBrowserRegistry reg = new WebBrowserRegistry();
            if (reg.Exists())
            {
                ie11Btn.Visibility = Visibility.Hidden;
            }
            else
            {
                ShowMsg("默认使用ie7模式打开页面，为了更好使用，建议设置成IE11模式并重新打开程序，如果你的系统支持ie11");
            }
        }

        //生成图片
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string fullname = lblDiretory.Content + "\\" + txtName.Text;
            ThumbnailImg img = new ThumbnailImg(fullname);
            ComboBoxItem selecedItem = comboWidth.SelectedValue as ComboBoxItem;
            int width = Convert.ToInt32(selecedItem.Content);
            ThumbnailOperate _operate = new ThumbnailOperate(txtUrl.Text, width, img);

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //默认使用IE11模式
            try
            {
                WebBrowserRegistry reg = new WebBrowserRegistry();
                reg.SetIEDocument();
                ShowMsg("设置成功");
                ie11Btn.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        public static void ShowMsg(string content)
        {
            System.Windows.MessageBox.Show(content);
        }
    }
}

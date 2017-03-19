using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperate
{
    /// <summary>
    /// WebBrowser,指定IE浏览器的文档模式
    /// </summary>
    public class WebBrowserRegistry
    {
        /// <summary>
        /// 指定是否是32位的引用
        /// </summary>
        public bool IsWin32 { get; set; } = true;
        //HKEY_LOCAL_MACHINE\ 下的项
        private string key32 = @"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";
        private string key64 = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";

        /// <summary>
        /// 获取当前进程名称
        /// </summary>
        /// <returns></returns>
        public string GetCallProgramName()
        {
            string progressname = Process.GetCurrentProcess().ProcessName;
            return $"{progressname}.exe";
        }
        /// <summary>
        /// 获取当前key
        /// </summary>
        /// <returns></returns>
        public RegistryKey GetCurKey()
        {
            if (IsWin32)
                return Registry.LocalMachine.OpenSubKey(key32, true);
            return Registry.LocalMachine.OpenSubKey(key64, true);
        }
        /// <summary>
        /// 判断当前注册表键值是否存在
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            RegistryKey curKey = GetCurKey();
            string[] names = curKey.GetValueNames();
            if (names == null)
                return false;
            string name = GetCallProgramName();
            return names.Any(q => q == name);
        }
        /// <summary>
        /// 指定IE
        /// </summary>
        /// <param name="document"></param>
        public void SetIEDocument(WebBrowserIE document = WebBrowserIE.IE11)
        {
            RegistryKey curKey = GetCurKey();
            curKey.SetValue(GetCallProgramName(), document.GetHashCode(), RegistryValueKind.DWord);
        }
        /// <summary>
        /// IE浏览器的文档模式
        /// </summary>
        public enum WebBrowserIE
        {
            IE11 = 11000,
            IE10 = 10000,
            IE9 = 9000,
            IE8 = 8000,
            IE7 = 7000
        }
    }
}

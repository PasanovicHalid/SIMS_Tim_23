using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ZdravoCorp.Service;

namespace ZdravoCorp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
        }

        public static void ChangeLanguage(string language)
        {
            CultureInfo lang = new System.Globalization.CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = lang;
        }
    }
}

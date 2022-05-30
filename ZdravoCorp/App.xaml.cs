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
using ZdravoCorp.View.Core;

namespace ZdravoCorp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ChangeLanguage(string currLang)
        {
            if (currLang.Equals("sr"))
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr");
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en");
            }
        }
    }
}

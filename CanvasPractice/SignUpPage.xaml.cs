using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CanvasPractice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : Page
    {
        private LoginPage _loginPage;
        private Dictionary<string, string> _userInfor;
        private string _userName;
        private string _passWord;

        public SignUpPage()
        {
            this.InitializeComponent();
            _loginPage = new LoginPage();
            _userInfor = new Dictionary<string, string>();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            _userInfor.Add(_userName, _passWord);
            _loginPage.setUserInfor(_userInfor);
        }

        private void phone_entry(TextBox sender, TextChangedEventArgs args)
        {

        }

        private void email_entry(TextBox sender, TextChangedEventArgs args)
        {

        }

        private void password_entry(object sender, TextChangedEventArgs e)
        {
            _passWord = e.ToString();

        }

        private void userName_entry(TextBox sender, TextChangedEventArgs args)
        {
            _userName = args.ToString();
        }

 
    }
}

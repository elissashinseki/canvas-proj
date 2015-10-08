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
    public sealed partial class LoginPage : Page
    {
        //private attributes
        private Dictionary<string, string> _userInfor = new Dictionary<string, string>(); // stores the user infor key -> <username, addressre> to <password>
        private string _userName = "";
        private string _passWord = "";

        // initializing the page
        public LoginPage()
        {
            this.InitializeComponent();
        }

        //userName
        private void enterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _userName = e.ToString();
        }

        //password
        private void passWordText_SelectionChanged(object sender, TextChangedEventArgs e)
        {
            _passWord = e.ToString();
        }

        //the sign up page will allow user to navigate to the sigh up page
        private void signUpButton_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SignUpPage));
        }


        private void loginButton_click(object sender, RoutedEventArgs e)
        {
            Boolean canLogin = false;

           if(  _userInfor != null && _userInfor.ContainsKey(_userName))//check if this is a valid user name, display stuff
            {
                //check for password
                if(_userInfor.TryGetValue(_userName, out _passWord))
                {
                    canLogin = true;
                }
            } 
           
           if(canLogin)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
           else
            {
                //display the username or password is wrong   
                              
            }     
        }
      
        
        private void hideTextButton_click(object sender, ContextMenuEventArgs e)
        {

        }

        //fetch the password and username function calls
        public string getUserName()
        {
            return _userName;
        }
        public string getPassWord()
        {
            return _passWord;
        }
        public Dictionary<string,string> getUserInfor()
        {
            return _userInfor;
        }

        //set use name and password
        public void setUserName(string name)
        {
            _userName = name;
        }
        public void setPassWord(string password)
        {
            _passWord = password;
        }
        public void setUserInfor(Dictionary<string,string> info)
        {
            _userInfor = info;
        }
    }
}

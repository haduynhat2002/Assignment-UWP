using AssignmentT2009M1.Entities;
using AssignmentT2009M1.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AssignmentT2009M1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePages : Page
    {
        private AccountService accountService = new AccountService();
        public ProfilePages()
        {
            this.InitializeComponent();
            this.Loaded += ProfilePages_LoadedAsync;
        }

        private async void ProfilePages_LoadedAsync(object sender, RoutedEventArgs e)
        {
            var account = await accountService.GetInfomation();
            if (account == null)
            {
                ContentDialog contentDialog = new ContentDialog();
                contentDialog.Title = "Login required";
                contentDialog.Content = $"Please login to continue";
                contentDialog.PrimaryButtonText = "Got it";
                this.Frame.Navigate(typeof(Pages.LoginPages));
            }
            else
            {
                Email.Text = account.email;
                FullName.Text = account.firstName + " " + account.lastName;
            }          
        }
    }
}

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
using MailSendTest;

namespace Utilites
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            List<string> ss = new List<string>();
            
            foreach (var el in lvAttachments.Items)
                ss.Add((el as ListViewItem).Content.ToString());
            Library.MailSend(tbFrom.Text,tbTo.Text,tbSubject.Text,tbBody.Text,tbLogin.Text,pbPassword.Password,ss);
        }

        private void FileInputBox_FileNameChanged(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(fibFileInput.FileName);
        }

        private void fibFileInput_FileNameChanged(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(fibFileInput.FileName);
        }

        private void Switcher_Next()
        {
            tcTabControl.SelectedIndex++;
        }

        private void Switcher_Prev()
        {
            tcTabControl.SelectedIndex--;
        }

        private void tbFrom_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action==ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
            }
            else
            if (e.Action == ValidationErrorEventAction.Removed)
            {
               ((Control)sender).ToolTip = "";
            }
        }

        private void btnSend_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsValid(sender as DependencyObject);
        }


        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }
    }
}

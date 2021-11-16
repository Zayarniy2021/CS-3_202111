using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailSendTest;

namespace Utilites.ViewModel
{
    class ViewModel: INotifyPropertyChanged
    {

        string _login = "Admin";
        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Login"));
                    System.Diagnostics.Debug.WriteLine("Login is changed:"+_login);
                }
            }
        }
        public string Password { get; set; } = "Admin";

        public ICommand AccessCommand

        {
            get
            {
                return new DelegateCommand(Execute);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Execute(object obj)
        {

            System.Diagnostics.Debug.WriteLine(obj.ToString());

            //Если проверка правдиви
            if (MailSendTest.Library.Check(_login, Password) == true)
            {

                //То получаем ссылку на TabControl
                System.Windows.Controls.TabControl tabControl = (obj as System.Windows.Controls.TabControl);
                //Пробегаемся по всем TabItem
                foreach (var el in tabControl.Items)
                    (el as System.Windows.Controls.TabItem).IsEnabled = true;
            }



        }

    }
}

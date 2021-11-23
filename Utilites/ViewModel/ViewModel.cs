using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        string _from = "from";
        public string From
        {
            get { return _from; }
            set
            {
                if (_from != value)
                {
                    _from = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("From"));
                    System.Diagnostics.Debug.WriteLine("From is changed:" + _from);
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





        private int tabControlIndex = 0;

        public int TabControlIndex
        {
            get
            {
                return tabControlIndex;
            }
            set
            {
                if (tabControlIndex != value)
                {
                    tabControlIndex = value;
                    Console.WriteLine("Invoke");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TabControlIndex"));
                }
            }
        }

        public ICommand PrevTab
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    //System.Diagnostics.Debug.WriteLine(obj.ToString());
                    TabControlIndex = TabControlIndex == 0 ? (obj as TabControl).Items.Count-1 : --TabControlIndex;                    

                },
                (obj) => true);
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

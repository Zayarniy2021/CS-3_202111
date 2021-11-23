using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibControls
{
    /// <summary>
    /// Логика взаимодействия для TabSwitcher.xaml
    /// </summary>
    public partial class TabSwitcher : UserControl
    {
        public TabSwitcher()
        {
            InitializeComponent();
            btnPrevious.Click += BtnPrevious_Click;


        }






        #region DependencyProperty
        public static readonly DependencyProperty PrevTextProperty = DependencyProperty.Register("PrevText", typeof(string), typeof(TabSwitcher), new PropertyMetadata("Prev"));


        public string PrevText
        {
            get
            {
                return (string)GetValue(PrevTextProperty);
            }
            set
            {
                SetValue(PrevTextProperty, value);
            }
        }



        #endregion



        #region RoutedEvents
        public static readonly RoutedEvent btnPrevClickEvent = EventManager.RegisterRoutedEvent("btnPreviousClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSwitcher));

        public static readonly RoutedEvent btnNextClickEvent = EventManager.RegisterRoutedEvent("btnNextClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSwitcher));



        #endregion

        public event RoutedEventHandler btnPreviousClick
        {
            add { AddHandler(btnPrevClickEvent, value); }
            remove { RemoveHandler(btnPrevClickEvent, value); }
        }






        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btnPrevClickEvent);
            RaiseEvent(args);
        }


        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
                throw new InvalidOperationException("You can't change Content!");
        }

    }
}

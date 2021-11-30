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
using TracksDB;
using System.Data.Entity;

namespace TracksDBUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TracksDB.TracksContainer _dbContainer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _dbContainer = new TracksContainer();
            _dbContainer.TrackSet.Load();
            dgGrid.ItemsSource = _dbContainer.TrackSet.Local;
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            _dbContainer.TrackSet.Add(new Track
            {
                ArtistName = ArtistNameTxt.Text,
                TrackName = TrackNameTxt.Text

            });
            _dbContainer.SaveChanges();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    int id = (row.Item as Track).Id;
                    //SampleContext context = new SampleContext();

                    Track track = _dbContainer.TrackSet
                        .Where(o => o.Id == id)
                        .FirstOrDefault();

                    _dbContainer.TrackSet.Remove(track);
                    _dbContainer.SaveChanges();
                    tbStatus.Text = id + " was removed";
                    break;
                }
        }
    }
}

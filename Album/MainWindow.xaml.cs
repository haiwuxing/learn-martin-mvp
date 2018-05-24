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

namespace AlbumDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PmodAlbum model;

        private bool _isLoadingView = false;
        private bool NotLoadingView { get { return !_isLoadingView; } }

        public MainWindow()
        {
            InitializeComponent();
            model = new PmodAlbum(DsAlbum.AlbumDataSet());
            LoadFromPmod();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            model.Apply();
            LoadFromPmod();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            model.Cancel();
            LoadFromPmod();
        }

        private void SaveToPmod()
        {
            model.Title = txtTitle.Text;
            model.Artist = txtArtist.Text;
            model.IsClassical = chkClassical.IsChecked == true?true:false;
            model.Composer = txtComposer.Text;
        }

        private void LoadFromPmod()
        {
            if (NotLoadingView)
            {
                _isLoadingView = true;
                lstAlbums.ItemsSource = model.AlbumList;
                lstAlbums.SelectedIndex = model.SelectedAlbumNumber;
                txtArtist.Text = model.Artist;
                txtTitle.Text = model.Title;
                this.Title = model.FormTitle;
                chkClassical.IsChecked = model.IsClassical;
                txtComposer.IsEnabled = model.IsComposerFieldEnabled;
                txtComposer.Text = model.Composer;
                btnApply.IsEnabled = model.IsApplyEnabled;
                btnCancel.IsEnabled = model.IsCancelEnabled;
                _isLoadingView = false;
            }
        }
        
        private void SyncWithPmod()
        {
            if (NotLoadingView)
            {
                SaveToPmod();
                LoadFromPmod();
            }
        }

        private void lstAlbums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NotLoadingView)
            {
                model.SelectedAlbumNumber = lstAlbums.SelectedIndex;
                LoadFromPmod();
            }
        }

        //private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //SyncWithPmod();
        //    System.Diagnostics.Debug.WriteLine("txtTitle_TextChanged 被调用");
        //}
    }
}

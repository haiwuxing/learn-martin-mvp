using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumDemo
{
    class PmodAlbum
    {
        private DsAlbum _data;
        private int _selectedAlbumNumber;
        //private Album SelectedAlbum { get; set; }
        public int SelectedAlbumNumber {
            get { return _selectedAlbumNumber; }
            set { _selectedAlbumNumber = value; }
        }

        public DsAlbum Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public PmodAlbum(DsAlbum albums)
        {
            this._data = albums;
            _selectedAlbumNumber = 0;
        }

        public String Title
        {
            get { return SelectedAlbum.Title; }
            set { SelectedAlbum.Title = value; }
        }

        public String Artist
        {
            get { return SelectedAlbum.Artist; }
            set { SelectedAlbum.Artist = value; }
        }

        public bool IsClassical
        {
            get { return SelectedAlbum.IsClassical; }
            set { SelectedAlbum.IsClassical = value; }
        }

        public String Composer
        {
            get
            {
                return (SelectedAlbum.IsComposerNull()) ? "" : SelectedAlbum.Composer;
            }
            set
            {
                if (IsClassical) SelectedAlbum.Composer = value;
            }
        }

        public Album SelectedAlbum
        {
            get { return Data.Albums[SelectedAlbumNumber]; }
        }

        // The title of the window is based on the album title.
        public String FormTitle
        {
            get { return "Album: " + Title; }
        }

        public bool IsComposerFieldEnabled
        {
            get { return IsClassical; }
        }

        public bool IsApplyEnabled
        {
            get { return HasRowChanged; }
        }

        public bool IsCancelEnabled
        {
            get { return HasRowChanged; }
        }

        public bool HasRowChanged
        {
            //get { return SelectedAlbum.RowState == DataRowState.Modified; }
            get { return true; }
        }

        // The list box in the view shows a list of the album titles. PmodAlbum provides this list.
        public String[] AlbumList
        {
            get
            {
                String[] result = new String[Data.Albums.Count];
                for (int i = 0; i < result.Length; i++)
                    result[i] = Data.Albums[i].Title;
                return result;
            }
        }

        internal void Apply()
        {
            SelectedAlbum.AcceptChanges();
        }

        internal void Cancel()
        {
            SelectedAlbum.RejectChanges();
        }
    }
}

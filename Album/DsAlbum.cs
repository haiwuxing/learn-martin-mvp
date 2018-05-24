using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumDemo
{
    public class DsAlbum
    {
        public List<Album> Albums = new List<Album>();
        public int AlbumsRow { get; set; }

        public void AddAlbumsRow(int index, string title, string artist, bool isClassical, string composer)
        {
            Album album = new Album(title, artist, isClassical, composer);
            Albums.Add(album);
        }

        public static DsAlbum AlbumDataSet()
        {
            DsAlbum result = new DsAlbum();
            result.AddAlbumsRow(1, "HQ", "Roy Harper", false, null);
            result.AddAlbumsRow(2, "The Rough Dancer and Cyclical Night", "Astor Piazzola", false, null);
            result.AddAlbumsRow(3, "The Black Light", "Calexico", false, null);
            result.AddAlbumsRow(4, "Symphony No.5", "CBSO", true, "Sibelius");
            return result;
        }
    }
}

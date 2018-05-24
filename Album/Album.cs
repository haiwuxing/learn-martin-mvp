using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumDemo
{
    public class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public bool IsClassical { get; set; }
        public string Composer { get; set; }
        public object RowState { get; internal set; }

        public Album(string title, string artist, bool isClassical, string composer)
        {
            Title = title;
            Artist = artist;
            IsClassical = isClassical;
            Composer = composer;
        }

        internal bool IsComposerNull()
        {
            return Composer == null;
        }

        internal void AcceptChanges()
        {
            throw new NotImplementedException();
        }

        internal void RejectChanges()
        {
            throw new NotImplementedException();
        }
    }
}

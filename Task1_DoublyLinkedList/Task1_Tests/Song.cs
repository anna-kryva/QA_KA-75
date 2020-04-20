using System;

namespace Task1_Tests
{
    public class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public Song()
        {
            Title = "Untitled";
            Author = "Unknown";
            PublicationDate = DateTime.Today;
        }

        public Song(
            string Title,
            string Author,
            DateTime PublicationDate
            )
        {
            this.Title = Title;
            this.Author = Author;
            this.PublicationDate = PublicationDate;
        }

                
    }
}

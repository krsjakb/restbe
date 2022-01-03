using System;

namespace restbe.Models
{
    public class OperatingSystem
    {
        private DateTime _releaseDate;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime releaseDate 
        { 
            get { return _releaseDate.Date; }
            set { _releaseDate = value.Date; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InlogTeste.Models
{
    public class DetalheFilmeModel
    {       
        public string title { get; set; }
        public double vote_average { get; set; }
        public string release_date { get; set; }

        private string backdropPath;
        public string backdrop_path { get { return backdropPath; } set { backdropPath = "https://image.tmdb.org/t/p/w780" + value; } }
        public List<Genre> genres { get; set; }
        public string overview { get; set; }
        public int budget { get; set; }
        public int revenue { get; set; }
        public string runtime { get; set; }
        public int id { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}

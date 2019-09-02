using System;
using System.Collections.Generic;
using System.Text;

namespace InlogTeste.Models
{
    public class RespostaAPI
    {
        public List<Filme> results { get; set; }
    }

    public class Filme
    {
        private string posterPath;
        public string poster_path { get { return posterPath; } set { posterPath = "https://image.tmdb.org/t/p/w154" + value; } }      
        public string title { get; set; }
        public double vote_average { get; set; }
        public string release_date { get; set; }
        public int id { get; set; }
    }
}

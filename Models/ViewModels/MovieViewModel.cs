using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<MovieEntry> Movies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public interface IMoviesRepository
    {
        IQueryable<MovieEntry> Movies { get; }
    }
}

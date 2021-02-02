using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    //temporary storage that will be used to display data sumbitted in a table
    public static class TempStorage
    {
        //creates a list object
        private static List<MovieEntry> entries = new List<MovieEntry>();
        //add the entries into that list object
        public static IEnumerable<MovieEntry> Entries => entries;
        
        public static void AddEntry(MovieEntry entry)
        {
            entries.Add(entry);
        }
    }
}

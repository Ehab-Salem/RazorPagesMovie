#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        

        // Defult Constractor (Dependecy injection to the contextClass)
        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SerchString { get; set; }

        public SelectList Genres { get; set; }
       // public SelectList Rate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string  MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // add list of Genres 
            // using 
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;


            
            // Retrive all Movies Data
            var movies = from m in _context.Movie
                         select m;


            // Add Serch string
            if (!string.IsNullOrEmpty(SerchString))
            {

                movies = movies.Where(s => s.Title.Contains(SerchString));

            }


            if (!string.IsNullOrEmpty(MovieGenre))
            {
               movies =  movies.Where(x => x.Genre == MovieGenre);

            }

            ////
            /////  var maxprice = (from m in this._context.Movie
            //                select m).Max(e=> e.Price);

            // maxprice = maxprice.OrderByDescending(s => s.Price);


            // Movie = await _context.Movie.ToListAsync();

            ///


            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();

       
        }


        ////public void   OnGet()
        ////{
        ////    Movie =  _context.Movie.ToList();
        ////}
    }
}

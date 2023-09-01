using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MovieLogic
    {
        public MovieData AddMov;
        public MovieLogic()
        {
            AddMov = new MovieData();
        }

        public void  Insert(MovieDetails MovObj)
        {

            AddMov.Insert(MovObj);

        }
        public IEnumerable<MovieDetails> GetMovieAll()
        {
           return  AddMov.GetMovieAll();
        }
        public MovieDetails GetMovieById(int Movieid)
        {
           
           return  AddMov.GetMovieById(Movieid);
        }
        public MovieDetails Edit(int Movieid)
        {

            return AddMov.Edit(Movieid);
        }

        public void Edits(MovieDetails MovObj)
        {
         AddMov.Edits(MovObj);
        }
        //public void Delete(int  Movieid)
        //{
        //  AddMov.Delete(Movieid);

        //}
        public IEnumerable<MovieDetails> Index()
        {
           return AddMov.Index();
        }

        //public SeatObject Seat(SeatObject Movieid)
        //{
        //    return AddMov.Seat(Movieid);
        //}
        //public SeatsToBeRendered Seats(SeatsToBeRendered Obj)
        //{

        //    return AddMov.Seats(Obj);
        //}
        public SeatsToBeRendered Select(SeatsToBeRendered Seat)
        {
            return AddMov.Select(Seat);
        }

    }

}

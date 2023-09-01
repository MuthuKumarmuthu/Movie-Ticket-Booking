using BusinessObject;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataAccess
{
    public class MovieData
    {
        public
        string ImagePath = WebConfigurationManager.AppSettings["imagepath"];

        public MoviebookingEntities db;
        public MovieData()
        {
            db = new MoviebookingEntities();
        }
        public void Insert(MovieDetails MovObj)
        {

            if (!System.IO.Directory.Exists(ImagePath))
            {
                System.IO.Directory.CreateDirectory(ImagePath);
            }

            Guid moviesImg = Guid.NewGuid();
            string imageName = moviesImg + ".Jpeg";
            string path = Path.Combine(ImagePath, imageName);


            byte[] imageBytes = null;
            using (var binaryReader = new BinaryReader((MovObj.File.InputStream)))
            {
                imageBytes = binaryReader.ReadBytes(MovObj.File.ContentLength);
            }
            File.WriteAllBytes(path, imageBytes);
            AddMovy Movj = new AddMovy()
            {
                Memberid = MovObj.Memberid,
                Moviename = MovObj.Moviename,
                Movieimage = moviesImg.ToString(),
                Genre = MovObj.Genre,
                Language = MovObj.Language,
                Releasedate = MovObj.Releasedate,
                Description = MovObj.Description,
                Price=MovObj.Price,
                Createdon = DateTime.Now,
                Createdby = MovObj.Username,
                Updatedon = DateTime.Now,
                Updatedby = MovObj.Username,
            };
            db.AddMovies.Add(Movj);
            db.SaveChanges();

        }
        //var result = (from mov in db.AddMovies
        //              select new MovieDetails
        //              {
        //                  Movieid = mov.Movieid,
        //                  MovieName = mov.Moviename,
        //                  ImageUrl = imageurl + mov.Movieimage
        //              }).ToList();
        //    return result;



        public IEnumerable<MovieDetails> GetMovieAll()
        {
            string imageurl = WebConfigurationManager.AppSettings["imageurl"];

            var result = (from mov in db.AddMovies
                          select new MovieDetails
                          {

                              Movieid = mov.Movieid,
                              Memberid = mov.Memberid,
                              Moviename = mov.Moviename,
                              ImageUrl = imageurl+mov.Movieimage,
                              Genre = mov.Genre,
                              Language = mov.Language,
                              Releasedate = mov.Releasedate,
                              Description = mov.Description,
                            
                              Price =mov.Price,
                          }).ToList();


            return result;


        }
        public MovieDetails GetMovieById(int Movieid)
        {

            MovieDetails movieDetails = new MovieDetails();
            string imageurl = WebConfigurationManager.AppSettings["imageurl"];
            MoviebookingEntities db = new MoviebookingEntities();
            var result = db.AddMovies.Where(x => x.Movieid == Movieid);

            if (result.Any())
            {
                var movie = result.FirstOrDefault();
                movieDetails.Memberid = movie.Memberid;
                movieDetails.Movieid = movie.Movieid;
                movieDetails.Moviename = movie.Moviename;
                movieDetails.ImageUrl = imageurl + movie.Movieimage;
                movieDetails.Genre = movie.Genre;
                movieDetails.Language = movie.Language;
                movieDetails.Releasedate = movie.Releasedate;
                movieDetails.Description = movie.Description;
                movieDetails.Price = movie.Price;
            }

            return movieDetails;

        }
        public MovieDetails Edit(int Movieid) //single
        {
            //  MoviebookingEntities db = new MoviebookingEntities();
            var rest = new MovieDetails();
            var res = db.AddMovies.Where(x => x.Movieid == Movieid).FirstOrDefault();
            {
                var mov = res;

                rest.Movieid = mov.Movieid;
                rest.Memberid = mov.Memberid;
                rest.Moviename = mov.Moviename;
                //rest.Movieimage = mov.Movieimage;
                rest.Genre = mov.Genre;
                rest.Language = mov.Language;
                rest.Releasedate = mov.Releasedate;
                rest.Description = mov.Description;
                
                rest.Price = mov.Price;
                rest.Createdby = mov.Createdby;
                rest.Createdon = mov.Createdon;

            }
            return rest;

        }
        public void Edits(MovieDetails MovObj)

        {
            string ImagePath = WebConfigurationManager.AppSettings["imagepath"];

            if (!System.IO.Directory.Exists(ImagePath))
            {
                System.IO.Directory.CreateDirectory(ImagePath);
            }

            Guid moviesImg = Guid.NewGuid();
            string imageName = moviesImg + ".Jpeg";
            string path = Path.Combine(ImagePath, imageName);


            byte[] imageBytes = null;
            using (var binaryReader = new BinaryReader((MovObj.File.InputStream)))
            {
                imageBytes = binaryReader.ReadBytes(MovObj.File.ContentLength);
            }
            File.WriteAllBytes(path, imageBytes);
            MoviebookingEntities db = new MoviebookingEntities();
            var result = db.AddMovies.SingleOrDefault(x => x.Movieid == MovObj.Movieid);
            {
                result.Memberid = MovObj.Memberid;
                result.Moviename = MovObj.Moviename;
                result.Movieimage = moviesImg.ToString();
                result.Genre = MovObj.Genre;
                result.Language = MovObj.Language;
                result.Releasedate = MovObj.Releasedate;
                result.Description = MovObj.Description;
                result.Price = MovObj.Price;
                result.Createdon = MovObj.Createdon;
                result.Createdby = MovObj.Createdby;
                result.Updatedon = DateTime.Now;
                result.Updatedby = MovObj.Username;

            };

            db.Entry(result).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


        }
        //public MovieDetails Delete(int Movieid)
        //{
        //    MoviebookingEntities db = new MoviebookingEntities();
        //    var result = from mov in db.AddMovies select new MovieDetails();
        //    var res = result.Single(x => x.Movieid == Movieid);
        //    return res;
        //}

        //public void Delete(int  Movieid)
        //{
       
        //    MoviebookingEntities db = new MoviebookingEntities();
        //    MovieDetails Mov = new MovieDetails();
         
        //    var result = db.AddMovies.Where(x => x.Movieid == Movieid).SingleOrDefault();

        //    {
        //        result.Movieid = result.Movieid;
        //        result.Memberid = result.Memberid;
        //        result.Moviename = result.Moviename;
        //        result.Movieimage = result.Movieimage;
        //        result.Genre = result.Genre;
        //        result.Language = result.Language;
        //        result.Releasedate = result.Releasedate;
        //        result.Description = result.Description;

        //        result.Price = result.Price;
        //        result.Createdon = result.Createdon;
        //        result.Createdby = result.Createdby;
        //        result.Updatedon = result.Updatedon;
        //        result.Updatedby = result.Updatedby;

        //    };

        //    db.AddMovies.Remove(result);
        //    db.SaveChanges();
         

        //}
        public IEnumerable<MovieDetails> Index()
        {
            string imageurl = WebConfigurationManager.AppSettings["imageurl"];
            MoviebookingEntities db = new MoviebookingEntities();
            var result = (from mov in db.AddMovies
                          select new MovieDetails
                          {
                              Movieid = mov.Movieid,
                              Moviename = mov.Moviename,
                              ImageUrl = imageurl + mov.Movieimage
                          }).ToList();
            return result;
          

        }
        public SeatObject Seat(SeatObject Mov)
        {
            MoviebookingEntities db = new MoviebookingEntities();

            var res = db.AddMovies.Single(x => x.Movieid == Mov.Movieid);

            SeatObject Reg = new SeatObject();

            {
                var obj = db.AddMovies.Where(a => a.Movieid == Mov.Movieid);
                if (obj.Any())
                {
                    for (var i = 0; i < Mov.Seatno.Length; i++)
                    {
                        Seatbooking books = new Seatbooking();
                        books.Memberid = Mov.Memberid; ;
                        books.Movieid = Mov.Movieid;
                        books.Seatid = Mov.Seatno[i];
                        books.Ticketprice = Mov.Ticketprice;
                        db.Seatbookings.Add(books);
                        
                        db.SaveChanges();

                    };
                    

                }
            }
            return Reg;
        }
        //public SeatObject Seats(SeatObject Obj)
        //{
        //    SeatObject seatData = new SeatObject();
        //    var res = db.Seatbookings.Where(x => x.Movieid == Obj.Movieid).FirstOrDefault();
        //    {
        //        seatData.Movieid = res.Movieid;
        //        seatData.Seatid = res.Seatid;
        //        return seatData;
        //    }

        //}
        public SeatsToBeRendered Select(SeatsToBeRendered Sea)
        {
            SeatsToBeRendered seatData = new SeatsToBeRendered();
            var rest = db.AddMovies.Where(x => x.Movieid == Sea.Movieid).FirstOrDefault();

            {

             
                seatData.Price = rest.Price;


            }
            return seatData;
        }



    }
}

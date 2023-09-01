using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace BusinessObject
{
    public class MovieObject
    {

        public int Movieid { get; set; }
        public int Memberid { get; set; }
        public string Username { get; set; }
        [Display(Name ="Movie Name")]
        [Required(ErrorMessage ="Please Enter Movie Name")]
        public string Moviename { get; set; }
        [Display(Name ="Movie Image")]
        [Required(ErrorMessage ="Please Enter Movie Image")]
        public string Movieimage { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please Enter Genre")]
        public string Genre { get; set; }
        [Display(Name = "Language")]
        [Required(ErrorMessage = "Please Enter Language")]
        public string Language { get; set; }
        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Please Enter Release Date")]
        public System.DateTime Releasedate { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }
        public System.DateTime Createdon { get; set; }
        public string Createdby { get; set; }
        public System.DateTime Updatedon { get; set; }
        public string Updatedby { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }


    public class MovieDetails
    {
        public int Movieid { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Name")]
        public string Moviename { get; set; }
      
        public string ImageUrl { get; set; }

        public int Memberid { get; set; }

        public string Username { get; set; }

        public string Movieimage { get; set; }
        [Required(ErrorMessage = "Please Enter Genre")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Please Enter Language")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Please Enter Release Date")]
        public System.DateTime Releasedate { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Price")]
        public int Price { get; set; }

        public System.DateTime Createdon { get; set; }
        public string Createdby { get; set; }
        public System.DateTime Updatedon { get; set; }
        public string Updatedby { get; set; }

        [Required(ErrorMessage = "Please Enter Movie image")]
        public HttpPostedFileBase File { get; set; }

    }
    public class MovieListObject
    {
        public string Moviename { get; set; }
        public string Movieimage { get; set; }
        public string ImageUrl { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }
       
        public System.DateTime Releasedate { get; set; }

        public string Description { get; set; }
   
        public int Price { get; set; }


    }

}
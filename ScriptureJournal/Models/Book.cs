using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal.Models
{
   public class Book
   {
      public int ID { get; set; }
      public string Title { get; set; }


      [Display(Name = "Read Date")]
      [DataType(DataType.Date)]
           
      public DateTime ReleaseDate { get; set; }

      [Display(Name = "Chapter . Verse")]
      public decimal Price { get; set; }

      [Display(Name = "Book")]
      public string Genre { get; set; }

      public string Notes { get; set; }
     
   }
}

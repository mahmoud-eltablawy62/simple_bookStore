
using System.ComponentModel.DataAnnotations.Schema;


namespace Repository_Pattern.core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Tittle { get; set; }

        [ForeignKey("Authors")]
        public int Auth_Id { get; set; }     
      public Author  Authors { get; set; }
    }
}

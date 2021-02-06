using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        //virtual list of comments
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();


        //Guid Author(using user ID)??
        public Guid Author { get; set; }
        
        //should probably add some range, max length and error message to properties
    }
}

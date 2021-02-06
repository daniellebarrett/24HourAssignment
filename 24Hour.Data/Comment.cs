using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey(nameof(Post))]
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        // virtual list of replies
        public virtual List<string> Replies { get; set; } = new List<string>();

        [Required]
        //Guid Author(using user ID)??
        public Guid Author { get; set; }

        // also need a Reply --> separate class OR can inherit from Comment - your choice

        //should probably add some range, max length and error message to properties
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public virtual List<string> Replies { get; set; } = new List<string>();
        public int PostId { get; set; }
    }
}

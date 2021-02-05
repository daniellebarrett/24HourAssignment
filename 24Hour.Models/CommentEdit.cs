using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    class CommentEdit
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public virtual List<string> Replies { get; set; } = new List<string>();
    }
}

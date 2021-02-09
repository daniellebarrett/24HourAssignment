using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }
        

        // add range and max length here
        public string Text { get; set; }
    }
}

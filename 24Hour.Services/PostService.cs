using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class PostService
    {
        
       
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    
                    Title = model.Title,
                    Text = model.Text,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
       

        //This is a random change...
    }
}

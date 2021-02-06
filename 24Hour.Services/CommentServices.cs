using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class CommentServices
    {

        private readonly Guid _userId;

        public CommentServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    Id = model.Id
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == id);
                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.Id == model.Id && e.Author == _userId);

                    entity.PostId = model.PostId;
                entity.Text = model.Text;
                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Comments
                    .Single(e => e.Id == commentId && e.Author == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.Author== _userId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            Id = e.Id,
                            Text = e.Text,
                        }
                        
                        );
                return query.ToArray();
            }
        }
    }
}

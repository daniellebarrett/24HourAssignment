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
                    CommentId = model.CommentId,
                    Author = _userId
                    
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
                    .Single(e => e.CommentId == id);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
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
                    .Single(e => e.CommentId == model.CommentId && e.Author == _userId);

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
                    .Single(e => e.CommentId == commentId && e.Author == _userId);
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
                            CommentId = e.CommentId,
                            Text = e.Text
                        }
                        
                        );
                return query.ToArray();
            }
        }
    }
}

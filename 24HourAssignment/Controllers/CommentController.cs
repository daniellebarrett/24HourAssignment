using System.Web.Http;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using _24Hour.Services;
using _24Hour.Models;

namespace _24HourAssignment.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            CommentServices commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);

        }

        public IHttpActionResult Get(int id)
        {
            CommentServices commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok(comment);

        }



        public IHttpActionResult Put(CommentEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(note))
                return InternalServerError();

            return Ok();
        }


        //Delete METHOD 

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
        private CommentServices CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentServices(userId);
            return commentService;
        }
    }


}

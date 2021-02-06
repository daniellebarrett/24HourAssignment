using  System.Web.Http;
using  Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourAssignment.Controllers
{
    public class CommentController : ApiController
    
    {
        [Authorize]
        public class CommentController : ApiController
        {
            private CommentServices CreateCommentService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var commentService = new CommentServices(userId);
                return commentService;
            }
        }


        public IHttpActionResult Get()
        {
            CommentServices commentService = CreateCommentServices();
            var notes = commentService.GetComment();
            return Ok(notes);

        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentServices();

            if (!service.CreateNote(comment))
                return InternalServerError();

            return Ok();
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

            if (!service.UpdateNote(note))
                return InternalServerError();

            return Ok();
        }


        //Delete METHOD 

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteNote(id))
                return InternalServerError();

            return Ok();
        }

    }


}

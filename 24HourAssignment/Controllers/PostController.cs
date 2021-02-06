using _24Hour.Services;
using System.Web.Http;
<<<<<<< HEAD
using  _24Hour.Models;
=======
using using System;
using Microsoft.AspNet.Identity;

24Hour.Models;
>>>>>>> 728b53559d5b13970c94c034fd001be2492128e5
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace _24HourAssignment.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }


        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

    }
}

using _24Hour.Services;
using System.Web.Http;
using _24Hour.Models;
using System;
using Microsoft.AspNet.Identity;
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
            var postId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(postId);
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

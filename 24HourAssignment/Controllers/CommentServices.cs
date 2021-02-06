using System;

namespace _24HourAssignment.Controllers
{
    internal class CommentServices
    {
        private Guid userId;

        public CommentServices(Guid userId)
        {
            this.userId = userId;
        }
    }
}
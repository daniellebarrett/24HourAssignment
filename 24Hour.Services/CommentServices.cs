using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    class CommentServices
    {

        private readonly Guid _userId;
        public CommentServices(Guid userId)
        {
            _userId = userId;
        }

    }
}

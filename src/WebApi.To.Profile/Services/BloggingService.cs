using System.Collections.Generic;

using WebApi.To.Profile.Data;

namespace WebApi.To.Profile.Services
{
    public class BloggingService : IBloggingService
    {
        private readonly BloggingContext _context;
        public BloggingService(BloggingContext context)
        {
            _context = context;
        }
        public IEnumerable<Blog> GetBlogs()
        {
            return _context.Blogs;
        }
    }
}

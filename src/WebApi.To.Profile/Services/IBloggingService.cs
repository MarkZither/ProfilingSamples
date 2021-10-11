using System.Collections.Generic;

using WebApi.To.Profile.Data;

namespace WebApi.To.Profile.Services
{
    public interface IBloggingService
    {
        IEnumerable<Blog> GetBlogs();
    }
}
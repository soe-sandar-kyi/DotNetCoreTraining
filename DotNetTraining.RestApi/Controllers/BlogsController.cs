using DotNetCoreTraining.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetTraining.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _context = new AppDbContext();


        // GET: api/Blogs
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<Blog>? blogList = _context.Blogs.AsNoTracking().Where(blog => blog.DeleteFlag == false).ToList();
            return Ok(blogList);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            Blog? item = _context.Blogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, Blog blog)
        {
            Blog? item = _context.Blogs.AsNoTracking().FirstOrDefault(blog => blog.BlogId == id);
            if (item is null)
            {
                return NotFound();
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(item);
        }

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return Ok(blog);
        }

        //PATCH: api/Blogs/id
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, Blog blog)
        {
            Blog? item = _context.Blogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            if (item is null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogTitle = blog.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogTitle = blog.BlogContent;
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(item);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            Blog? item = _context.Blogs.AsNoTracking().FirstOrDefault(b => b.BlogId == id);
            if (item is null)
            {
                return NotFound();
            }
            item.DeleteFlag = true;

            //_context.Entry(item).State = EntityState.Deleted;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(item);
        }

        private bool BlogExists(int id)
        {
            return (_context.Blogs?.Any(e => e.BlogId == id)).GetValueOrDefault();
        }
    }
}

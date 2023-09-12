using CRUD.Data;
using CRUD.Models.Blog;
using CRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class AdminController : Controller
    {
        private readonly CrudDbContext crudDbContext;

        public AdminController(CrudDbContext crudDbContext)
        {
            this.crudDbContext = crudDbContext;
        }

        [HttpGet]
        public IActionResult AddTags()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddTags")]
        public IActionResult AddTags(AddTagRequest addTagRequest)
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

            crudDbContext.Tags.Add(tag);
            crudDbContext.SaveChanges();
            return View("AddTags");
        }

        [HttpGet]
        public IActionResult AddBlogs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBlogs(AddBlogRequest addBlogRequest)
        {
            var blog = new BlogPost
            {
                Heading = addBlogRequest.Heading,
                PageTitle = addBlogRequest.PageTitle,
                Content = addBlogRequest.Content,
                ShortDescription = addBlogRequest.ShortDescription,
                FeaturedImageUrl = addBlogRequest.FeaturedImageUrl,
                UrlHandle = addBlogRequest.UrlHandle,
                Author = addBlogRequest.Author,
                Visible = addBlogRequest.Visible,
            };

            crudDbContext.BlogPosts.Add(blog);
            crudDbContext.SaveChanges();

            return View();
        }
    }
}


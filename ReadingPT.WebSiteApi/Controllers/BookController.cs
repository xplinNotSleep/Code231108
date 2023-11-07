using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadingPT.BusinessService.Interface;
using ReadingPT.DataAccess;
using ReadingPT.Models;
using ReadingPT.WebSiteApi.Controllers.test;
using ReadingPT.WebSiteApi.testDemo;
using ReadingPT.WebSiteApi.Utility.SwaggerExt;

namespace ReadingPT.WebSiteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = nameof(ApiVersions.V3))]
    public class BookControllerV3 : ControllerBase
    {
        private readonly ILogger<BookControllerV3> _Logger;
        private readonly DbContext _Context;
        private readonly IBookService _BookService;

        public BookControllerV3(ILogger<BookControllerV3> logger, DbContext context, IBookService bookService)
        {
            _Logger = logger;
            _Context = context;
            _BookService = bookService;
        }

        [HttpGet(Name = "BookControllerV3")]
        public void Get()
        {
            _BookService.Add();
            _BookService.Update();
            _BookService.Query();
            _BookService.Delete();

            //在数据库中添加对象
            _Context.Set<BookEntityInfo>().Add(new BookEntityInfo()
            {
                Name = "李白诗词集",
                Author = "李白",
                BookCode = "Book11071101",
                BannerUrl = "url0",
                BookCategory = 0,
                Description = "十分经典的古诗词读本",
                IsCharge = true,

            });
            _Context.SaveChanges();

            //修改对象
            BookEntityInfo book0 = _Context.Set<BookEntityInfo>().OrderByDescending(c =>
            c.Id).FirstOrDefault();

            book0.Name = book0.Name + "20231107";
            _Context.SaveChanges();

            //移除对象
            _Context.Set<BookEntityInfo>().Remove(book0);
            _Context.SaveChanges();


        }


    }
}

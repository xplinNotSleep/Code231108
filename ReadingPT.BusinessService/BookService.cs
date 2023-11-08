using Microsoft.EntityFrameworkCore;
using ReadingPT.BusinessService.Interface;

namespace ReadingPT.BusinessService
{
    public class BookService : BaseService, IBookService
    {
        public BookService(DbContext context) : base(context)
        {

        }
    }
}
// See https://aka.ms/new-console-template for more information
using ReadingPT.DataAccess;
using ReadingPT.Models;

Console.WriteLine("Hello, World!");

using (ReadingDbContext context = new ReadingDbContext())
{
    context.Database.EnsureCreated();//自动新建数据库
    //context.Database.EnsureDeleted();//自动删除数据库

    //在数据库中添加对象
    context.BookEntityInfos.Add(new BookEntityInfo()
    {
        Name="李白诗词集",
        Author="李白",
        BookCode="Book11071101",
        BannerUrl="url0",
        BookCategory=0,
        Description="十分经典的古诗词读本",
        IsCharge=true,

    });
    context.SaveChanges();

    //修改对象
    BookEntityInfo book0 = context.BookEntityInfos.OrderByDescending(c =>
    c.Id).FirstOrDefault();

    book0.Name = book0.Name + "20231107";
    context.SaveChanges();

    //移除对象
    context.BookEntityInfos.Remove(book0);
    context.SaveChanges();

}

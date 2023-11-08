using Microsoft.EntityFrameworkCore;
using ReadingPT.BusinessService.Interface;
using System.Linq.Expressions;

namespace ReadingPT.BusinessService
{
    public abstract class BaseService: IBaseService
    {
        protected DbContext Context { get; set; }

        public BaseService(DbContext context)
        {
            Context = context;
        }

        #region Query
        /// <summary>
        /// 基于主键的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }

        /// <summary>
        /// 提供对单表的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        /// <summary>
        /// 常规查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return Context.Set<T>().Where(funcWhere);
        }
        #endregion

        #region Add
        /// <summary>
        /// 新增数据,即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Insert<T>(T t) where T : class
        {
            Context.Set<T>().Add(t);
            Commit();
            return t;
        }

        /// <summary>
        /// 新增数据并立即执行Commit
        /// 多条sql执行一次连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            Context.Set<T>().AddRange(tList);
            Commit();
            return tList;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新单条数据,即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");

            Context.Set<T>().Attach(t);
            Context.Entry(t).State = EntityState.Modified;
            Commit();
        }

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach(var t in tList)
            {
                Context.Set<T>().Attach(t);
                Context.Entry(t).State = EntityState.Modified;
            }
            Commit();
        }
        #endregion

        #region Delete
        /// <summary>
        /// 根据主键id删除某个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        public void Delete<T>(int Id) where T : class
        {
            T t = Find<T>(Id);
            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Attach(t);
            Context.Set<T>().Remove(t);
            Commit();
        }

        /// <summary>
        /// 删除某个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            Context.Set<T>().Attach(t);
            Context.Set<T>().Remove(t);
            Commit();
        }

        /// <summary>
        /// 删除多个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                Context.Set<T>().Attach(t);
            }
            Context.Set<T>().RemoveRange(tList);
            Commit();
        }

        #endregion

        #region other
        /// <summary>
        /// 保存全部修改
        /// </summary>
        public void Commit()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// 执行sql,返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IQueryable<T> ExcuteQuery<T>(string sql) where T : class
        {
            return null;
        }

        /// <summary>
        /// 执行sql,无返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        public void Excute<T>(string sql) where T : class
        {
            

        }

        #endregion

        #region 分页
        public PagingData<T> QueryPage<T,S>(Expression<Func<T,bool>> funcWhere, int pageSize,
            int pageIndex, Expression<Func<T,S>> funcOrderby, bool isAsc=true) where T:class
        {
            var list = Set<T>();
            if(funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if(isAsc)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }
            PagingData<T> result = new PagingData<T>()
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = list.Count()
            };
            return result;
        }
        #endregion

    }
}
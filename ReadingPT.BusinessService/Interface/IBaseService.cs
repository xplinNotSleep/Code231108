using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadingPT.BusinessService.Interface
{
    public interface IBaseService
    {
        #region Query
        /// <summary>
        /// 基于主键的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;

        /// <summary>
        /// 提供对单表的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> Set<T>() where T : class;

        /// <summary>
        /// 常规查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;
        #endregion

        #region Add
        /// <summary>
        /// 新增数据,即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        /// 新增数据并立即执行Commit
        /// 多条sql执行一次连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Update
        /// <summary>
        /// 更新单条数据,即时Commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T>(T t) where T : class;

        /// <summary>
        /// 更新多条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Update<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region Delete
        /// <summary>
        /// 根据主键删除记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        void Delete<T>(int Id) where T : class;

        /// <summary>
        /// 删除某个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : class;

        /// <summary>
        /// 删除多个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region other
        /// <summary>
        /// 保存全部修改
        /// </summary>
        void Commit();

        /// <summary>
        /// 执行sql,返回集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        IQueryable<T> ExcuteQuery<T>(string sql) where T : class;

        /// <summary>
        /// 执行sql,无返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        void Excute<T>(string sql) where T : class;

        #endregion

        #region 多余
        //public void Add();

        //public void Update();

        //public void Query();

        //public void Delete();
        #endregion
    }
}

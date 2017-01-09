using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterfaceDataLibrary
{
    ///<summary>
    ///扩展接口，主要用于执行Sql语句
    /// </summary> 
    /// 
    interface InterfaceExpandRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 过程分页
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <param name="fields">分布自增ID</param>
        /// <param name="byOrder">排序字段</param>
        /// <param name="page">返回页数</param>
        /// <param name="pageSize">面大小</param>
        /// <returns></returns>
        //   ModelPage<TEntity> GetListByPage(Expression<Func<TEntity, bool>> strWhere, string fields, string byOrder, int page, int pageSize);


    }
}

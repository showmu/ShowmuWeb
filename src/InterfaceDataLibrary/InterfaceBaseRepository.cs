using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InterfaceDataLibrary
{
    public interface InterfaceBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 数据实体列表
        /// </summary>
        IQueryable<TEntity> Entities { get; }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>添加后的数据实体</returns>
        TEntity Add(TEntity entity, bool isSave = true);

        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Update(TEntity entity, bool isSave = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Delete(TEntity entity, bool isSave = true);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<TEntity, bool>> anyLambda);

    

        /// <summary>
        /// 查询数据【请优先使用Find(Guid id)】
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        TEntity Find(Expression<Func<TEntity, bool>> whereLambda);

        /// <summary>
        /// 返回满足条件的结果集
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns></returns>
        IQueryable<TEntity> LoadEntities(Func<TEntity, bool> wherelambda);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>影响的记录数目</returns>
        int Save();
  /// <summary>
        /// LinQ 分页
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="total">总页数</param>
        /// <param name="whereLambda">条件</param>
        /// <param name="isAsc">是否排序</param>
        /// <param name="orderByLambda">排序条件</param>
        /// <returns></returns>
        /// 
        IQueryable<TEntity> LoadPagerEntities<TS>(int pageSize, int pageIndex, out int total,
            Func<TEntity, bool> whereLambda, bool isAsc, Func<TEntity, TS> orderByLambda);
    }
}

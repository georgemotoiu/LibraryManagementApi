using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Application.Contracts.Repositories
{
    public interface IBaseRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        /// <summary>
        ///     Asynchronous get an Entity by the Id and convert it it to TModel using AutoMapper
        /// </summary>
        /// <param name="id">the id</param>
        /// <returns>TModel object with given id</returns>
        Task<TModel> GetByIdAsync(Guid id);


        /// <summary>
        ///     Asynchronous get an Entity by Id and convert it to TModel using AutoMapper and remove tracking.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetByIdWithNoTrackingAsync(Guid id);

        /// <summary>
        ///     Get the entities of TEntity type async
        /// </summary>
        /// <returns>IEnumerable of TModel objects asynchronously</returns>
        Task<IEnumerable<TModel>> GetAllAsync();

        /// <summary>
        ///     Asynchronous get the entities from db with its related data            
        ///     Convert them to TModel type using AutoMapper
        /// <param name="includeProperties">comma-delimited list of navigation properties for eager loading</param>
        /// <returns>IEnumerable of TModel objects</returns>
        Task<IEnumerable<TModel>> GetAsync
            (Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "");

        /// <summary>
        ///     Asynchronous Insert the given entity
        /// </summary>
        /// <param name="entity">given entity of TModel type</param>
        /// <returns>TEntity object that was added to DB</returns>
        Task<TEntity> AddAsync(TModel model);

        /// <summary>
        ///     Asynchronous Update the given entity in the DB
        /// </summary>
        /// <param name="entity">the entity of TModel type to update</param>
        /// <returns>TEntity object that was updated</returns>
        Task<TEntity> UpdateAsync(TModel model);

        /// <summary>
        ///     Asynchronous Delete the given entity from the DB
        /// </summary>
        /// <param name="entity">the entity of TModel type to Delete</param>
        Task DeleteAsync(TModel model);

        /// <summary>
        ///     Asynchronous gets the given entities paginated
        /// </summary>
        /// <param name="page">the page number</param>
        /// <param name="size">the page size</param>
        Task<IEnumerable<TEntity>> GetPagedReponseAsync(int page, int size);
    }
}

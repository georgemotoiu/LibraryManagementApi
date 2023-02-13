using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Library.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.Repositories
{
    public class BaseRepository<TEntity, TModel> : IBaseRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        internal LibraryDbContext _context;
        internal DbSet<TEntity> _dbSet;
        internal IMapper _mapper;

        public BaseRepository(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var entity = _mapper.Map<TEntity>(model);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var entity = _mapper.Map<TEntity>(model);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = _dbSet.AsQueryable();

            return await entities.ProjectTo<TModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetAsync
            (Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                         (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.ProjectTo<TModel>(_mapper.ConfigurationProvider).ToListAsync();
        }


        public async Task<TModel> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            return _mapper.Map<TModel>(entity);
        }        

        public async Task<TModel> GetByIdWithNoTrackingAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }

            return _mapper.Map<TModel>(entity);
        }

        public async Task<IEnumerable<TEntity>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbSet.Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var entity = _mapper.Map<TEntity>(model);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();            

            return entity;
        }
    }
}

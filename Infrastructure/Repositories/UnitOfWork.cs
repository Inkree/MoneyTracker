//using Core.interfaces;
//using Infrastructure.Data;


//namespace Infrastructure.Repositories
//{
//    public class UnitOfWork : IUnitOfWork
//    {
//        protected readonly MoneyTrackerDbContext _dbContext;
//        private readonly IDictionary<Type, dynamic> _repositories;
//        public UnitOfWork(MoneyTrackerDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IGenericRepository<T> Repository<T>() where T : class
//        {
//            var entityType = typeof(T);

//            if (_repositories.ContainsKey(entityType))
//            {
//                return _repositories[entityType];
//            }

//            var repositoryType = typeof(GenericRepository<>);

//            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

//            if (repository == null)
//            {
//                throw new NullReferenceException("Repository should not be null");
//            }

//            _repositories.Add(entityType, repository);

//            return (IGenericRepository<T>)repository;
//        }

        

//        public async Task RollBackChangesAsync()
//        {
//            await _dbContext.Database.RollbackTransactionAsync();
//        }

//        public async Task<int> SaveChangesAsync()
//        {
//            return await _dbContext.SaveChangesAsync();
//        }
//    }
//}

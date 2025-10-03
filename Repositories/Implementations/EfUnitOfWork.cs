using Microsoft.EntityFrameworkCore.Storage;
using quizweb.Data;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IQuestionSetRepository _qsRepo;
        private readonly IQuestionRepository _qRepo;
        private readonly IAnswerRepository _aRepo;

        private IDbContextTransaction? _tx;

        public EfUnitOfWork(AppDbContext context, IQuestionSetRepository qsRepo, IQuestionRepository qRepo, IAnswerRepository aRepo)
        {
            _context = context;
            _qsRepo = qsRepo;
            _qRepo = qRepo;
            _aRepo = aRepo;
        }

        public IQuestionSetRepository QuestionSetRepository => throw new NotImplementedException();

        public IQuestionRepository QuestionRepository => throw new NotImplementedException();

        public IAnswerRepository AnswerRepository => throw new NotImplementedException();

        public async Task BeginTransactionAsync()
        {
            if (_tx == null)
            {
                _tx = await _context.Database.BeginTransactionAsync();
            }
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

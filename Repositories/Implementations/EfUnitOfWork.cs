using Microsoft.EntityFrameworkCore.Storage;
using quizweb.Data;
using quizweb.Models;
using quizweb.Repositories.Interfaces;

namespace quizweb.Repositories.Implementations
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        private readonly IQuestionSetRepository _qsRepo;
        private readonly IQuestionRepository _qRepo;
        private readonly IAnswerRepository _aRepo;

        private bool _disposed;

        public EfUnitOfWork(AppDbContext context, IQuestionSetRepository qsRepo, IQuestionRepository qRepo, IAnswerRepository aRepo)
        {
            _context = context;
            _qsRepo = qsRepo;
            _qRepo = qRepo;
            _aRepo = aRepo;
        }

        public IQuestionSetRepository QuestionSetRepository => _qsRepo;

        public IQuestionRepository QuestionRepository => _qRepo;

        public IAnswerRepository AnswerRepository => _aRepo;


        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                return;
            }
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("The transaction has not been initiated yet.");
            }

            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }

                await _context.DisposeAsync();
                _disposed = true;
            }

            GC.SuppressFinalize(this);
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using quizweb.Models;
namespace quizweb.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<AnsweredQuestion> AnsweredQuestions { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<CreatedQuestionSet> CreatedQuestionSets { get; set; } = null!;
        public DbSet<Level> Levels { get; set; } = null!;
        public DbSet<MarkedQuestion> MarkedQuestions { get; set; } = null!;
        public DbSet<ProgressQuestionSet> ProgressQuestionSets { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<QuestionSet> QuestionSets { get; set; } = null!;
        public DbSet<Ranking> Rankings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Answer>(e =>
            {
                e.HasKey(e => e.AnswerId);
                e.Property(e => e.AnswerText)
                    .IsRequired()
                    .HasMaxLength(500);

                e.HasOne(e => e.Question)
                    .WithMany(q => q.Answers)
                    .HasForeignKey(e => e.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
               
        }
    }
}

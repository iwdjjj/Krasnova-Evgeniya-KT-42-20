using KrasnovaEV_KT_42_20.Database;
using KrasnovaEV_KT_42_20.Filters.SubjectFilters;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace KrasnovaEV_KT_42_20.Interfaces
{
    public interface ISubjectService
    {
        public Task<Subject[]> GetSubjectsByDescriptionAsync(SubjectDescriptionFilter filter, CancellationToken cancellationToken);
        public Task<Subject[]> GetSubjectsByIsDeletedAsync(SubjectIsDeletedFilter filter, CancellationToken cancellationToken);
    }

    public class SubjectService : ISubjectService
    {
        private readonly StudentDbContext _dbContext;
        public SubjectService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Subject[]> GetSubjectsByDescriptionAsync(SubjectDescriptionFilter filter, CancellationToken cancellationToken = default)
        {
            var subjects = _dbContext.Set<Subject>().Where(w => w.SubjectDescription == filter.SubjectDescription).Where(w => w.IsDeleted == filter.SubjectIsDeleted).ToArrayAsync(cancellationToken);

            return subjects;
        }
        public Task<Subject[]> GetSubjectsByIsDeletedAsync(SubjectIsDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var subjects = _dbContext.Set<Subject>().Where(w => w.IsDeleted == filter.SubjectIsDeleted).ToArrayAsync(cancellationToken);

            return subjects;
        }
    }
}

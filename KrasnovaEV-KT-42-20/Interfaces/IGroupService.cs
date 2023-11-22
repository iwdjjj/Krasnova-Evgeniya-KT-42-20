using KrasnovaEV_KT_42_20.Database;
using KrasnovaEV_KT_42_20.Filters.GroupFilters;
using KrasnovaEV_KT_42_20.Filters.SubjectFilters;
using KrasnovaEV_KT_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace KrasnovaEV_KT_42_20.Interfaces
{
    public interface IGroupService
    {
        public Task<Group[]> GetGroupsByJobAsync(GroupJobFilter filter, CancellationToken cancellationToken);
        public Task<Group[]> GetGroupsByYearAsync(GroupYearFilter filter, CancellationToken cancellationToken);
        public Task<Group[]> GetGroupsByIsDeletedAsync(GroupIsDeletedFilter filter, CancellationToken cancellationToken);
    }

    public class GroupService : IGroupService
    {
        private readonly StudentDbContext _dbContext;
        public GroupService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Group[]> GetGroupsByJobAsync(GroupJobFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Group>().Where(w => w.GroupJob == filter.GroupJob).Where(w => w.IsDeleted == filter.GroupIsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Group[]> GetGroupsByYearAsync(GroupYearFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Group>().Where(w => w.GroupYear == filter.GroupYear).Where(w => w.IsDeleted == filter.GroupIsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
        public Task<Group[]> GetGroupsByIsDeletedAsync(GroupIsDeletedFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Group>().Where(w => w.IsDeleted == filter.GroupIsDeleted).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}

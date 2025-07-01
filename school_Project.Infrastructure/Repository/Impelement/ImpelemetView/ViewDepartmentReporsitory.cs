using Microsoft.EntityFrameworkCore;
using school_Project.Data.Entities.Views;
using school_Project.Infrastructure.Base;
using school_Project.Infrastructure.Data;
using school_Project.Infrastructure.Repository.Abstract.AbstractView;

namespace school_Project.Infrastructure.Repository.Impelement.ImpelemetView
{
    public class ViewDepartmentReporsitory : GenericRepositoryAsync<ViewDepartment>, IViewReporsitory<ViewDepartment>
    {
        #region Field
        private readonly DbSet<ViewDepartment> _viewdepartment;
        #endregion
        #region Constructor DB
        public ViewDepartmentReporsitory(ApplicationDbContext dbContext) : base(dbContext)
        {
            _viewdepartment = dbContext.Set<ViewDepartment>();
        }
        #endregion
    }
}

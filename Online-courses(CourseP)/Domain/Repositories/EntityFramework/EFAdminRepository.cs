using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.Data.Entity;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFAdminRepository : IAdminRepository
    {
        private readonly SchoolDbContext context;
        public EFAdminRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Admin> GetList()
        {
            return context.Admins;
        }
        public Admin GetByID(string id)
        {
            return context.Admins.FirstOrDefault(admin => admin.Id == id);
        }

        public void Save(Admin entity)
        {
            if (!IsExistAdmin(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(string id) 
        {
            context.Admins.Remove(new Admin { Id = id });
            context.SaveChanges();
        }

        public bool IsExistAdmin(string id)
        {
            return context.Admins.Any(admin => admin.Id == id);
        }
    }
}

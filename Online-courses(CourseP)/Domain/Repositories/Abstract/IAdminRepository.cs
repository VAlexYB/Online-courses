using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface IAdminRepository
    {
        public IQueryable<Admin> GetList();
        public Admin GetByID(string id);
        public void Save(Admin entity);
        public void Delete(string id);
        public bool IsExistAdmin(string id);
    }
}

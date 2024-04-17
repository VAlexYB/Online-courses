using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface IStudentRepository
    {
        public IQueryable<Student> GetList();
        public Student GetByID(string id);
        public void Save(Student entity);
        public void Delete(string id);
        public bool IsExistStudent(string id);
        public List<SelectListItem> GetSelectListItems();
        public IQueryable<Student> GetPagedStudentsAsync(int page, int pageSize);
        public bool AddToAffiliation(Student student, Group group);
        public int GetCount();
    }
}

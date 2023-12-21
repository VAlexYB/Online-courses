using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface IGroupRepository
    {
        public IQueryable<Group> GetList();
        public Group GetByID(int id);
        public void Save(Group entity);
        public void Delete(int id);
        public bool IsExistGroup(int id);
        public List<SelectListItem> GetSelectListItems();
    }
}

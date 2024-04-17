using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.Drawing.Printing;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ITutorRepository
    {
        public IQueryable<Tutor> GetList();
        public Tutor GetByID(string id);
        public void Save(Tutor entity);
        public void Delete(string id);
        public bool IsExistTutor(string id);
        public IQueryable<Tutor> GetPagedTutorsAsync(int page, int pageSize);
        public int GetCount();
    }
}

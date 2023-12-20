using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Models;

namespace Online_courses_CourseP_.Areas.Admin.Views.Components
{
    public class TeachersViewComponent : ViewComponent
    {
        private readonly ITeacherRepository teacherRepository;
        public TeachersViewComponent(ITeacherRepository tutorRepository)
        {
            this.teacherRepository = tutorRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 3)
        {
            var teachers = teacherRepository.GetPagedTeachersAsync(page, pageSize);
            var totalCount = teacherRepository.GetCount();
            var pageViewModel = new PageViewModel(totalCount, page, pageSize);

            return View(new Tuple<IEnumerable<Teacher>, PageViewModel>(teachers, pageViewModel));
        }
    }
}

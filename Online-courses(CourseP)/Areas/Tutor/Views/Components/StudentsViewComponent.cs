using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Models;

namespace Online_courses_CourseP_.Areas.Tutor.Views.Components
{
    public class StudentsViewComponent : ViewComponent
    {
        private readonly IStudentRepository studentRepository;
        public StudentsViewComponent(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 3)
        {
            var students = studentRepository.GetPagedStudentsAsync(page, pageSize);
            var totalCount = studentRepository.GetCount();
            var pageViewModel = new PageViewModel(totalCount, page, pageSize);

            return View(new Tuple<IEnumerable<Student>, PageViewModel>(students, pageViewModel));
        }
    }
}

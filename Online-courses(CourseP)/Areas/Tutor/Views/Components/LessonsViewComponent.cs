using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Models;

namespace Online_courses_CourseP_.Areas.Tutor.Views.Components
{
    public class LessonsViewComponent : ViewComponent
    {
        private readonly ILessonRepository lessonRepository;
        public LessonsViewComponent(ILessonRepository lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 3)
        {
            var lessons = lessonRepository.GetPagedLessonsAsync(page, pageSize);
            var totalCount = lessonRepository.GetCount();
            var pageViewModel = new PageViewModel(totalCount, page, pageSize);

            return View(new Tuple<IEnumerable<Lesson>, PageViewModel>(lessons, pageViewModel));
        }
    }
}

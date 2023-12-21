using Microsoft.AspNetCore.Mvc;
using MyCompany.Domain;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Models;

namespace Online_courses_CourseP_.Areas.Admin.Views.Components
{
    public class TutorsViewComponent : ViewComponent
    {
        private readonly ITutorRepository tutorRepository;
        public TutorsViewComponent(ITutorRepository tutorRepository)
        {
            this.tutorRepository = tutorRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int pageSize = 3)
        {
            var tutors = tutorRepository.GetPagedTutorsAsync(page, pageSize);
            var totalCount = tutorRepository.GetCount();
            var pageViewModel = new PageViewModel(totalCount, page, pageSize);

            return View(new Tuple<IEnumerable<Domain.SchoolEntities.Tutor>, PageViewModel>(tutors, pageViewModel));
        }

    }
}

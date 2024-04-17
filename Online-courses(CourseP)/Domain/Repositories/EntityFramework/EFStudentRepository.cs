using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext context;
        public EFStudentRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Delete(string id)
        {
            context.Students.Remove(new Student { Id = id });
            context.SaveChanges();
        }

        public Student GetByID(string id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Student> GetList()
        {
            return context.Students;
        }

        public bool IsExistStudent(string id)
        {
            return context.Students.Any(x => x.Id == id);
        }

        public void Save(Student entity)
        {
            if (!IsExistStudent(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return context.Students.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = $"{s.Surname} {s.Name} {s.Patronymic}" }).ToList();
        }

        public IQueryable<Student> GetPagedStudentsAsync(int page, int pageSize)
        {
            return context.Students.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public int GetCount()
        {
            return context.Students.Count();
        }

        public bool AddToAffiliation(Student student, Group group)
        {
            if (!context.Students.Any(s => s.Id == student.Id) || !context.Groups.Any(g => g.Id == group.Id))
                return false;

            if (context.AffiliationAgreements.Any(aa => aa.StudentId == student.Id && aa.GroupId == group.Id))
                return false;

            var affiliation = new AffiliationAgreement
            {
                StudentId = student.Id,
                GroupId = group.Id,
                Student = student,
                Group = group
            };

            context.AffiliationAgreements.Add(affiliation);
            context.SaveChanges();
            return true;
        }
    }
}

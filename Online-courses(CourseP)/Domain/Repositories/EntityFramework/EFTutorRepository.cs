﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFTutorRepository : ITutorRepository
    {
        private readonly SchoolDbContext context;
        public EFTutorRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Delete(string id)
        {
            context.Tutors.Remove(new Tutor { Id = id});
            context.SaveChanges();
        }

        public Tutor GetByID(string id)
        {
            return context.Tutors.FirstOrDefault(t => t.Id == id);
        }

        public int GetCount()
        {
            return context.Tutors.Count();
        }

        public IQueryable<Tutor> GetList()
        {
            return context.Tutors;
        }

        public IQueryable<Tutor> GetPagedTutorsAsync(int page, int pageSize)
        {
            return context.Tutors.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public bool IsExistTutor(string id)
        {
            return context.Tutors.Any(t => t.Id == id);
        }

        public void Save(Tutor entity)
        {
            if (!IsExistTutor(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

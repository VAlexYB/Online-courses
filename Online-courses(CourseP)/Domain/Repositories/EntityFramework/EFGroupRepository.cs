﻿using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFGroupRepository : IGroupRepository
    {
        private readonly SchoolDbContext context;
        public EFGroupRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Groups.Remove(new Group { Id = id });
        }

        public Group GetByID(int id)
        {
            return context.Groups.FirstOrDefault(group => group.Id == id);
        }

        public IQueryable<Group> GetList()
        {
            return context.Groups;
        }

        public bool IsExistGroup(int id)
        {
            return context.Groups.Any(group => group.Id == id);
        }

        public void Save(Group entity)
        {
            if (!IsExistGroup(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Runtime.CompilerServices;

namespace Online_courses_CourseP_.Service
{
    public class UserAreaAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public UserAreaAuthorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if(controller.Attributes.Any(attribute => attribute is AreaAttribute && 
            (attribute as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase))
                || controller.RouteValues.Any(route => route.Key.Equals("area", StringComparison.OrdinalIgnoreCase)
                && route.Value.Equals(area, StringComparison.OrdinalIgnoreCase)))
            {
                controller.Filters.Add(new AuthorizeFilter(policy)); 
            }
        }
    }
}

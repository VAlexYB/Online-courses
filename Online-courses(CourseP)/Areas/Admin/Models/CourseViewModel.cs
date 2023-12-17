using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.ComponentModel.DataAnnotations;

namespace Online_courses_CourseP_.Areas.Admin.Models
{
    public class CourseViewModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        
        [Display(Name = "Умение")]
        public string Skill { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Дата начала")]
        public DateTime? Duration { get; set; }

        [Display(Name = "Id категории")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        [Display(Name = "Id уровня навыка")]
        public int SkillLevelId { get; set; }

        public List<SelectListItem> SkillLevels { get; set; }
    }
}

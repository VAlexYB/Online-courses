using Microsoft.AspNetCore.Identity;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Student : Client
{
    [NotMapped]
    public string Password { get; set; }
    public virtual ICollection<AffiliationAgreement> AffiliationAgreements { get; set; } = new List<AffiliationAgreement>();
}

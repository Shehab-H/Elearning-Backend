using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public enum UserType
    {
        [Display(Name = "Student")]

        Student = 0,

        [Display(Name = "Teacher")]
        Teacher = 1,
    }
}

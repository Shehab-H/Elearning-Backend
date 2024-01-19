using Core.Entities.Shared;
using Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Course
{
    public class CourseEnrollments : Entity
    {
        public ElearningUser EnrolledStudent { get; private set; }

        public DateTime EnrollmentDate { get; set; }

        private CourseEnrollments() : base(Guid.NewGuid())
        { }
        public CourseEnrollments(DateTime enrollmentDate, ElearningUser enrolledStudent) : base(Guid.NewGuid())
        {
            EnrollmentDate = enrollmentDate;
            EnrolledStudent = enrolledStudent;
        }
    }
}

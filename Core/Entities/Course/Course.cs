using Core.Entities.Shared;
using Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Course
{
    public class Course : Entity
    {
        public string Name { get; private set; }

        private ICollection<CourseEnrollments> _courseEnrollments;
        public IReadOnlyCollection<CourseEnrollments> CourseEnrollments => _courseEnrollments.ToList();


        private ICollection<CourseCategory> _courseCategories;
        public IReadOnlyCollection<CourseCategory> CourseCategories => _courseCategories.ToList();

        private Course() : base(Guid.NewGuid())
        { }
        public Course(string name ,
            ICollection<CourseEnrollments> courseEnrollments ,
            ICollection<CourseCategory> courseCategories

            ) : base(Guid.NewGuid())
        {
            Name = name;
            _courseEnrollments = courseEnrollments;
            _courseCategories = courseCategories;
        }


    }
}

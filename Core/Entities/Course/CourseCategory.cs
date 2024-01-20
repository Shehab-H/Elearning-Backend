using Core.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Course
{
    public class CourseCategory : Entity
    {
        public string Name { get;private set; }

        public CourseCategory ParentCategory { get; private set; }


        private CourseCategory() : base(Guid.NewGuid())
        { }
        public CourseCategory(string name, CourseCategory  parentCategory) : base(Guid.NewGuid())
        {
            Name = name;
            ParentCategory = parentCategory;
        }

        public void RemoveParent()
        {
            ParentCategory = ParentCategory.ParentCategory ?? null;
        }
    }
}

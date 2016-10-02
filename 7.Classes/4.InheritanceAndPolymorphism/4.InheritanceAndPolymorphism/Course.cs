namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        public Course(string name, string teacherName = null, IList<string> students = null)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }

        public string TeacherName { get; set; }

        public IList<string> Students { get; set; }

        public override string ToString()
        {
            string courseType = this.GetType().Name;
            string courseName = $"Name = {this.Name}";
            string teacherName = $"Teacher = {this.TeacherName}";
            string students = $"Students = {this.GetStudentsAsString()}";

            var result = new StringBuilder();
            result.AppendLine(courseType);
            result.AppendLine(courseName);
            result.AppendLine(teacherName);
            result.AppendLine(students);

            return result.ToString().Trim();
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
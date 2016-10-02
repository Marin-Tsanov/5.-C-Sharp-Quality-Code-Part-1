namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        public LocalCourse(string name, string teacherName = null, IList<string> students = null, string lab = null)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Lab = {this.Lab}");

            return result.ToString();
        }
    }
}
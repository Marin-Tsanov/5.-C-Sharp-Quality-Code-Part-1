namespace InheritanceAndPolymorphism
{
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name, string teacherName = null, IList<string> students = null, string town = null)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine($"Town = {this.Town}");

            return result.ToString();
        }
    }
}
using System;

namespace Students
{
    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }


        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must be set!");
                }

                this.firstName = value;
            }
        }

            public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name must be set!");
                }

                this.lastName = value;
            }
        }

            public string OtherInformation { get; set; }

        public bool IsOlderThan(Student other)
        {
            int older = 0;
            bool isOlder = false;

            DateTime firstDate = DateTime.Parse(this.OtherInformation.Substring(this.OtherInformation.Length - 10));
            DateTime secondDate = DateTime.Parse(other.OtherInformation.Substring(other.OtherInformation.Length - 10));
            older = DateTime.Compare(firstDate, secondDate);

            if (older < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}
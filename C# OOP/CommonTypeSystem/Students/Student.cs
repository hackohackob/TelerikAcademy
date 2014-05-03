using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Student: ICloneable, IComparable<Student>
    {
        private string firstName;

        private string middleName;

        private string lastName;

        private uint ssn;

        private string address;

        private string phone;

        private string email;

        private string course;

        public University university {get; set;}

        public Faculty faculty { get; set; }

        public Speciality speciality { get; set; }

        public enum University
        {
            SofiaUniversity,
            NewBulgarianUniversity,
            SoftwareUniversity
        };

        public enum Faculty
        {
            Mathematics,
            Informatics,
            SocialSciences,
            ComputerScience,
        };

        public enum Speciality
        {
            ComputerScience,
            SoftwareEngeneering,
            Psychology,
            InformationTechnologies
        }

        public string FirstName
        {
            get { return this.firstName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid name!");
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid name!");
                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid name!");
                this.lastName = value;
            }
        }

        public uint SSN
        {
            get { return this.ssn; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid SSN!");
                this.ssn = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid address!");
                this.address = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid phone number!");
                this.phone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid mail address!");
                this.email = value;
            }
        }

        public string Course
        {
            get { return this.course; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Invalid course name!");
                this.course = value;
            }
        }

        public Student (string firstName, string middleName, string lastName,
            uint SSN, string address, string phone, string email, string course
            )
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.ssn = SSN;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.course = course;
        }

        public Student(string firstName, string lastName, uint ssn)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ssn = ssn;
        }

        public Student()
        { }

        public override string ToString()
        {
            return string.Format(
                "\n{0} {1} {2}\nSSN: {3}\nPhone: {4}",
                this.firstName, this.middleName, this.lastName,
                this.ssn, this.phone
                );
        }

        public override int GetHashCode()
        {
            //because SSN is supposed to be unique
            return this.ssn.GetHashCode();
        }

        public override bool Equals(object obj)
        {

            Student student = obj as Student;
            
            if (student == null)
                return false;
            
            if (!Object.Equals(this.firstName, student.firstName))
                return false;
           
            if (!Object.Equals(this.lastName, student.lastName))
                return false;

            if (!Object.Equals(this.ssn, student.ssn))
                return false;

            return true;

        }

        public static bool operator ==(Student student1,
                                  Student student2)
        {
            return Student.Equals(student1, student2);
        }
        public static bool operator !=(Student student1,
                           Student student2)
        {
            return !(Student.Equals(student1, student2));
        }


        public Object Clone()
        {
            Student newStudent = new Student();
            newStudent.firstName = this.firstName;
            newStudent.middleName = this.middleName;
            newStudent.lastName = this.lastName;
            newStudent.ssn = this.ssn;
            newStudent.phone = this.phone;
            newStudent.email = this.email;
            newStudent.address = this.address;
            newStudent.university = this.university;
            newStudent.faculty = this.faculty;
            newStudent.speciality = this.speciality;
            newStudent.course = this.course;

            return newStudent;
        }

        public int CompareTo(Student other)
        {
            // an interpretation of the task where the two conditions matter equally
            if (this.firstName.CompareTo(other.firstName) == 1)
            {
                if (this.ssn > other.ssn)
                {
                    return 2;
                }
                return 1;
            }
            if (this.firstName.CompareTo(other.firstName) == -1)
            {
                if (this.ssn < other.ssn)
                {
                    return -2;
                }
                return -1;
            }
            if (this.ssn > other.ssn)
                return 1;
            if (this.ssn < other.ssn)
                return -1;
            return 0;

        }
    }
}

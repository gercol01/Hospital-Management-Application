using System;

namespace AssignmentTesting
{

    //Student inherits from Employee and has controlled access to Employee's private data via its protected properties.
    public class Student : Employee
    {

        //instance variables
        protected string _schoolName;

        //ten-parameter Constructor
        public Student(string empId, string fname, string lname,
                        string mob, string title, string ward, bool fullTime,
                        int hours, decimal hourlyRate,
                        string schoolName)
               : base(empId, fname, lname, mob, title, ward, fullTime, hours, hourlyRate)
        {
            //from derived class
            _schoolName = schoolName;
        }

        //property that gets and sets SchoolName of Student
        public string SchoolName
        {
            get
            {
                return _schoolName;
            }//end get
            set
            {
                _schoolName = value;
            }//end set
        }// end property SchoolName

        //print Student details
        public override string ToString() =>
            string.Format("{0,-15}", EmployeeId)
            + string.Format("{0,-15}", FirstName)
            + string.Format("{0,-15}", LastName)
            + string.Format("{0,-10}", Mobile)
            + string.Format("{0,-15}", Title)
            + string.Format("{0,-7}", Ward)
            + string.Format("{0,-11}", FullTime)
            + string.Format("{0,-15}", Hour)
            + string.Format("{0,-15:C}", HourlyRate)
            + string.Format("{0,-15}", SchoolName)
            + "\r\n"
        ;


        //calculate salary of employee's pay
        public override decimal GetSalary()
        {
            //stipend if student worked > 20 hours 
            int stipend = 160;
            decimal salary = (HourlyRate * Hour);
            //eligible for stipend
            if(Hour > 20 )
            { 
                
                salary =+ stipend;
                return salary;
            }
            //no stipend given
            else
            {
                return salary = 0 ;
            }
            
        }
    }
}

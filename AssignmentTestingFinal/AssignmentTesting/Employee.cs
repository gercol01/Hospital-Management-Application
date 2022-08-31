using System;

namespace AssignmentTesting
{
    //Employee abstract base class that implements interface IWard.
    public class Employee : IWard
    {
        //instance variables to be used by Ward Manager, Doctor, Nurse, Doctor
        protected string _employeeId;
        protected string _name;
        protected string _surname;
        protected string _mobileNo;
        protected string _title;
        protected string _ward;
        protected bool _fullTime;
        protected int _hoursWorked;
        protected decimal _hourlyRate;


        // nine-parameter constructor
        public Employee(string empId, string fname, string lname, 
                        string mob, string title, string ward, bool fullTime, 
                        int hours, decimal hourlyRate)
        {
            //implicit call to object constructor
            _employeeId = empId;
            _name = fname;
            _surname = lname;
            _mobileNo = mob;
            _title = title;
            _ward = ward;
            _fullTime = fullTime;
            _hoursWorked = hours;
            _hourlyRate = hourlyRate;
        }

        //read-only property EmployeeId
        public string EmployeeId
        {
            get
            {
                return _employeeId;
            } //end get
        } //end property EmployeeId

        //read-only property FirstName
        public string FirstName
        {
            get
            {
                return _name;
            } //end get
        }// end property FirstName

        //property that gets and sets LastName of employee
        public string LastName
        {
            get
            {
                return _surname;
            } //end get
            set
            {
                _surname = value;
            }//end set
        }// end property LastName

        //property that gets and sets mobile of employee
        public string Mobile
        {
            get
            {
                return _mobileNo;
            } // end get
            set
            {
                _mobileNo = value;
            }//end set
        }//end property Mobile

        //property that gets and sets Title of employee
        public string Title
        {
            get
            {
                return _title;
            }//end get
            set
            {
                _title = value;
            }//end set
        }//end property Title

        //property that gets and sets Ward of employee
        public string Ward
        {
            get
            {
                return _ward;
            }//end get
            set
            {
                _ward = value;
            }//end set
        }//end property Ward

        public bool FullTime
        {
            get
            {
                return _fullTime;
            }
            set
            {
                _fullTime = value;
            }
        }

        //property that gets and sets Hour of employee
        public int Hour
        {
            get
            {
                return _hoursWorked;
            }//end get
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Hour)} must be >= 0");
                }
                _hoursWorked = value;
            }//end set
        }//end property Hours

        //property that gets and sets HourlyRate of employee
        public decimal HourlyRate
        {
            get
            {
                return _hourlyRate;
            }//end get
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(HourlyRate)} must be >= 0");
                }
                _hourlyRate = value;
            }//end set
        }//end property HourlyRate


        //return string representation of employee object
        public override string ToString() =>
            $"Employee ID: {EmployeeId} \n" +
            $"First Name: {FirstName} \n" +
            $"Last Name: {LastName} \n" +
            $"Mobile no: {Mobile} \n" +
            $"Title: {Title} \n" +
            $"Ward: {Ward} \n" +
            $"Full time: {FullTime} \n" +
            $"Hours worked: {Hour} \n" +
            $"Hourly rate: {HourlyRate} ";


        //calculates salary of employee
        //marked as virtual since it is used to modify a method, property, indexer, or event declaration and allow for it to be overridden in a derived class.
        public virtual decimal GetSalary() =>
            (HourlyRate * Hour);
    }
}

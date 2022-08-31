using System;

namespace AssignmentTesting
{
    //class Manager cannot be inherited from Employee, since a Child inherits all the Parent's. 
    //A derived class is an instance of a base class, and therefore contains everything the base class contains.
    //Therefore since Manager does have a fixed salary, it does not make sense for it to inherit Employee.

    //Manager abstract class that implements interface IWard.
    public class Manager : IWard
    {
        //instance variables
        private string _employeeId;
        private string _name;
        private string _surname;
        private string _mobileNo;
        private string _title;
        private string _ward;
        private decimal _salary;

        //seven-parameter constructor
        public Manager(string empId, string fname,
                       string lname, string mob, string title, 
                       string ward, 
                       decimal salary)
                  
        {
            //implicit call to object constructor
            _employeeId = empId;
            _name = fname;
            _surname = lname;
            _mobileNo = mob;
            _title = title;
            _ward = ward;
            _salary = salary;
        }
        //read-only property that gets EmployeeID of employee
        public string EmployeeId
        {
            get
            {
                return _employeeId;
            } //end get
        } //end property EmployeeId

        //read-only property that gets FirstName of employee
        public string FirstName
        {
            get
            {
                return _name;
            } //end get
        }// end property FirstName

        //property that gets and sets LastName of manager
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

        //property that gets and sets mobile of manager
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

        //property that gets and sets Title of manager
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

        //property that gets and sets Ward of manager
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
        
        //property that gets and sets Salary of Manager
        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Salary)} must be >= 0");
                }
                _salary = value;
            }
        }

        //return header title for winforms
        public string output()=> "List of Managers:\r\n"
            + string.Format("{0,-15}", "Employee ID:")
            + string.Format("{0,-15}", "First name:")
            + string.Format("{0,-15}", "Last name:")
            + string.Format("{0,-10}", "Mobile:")
            + string.Format("{0,-15}", "Title:")
            + string.Format("{0,-7}", "Ward:")
            + "\r\n"
        ;

        //return string representation of Manager object
        public override string ToString() =>
            string.Format("{0,-15}", EmployeeId)
            + string.Format("{0,-15}", FirstName)
            + string.Format("{0,-15}", LastName)
            + string.Format("{0,-10}", Mobile)
            + string.Format("{0,-15}", Title)
            + string.Format("{0,-7}", Ward)
            + "\r\n"
        ;

        //calculate salary of employee's pay
        public decimal GetSalary() => _salary;
        
    }

}

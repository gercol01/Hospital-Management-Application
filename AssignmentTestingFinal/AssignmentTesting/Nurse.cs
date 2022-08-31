using System;

namespace AssignmentTesting
{
    //Nurse inherits from Employee and has controlled access to Employee's private data via its protected properties.
    public class Nurse : Employee
    {
        //instance variables
        // - none

        //nine-parameter Constructor
        public Nurse(string empId, string fname, string lname, string mob,
                      string title, string ward, bool fullTime,
                      int hours, decimal hourlyRate)
                  : base(empId, fname, lname, mob, title, ward, fullTime, hours, hourlyRate)
        {
            
        }
        //return string representation of employee object
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
            + "\r\n"
        ;

        //calculate salary of employee's pay
        public override decimal GetSalary() =>
            (HourlyRate * Hour);
    }
}

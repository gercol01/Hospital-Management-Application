using System;

namespace AssignmentTesting
{
    //Doctor inherits from Employee and has controlled access to Employee's private data via its protected properties.
    public class Doctor : Employee
    {
        //instance variables
        private decimal _bonusSurgery;
        private int _numberOfSurgeries;

        //eleven-parameter constructor
        public Doctor(string empId, string fname, string lname,string mob, 
                      string title, string ward, bool fullTime, 
                      int hours, decimal hourlyRate, decimal bonusSurgery, int numOfSuergeries)
                  : base(empId, fname, lname, mob, title, ward, fullTime, hours, hourlyRate)
        {
            _bonusSurgery = bonusSurgery;
            _numberOfSurgeries = numOfSuergeries;
        }

        //property that gets and sets BonusSurgery of doctor
        public decimal BonusSurgery
        {
            get
            {
                return _bonusSurgery;
            }//end get
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(BonusSurgery)} must be >= 0");
                }
                _bonusSurgery = value;
            }//end set
        }// end property BonusSurgery

        //property that gets and sets NumberOfSurgeries of doctor
        public int NumberOfSurgeries
        {
            get
            {
                return _numberOfSurgeries;
            }// end get
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(NumberOfSurgeries)} must be >= 0");
                }
                _numberOfSurgeries = value;
            }//end set
        }//end property NumberOfSurgeries

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
            + string.Format("{0,-15}", BonusSurgery)
            + string.Format("{0,-15}", NumberOfSurgeries)
            + "\r\n"
        ;

        //calculates bonus from number of surgeries done * the bonus per surgery
        public decimal CalculateBonus() => ((decimal)NumberOfSurgeries * (decimal)BonusSurgery);

        //calculate salary of employee's pay
        public override decimal GetSalary() =>
          ((HourlyRate * Hour) + (decimal)CalculateBonus());
    }

}

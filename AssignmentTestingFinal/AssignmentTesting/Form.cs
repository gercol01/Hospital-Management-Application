using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace AssignmentTesting
{
    public partial class Form : System.Windows.Forms.Form
    {
        //output of data retrieved 
        string output;
        private string employeeId;
        private string fname;
        private string lname; 
        string mob;
        private string ward;
        private string salary;
        private bool full;
        private int hours;
        private decimal hourly;
        private string surgeries;
        private string school;
        StreamReader sr;
        StreamWriter sw;

        Random rnd = new Random();//random object used to randomise colours
        List<IWard> List = new List<IWard>();//contains the various employees of the hospital

        public Form()
        {
            InitializeComponent();          
        }

        //Creates a new Ward Manager
        private void AddWard_Click(object sender, EventArgs e)
        {
            employeeId = TWEmpID.Text;
            fname = TWName.Text;
            lname = TWSurname.Text;
            mob = TWMobile.Text;
            ward = DWWard.Text;
            salary = TWSalary.Text;


            int counter = 0;
            if (string.IsNullOrEmpty(employeeId) || employeeId.Length != 7 || !checkIfHasNumber(employeeId))
            {
                invalidID.Text = "Invalid ID. Must be 7 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidID.Text = " ";
            }

            if (string.IsNullOrEmpty(fname) || (fname.Length <= 3 || fname.Length >= 20) || !checkIfHasLetter(fname))
            {
                invalidName.Text = "Invalid Name. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidName.Text = " ";

            }

            if (string.IsNullOrEmpty(lname) || (lname.Length <= 3 || lname.Length >= 20) || !checkIfHasLetter(lname))
            {
                invalidLName.Text = "Invalid Surname. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidLName.Text = " ";

            }

            if (string.IsNullOrEmpty(mob) || mob.Length != 8 || !checkIfHasNumber(mob))
            {
                invalidMob.Text = "Invalid Mobile Number. Must be 8 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidMob.Text = " ";

            }

            if (string.IsNullOrEmpty(ward))
            {
                invalidWard.Text = "Invalid Ward. Must not be null. Must not be null.";
            }
            else
            {
                counter++;
                invalidWard.Text = " ";

            }

            if (string.IsNullOrEmpty(salary) || !checkIfHasNumber(salary))
            {
                invalidSalary.Text = "Invalid Salary. Must not be null.";
            }
            else
            {
                counter++;
                invalidSalary.Text = " ";

            }

            if (counter == 6)
            {
                List.Add(new Manager(employeeId, fname, lname, mob, "Manager", ward, Int32.Parse(salary)));



                WardMessage.Visible = true;//message to show member has been added.

                WardMessage.ForeColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                ClearAllText(WardTab);//clears text
            }
            saveManager(List);
        }

        //Creates a new Doctor
        private void AddDoctor_Click(object sender, EventArgs e)
        {
            employeeId = TDEmpID.Text;
            fname = TDName.Text;
            lname = TDSurname.Text;
            mob = TDMobile.Text;
            ward = DDWard.Text;
            full = RDFull.Checked;
            hours = (int)NDHours.Value;
            hourly = NDHourly.Value;
            surgeries = NDSurgeries.Text;
            
            int counter = 0;

            if (string.IsNullOrEmpty(employeeId) || employeeId.Length != 7 || !checkIfHasNumber(employeeId))
            {
                invalidDID.Text = "Invalid ID. Must be 7 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidDID.Text = " ";

            }

            if (string.IsNullOrEmpty(fname) || (fname.Length <= 3 || fname.Length >= 20) || !checkIfHasLetter(fname))
            {
                invalidDName.Text = "Invalid Name. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidDName.Text = " ";

            }

            if (string.IsNullOrEmpty(lname) || (lname.Length <= 3 || lname.Length >= 20) || !checkIfHasLetter(lname))
            {
                invalidDLName.Text = "Invalid Surname. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidDLName.Text = " ";

            }

            if (string.IsNullOrEmpty(mob) || mob.Length != 8 || !checkIfHasNumber(mob))
            {
                invalidDMob.Text = "Invalid Mobile Number. Must be 8 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidDMob.Text = " ";

            }

            if (string.IsNullOrEmpty(ward))
            {
                invalidDWard.Text = "Invalid Ward. Must not be null.";
            }
            else
            {
                counter++;
                invalidDWard.Text = " ";

            }

            if (counter == 5)
            {
                List.Add(new Doctor(employeeId, fname, lname, mob, "Manager", ward, full, hours, hourly, 300, Int32.Parse(NDSurgeries.Text)));

                DoctorMessage.Visible = true;//message to show member has been added.

                DoctorMessage.ForeColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                ClearAllText(DoctorTab);//clears text
            }
           
            
            saveDoctor(List);
            saveDoctorBonus(List);
            saveEmployee(List);
            saveOvertimeEmployee(List);
        }

        //Creates a new Nurse
        private void AddNurse_Click(object sender, EventArgs e)
        {
            employeeId = TNEmpID.Text;
            fname = TNName.Text;
            lname = TNSurname.Text;
            mob = TNMobile.Text;
            ward = DNWard.Text;
            full = RNFull.Checked;
            hours = (int)NNHours.Value;
            hourly = NNHourly.Value;

            int counter = 0;

            if (string.IsNullOrEmpty(employeeId) || employeeId.Length != 7 || !checkIfHasNumber(employeeId))
            {
                invalidNID.Text = "Invalid ID. Must be 7 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidNID.Text = " ";

            }

            if (string.IsNullOrEmpty(fname) || (fname.Length <= 3 || fname.Length >= 20) || !checkIfHasLetter(fname))
            {
                invalidNName.Text = "Invalid Name. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidNName.Text = " ";

            }

            if (string.IsNullOrEmpty(lname) || (lname.Length <= 3 || lname.Length >= 20) || !checkIfHasLetter(lname))
            {
                invalidNLName.Text = "Invalid Surname. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidNLName.Text = " ";

            }

            if (string.IsNullOrEmpty(mob) || mob.Length != 8 || !checkIfHasNumber(mob))
            {
                invalidNMob.Text = "Invalid Mobile Number. Must be 8 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidNMob.Text = " ";

            }

            if (string.IsNullOrEmpty(ward))
            {
                invalidNWard.Text = "Invalid Ward. Must not be null.";
            }
            else
            {
                counter++;
                invalidNWard.Text = " ";

            }

            if (counter == 5)
            {
                List.Add(new Nurse(employeeId, fname, lname, mob, "Nurse", ward, full, hours, hourly));

                NurseMessage.Visible = true;//message to show member has been added.

                NurseMessage.ForeColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));

                ClearAllText(NurseTab);//clears text
            }
            saveNurse(List);
            saveEmployee(List);
            saveOvertimeEmployee(List);
        }

        //Creates a new Student
        private void AddStudent_Click(object sender, EventArgs e)
        {
            employeeId = TSEmpID.Text;
            fname = TSName.Text;
            lname = TSSurname.Text;
            mob = TSMobile.Text;
            ward = DSWard.Text;
            full = RSFull.Checked;
            hours = (int)NSHours.Value;
            hourly = NSHourly.Value;
            school = DSSchool.Text;

            int counter = 0;

            if (string.IsNullOrEmpty(employeeId) || employeeId.Length != 7 || !checkIfHasNumber(employeeId))
            {
                invalidSID.Text = "Invalid ID. Must be 7 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidSID.Text = " ";

            }

            if (string.IsNullOrEmpty(fname) || (fname.Length <= 3 || fname.Length >= 20) || !checkIfHasLetter(fname))
            {
                invalidSName.Text = "Invalid Name. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidSName.Text = " ";

            }

            if (string.IsNullOrEmpty(lname) || (lname.Length <= 3 || lname.Length >= 20) || !checkIfHasLetter(lname))
            {
                invalidSLName.Text = "Invalid Surname. Must be greater than 3 letters long and only contain letters.";
            }
            else
            {
                counter++;
                invalidSLName.Text = " ";

            }

            if (string.IsNullOrEmpty(mob) || mob.Length != 8 || !checkIfHasNumber(mob))
            {
                invalidSMob.Text = "Invalid Mobile Number. Must be 8 numbers long and only contain digits.";
            }
            else
            {
                counter++;
                invalidSMob.Text = " ";

            }

            if (string.IsNullOrEmpty(ward))
            {
                invalidSWard.Text = "Invalid Ward. Must not be null.";
            }
            else
            {
                counter++;
                invalidSWard.Text = " ";

            }

            if (string.IsNullOrEmpty(school))
            {
                invalidSSchool.Text = "Invalid School. Must not be null.";
            }
            else
            {
                counter++;
                invalidSSchool.Text = " ";

            }

            if (counter == 6)
            {
                List.Add(new Student(employeeId, fname, lname, mob, "Student", ward, full, hours, hourly, school));

                StudentMessage.Visible = true;//message to show member has been added.

                StudentMessage.ForeColor = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                ClearAllText(StudentTab);//clears text
            }
            saveStudent(List);
            saveOvertimeStudent(List);
            saveOvertimeEmployee(List);
            saveRegulartimeStudent(List);
            saveEmployee(List);
        }

        //Methods to save
        public void readEmployees(List<IWard> list)
        {
            dataGridView1.ClearSelection();

            XElement xelement = XElement.Load(@"Employees.xml");
            StringBuilder result = new StringBuilder();

            //Load xml
           XDocument xdoc = XDocument.Load(@"Employees.xml");

        }
        public void readOvertimeEmployees(List<IWard> list)
        {
            dataGridView1.ClearSelection();

            XElement xelement = XElement.Load(@"OvertimeEmployees.xml");
            StringBuilder result = new StringBuilder();

            //Load xml
            XDocument xdoc = XDocument.Load(@"OvertimeEmployees.xml");

        }
        public void readOvertimeStudents(List<IWard> list)
        {
            dataGridView1.ClearSelection();

            XElement xelement = XElement.Load(@"OvertimeStudent.xml");
            StringBuilder result = new StringBuilder();

            //Load xml
            XDocument xdoc = XDocument.Load(@"OvertimeStudent.xml");
        }

        public void readRegulartimeStudents(List<IWard> list)
        {

            dataGridView1.ClearSelection();

            XElement xelement = XElement.Load(@"RegulartimeStudent.xml");
            StringBuilder result = new StringBuilder();

            //Load xml
            XDocument xdoc = XDocument.Load(@"RegulartimeStudent.xml");
        }

        public void readDoctorBonus(List<IWard> list)
        {
            dataGridView1.ClearSelection();

            XElement xelement = XElement.Load(@"BonusDoctors.xml");
            StringBuilder result = new StringBuilder();

            //Load xml
            XDocument xdoc = XDocument.Load(@"BonusDoctors.xml");
        }
        public void saveEmployee(List<IWard> list)
        {
            // if file!exists
            if (File.Exists(@"Employees.xml"))
            {
                var file = @"Employees.xml";
                var doc = XDocument.Load(file);

                var newEmployee = new XElement("employees",
                from value in list.OfType<Employee>()
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate)));
                doc.Root.Add(newEmployee);


                doc.Save(file);
            }
            else
            {
                var Employees = new XElement("employees",
                    from value in list.OfType<Employee>()
                    select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate)));

                Employees.Save(@"Employees.xml");
            }
        }
        public void saveOvertimeEmployee(List<IWard> list)
        {

            // if file!exists
            if (File.Exists(@"OvertimeEmployees.xml"))
            {
                var file = @"OvertimeEmployees.xml";
                var doc = XDocument.Load(file);

                var newEmployee = new XElement("employees",
                from value in list.OfType<Employee>()
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate)));
                doc.Root.Add(newEmployee);
                doc.Save(file);
            }
            else
            {
                var Employees = new XElement("employees",
                    from value in list.OfType<Employee>()
                    where value.Hour > 160
                    select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate)));
                Employees.Save(@"OvertimeEmployees.xml");
            }
        }
        public void saveManager(List<IWard> list)
        {
            // if file!exists
            if (File.Exists(@"WardManager.xml"))
            {
                var file = @"WardManager.xml";
                var doc = XDocument.Load(file);

                var newManager = new XElement("managers",
                from value in list.OfType<Manager>()
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("salary", value.Salary)));
                doc.Root.Add(newManager);
                doc.Save(file);
            }
            else
            {
                var WardManagerEmployees = new XElement("managers",
                    from value in list.OfType<Manager>()
                    select new XElement("employeeId", value.EmployeeId,
                           new XElement("name", value.FirstName),
                           new XElement("surname", value.LastName),
                           new XElement("mobile", value.Mobile),
                           new XElement("ward", value.Ward),
                           new XElement("salary", value.Salary)));

                WardManagerEmployees.Save(@"WardManager.xml");
            }
        }
        public void saveNurse(List<IWard> list)
        {
            // if file!exists
            if (File.Exists(@"Nurses.xml"))
            {
                var file = @"Nurses.xml";
                var doc = XDocument.Load(file);

                var newNurse = new XElement("nurses",
                from value in list.OfType<Nurse>()
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate)));
                doc.Root.Add(newNurse);


                doc.Save(file);
            }
            else
            {
                var NurseEmployees = new XElement("nurses",
                    from value in list.OfType<Nurse>()
                    select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate)));

                NurseEmployees.Save(@"Nurses.xml");
            }
        }
        public void saveDoctor(List<IWard> list)
        {
            // if file!exists
            if (File.Exists(@"Doctors.xml"))
            {
                var file = @"Doctors.xml";
                var doc = XDocument.Load(file);

                var newDoctor = new XElement("doctors",
                from value in list.OfType<Doctor>()
                select new XElement("employeeId", value.EmployeeId,
                   new XElement("name", value.FirstName),
                   new XElement("surname", value.LastName),
                   new XElement("mobile", value.Mobile),
                   new XElement("ward", value.Ward),
                   new XElement("fulltime", value.FullTime),
                   new XElement("hours", value.Hour),
                   new XElement("hourly_rate", value.HourlyRate),
                   new XElement("bonus_surgeryrate", value.BonusSurgery),
                   new XElement("number_of_surgeries", value.NumberOfSurgeries)));
                doc.Root.Add(newDoctor);
                doc.Save(file);
            }
            else
            {
                var DoctorEmployees = new XElement("doctors",
                    from value in list.OfType<Doctor>()
                    select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate),
                       new XElement("bonus_surgeryrate", value.BonusSurgery),
                       new XElement("number_of_surgeries", value.NumberOfSurgeries)));
                DoctorEmployees.Save(@"Doctors.xml");
            }
        }
        public void saveStudent(List<IWard> list)
        {

           // if file!exists
            if (File.Exists(@"Students.xml"))
            {
                var file = @"Students.xml";
                var doc = XDocument.Load(file);

                var newStudents = new XElement("students",
                from value in list.OfType<Student>()
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate),
                       new XElement("school", value.SchoolName)));
                doc.Root.Add(newStudents);


                doc.Save(file);
            }
            else
            {
                var studentEmployees = new XElement("students",
                    from value in list.OfType<Student>()
                    select new XElement("employeeId", value.EmployeeId,
                           new XElement("name", value.FirstName),
                           new XElement("surname", value.LastName),
                           new XElement("mobile", value.Mobile),
                           new XElement("ward", value.Ward),
                           new XElement("fulltime", value.FullTime),
                           new XElement("hours", value.Hour),
                           new XElement("hourly_rate", value.HourlyRate),
                           new XElement("school", value.SchoolName)));
                studentEmployees.Save(@"Students.xml");
            }
        }

        public void saveOvertimeStudent(List<IWard> list)
        {
            // if file!exists
            if (File.Exists(@"OvertimeStudent.xml"))
            {
                var file = @"OvertimeStudent.xml";
                var doc = XDocument.Load(file);

                var newStudents = new XElement("students",
                from value in list.OfType<Student>()
                where value.Hour > 20
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate),
                       new XElement("school", value.SchoolName)));
                doc.Root.Add(newStudents);


                doc.Save(file);
            }
            else
            {
                var studentEmployees = new XElement("students",
                    from value in list.OfType<Student>()
                    where value.Hour > 20
                    select new XElement("employeeId", value.EmployeeId,
                           new XElement("name", value.FirstName),
                           new XElement("surname", value.LastName),
                           new XElement("mobile", value.Mobile),
                           new XElement("ward", value.Ward),
                           new XElement("fulltime", value.FullTime),
                           new XElement("hours", value.Hour),
                           new XElement("hourly_rate", value.HourlyRate),
                           new XElement("school", value.SchoolName)));
                studentEmployees.Save(@"OvertimeStudent.xml");
            }
        }
        public void saveRegulartimeStudent(List<IWard> list)
        {
            // if file!exists
            if (File.Exists(@"RegulartimeStudent.xml"))
            {
                var file = @"RegulartimeStudent.xml";
                var doc = XDocument.Load(file);

                var newStudents = new XElement("students",
                from value in list.OfType<Student>()
                where value.Hour <= 20
                select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate),
                       new XElement("school", value.SchoolName)));
                doc.Root.Add(newStudents);
                doc.Save(file);
            }
            else
            {
                var studentEmployees = new XElement("students",
                    from value in list.OfType<Student>()
                    where value.Hour <= 20
                    select new XElement("employeeId", value.EmployeeId,
                           new XElement("name", value.FirstName),
                           new XElement("surname", value.LastName),
                           new XElement("mobile", value.Mobile),
                           new XElement("ward", value.Ward),
                           new XElement("fulltime", value.FullTime),
                           new XElement("hours", value.Hour),
                           new XElement("hourly_rate", value.HourlyRate),
                           new XElement("school", value.SchoolName)));
                studentEmployees.Save(@"RegulartimeStudent.xml");
            }
        }

        public void saveDoctorBonus(List<IWard> list) {
            // if file!exists
            if (File.Exists(@"BonusDoctors.xml"))
            {
                var file = @"BonusDoctors.xml";
                var doc = XDocument.Load(file);

                var newDoctor = new XElement("doctors",
                from value in list.OfType<Doctor>()
                where value.NumberOfSurgeries > 0
                select new XElement("employeeId", value.EmployeeId,
                   new XElement("name", value.FirstName),
                   new XElement("surname", value.LastName),
                   new XElement("mobile", value.Mobile),
                   new XElement("ward", value.Ward),
                   new XElement("fulltime", value.FullTime),
                   new XElement("hours", value.Hour),
                   new XElement("hourly_rate", value.HourlyRate),
                   new XElement("bonus_surgeryrate", value.BonusSurgery),
                   new XElement("number_of_surgeries", value.NumberOfSurgeries)));
                doc.Root.Add(newDoctor);
                doc.Save(file);
            }
            else
            {
                var DoctorEmployees = new XElement("doctors",
                    from value in list.OfType<Doctor>()
                    where value.NumberOfSurgeries > 0
                    select new XElement("employeeId", value.EmployeeId,
                       new XElement("name", value.FirstName),
                       new XElement("surname", value.LastName),
                       new XElement("mobile", value.Mobile),
                       new XElement("ward", value.Ward),
                       new XElement("fulltime", value.FullTime),
                       new XElement("hours", value.Hour),
                       new XElement("hourly_rate", value.HourlyRate),
                       new XElement("bonus_surgeryrate", value.BonusSurgery),
                       new XElement("number_of_surgeries", value.NumberOfSurgeries)));
                DoctorEmployees.Save(@"BonusDoctors.xml");
            }
        }
        
        //Method to clear all text in the UI window to display employees.
        public void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {   if (c is TextBox)//clears text boxes
                    ((TextBox)c).Clear();
                else if (c is ComboBox)//resets dropdowns
                    ((ComboBox)c).SelectedIndex = -1;
                else if (c is NumericUpDown)//resets Numeric up down
                    ((NumericUpDown)c).Value = 0;
                else if (c is RadioButton)//resets Numeric up down
                    ((RadioButton)c).Checked = false;
                else
                    ClearAllText(c);
            }
        }


        //List of Doctors, Nurses, Students and ward managers
        public void listAllEmployees(List<IWard> list)
        {
            DetailUI.Clear(); //Clearing the Display before printing results

            //Linq queries to retrieve data
            var managerEmployee = from value in list.OfType<Manager>()
                                  where value.EmployeeId != null
                                  select value;

            var doctorEmployee = from value in list.OfType<Doctor>()
                                 where value.EmployeeId != null
                                 select value;

            var nurseEmployee = from value in list.OfType<Nurse>()
                                where value.EmployeeId != null
                                select value;

            var studentEmployees = from value in list.OfType<Student>()
                                   where value.EmployeeId != null
                                   select value;
    
            output = "List of Managers:\r\n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-10}", "Mobile:")
                + string.Format("{0,-15}", "Title:")
                + string.Format("{0,-7}", "Ward:")
                + "\r\n";


            foreach (Manager values in managerEmployee)
            {
                    output += values.ToString();
            }

            output += "\r\nList of Doctors:\r\n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-10}", "Mobile:")
                + string.Format("{0,-15}", "Title:")
                + string.Format("{0,-7}", "Ward:")
                + string.Format("{0,-11}", "Fulltime:")
                + string.Format("{0,-15}", "Hours worked:")
                + string.Format("{0,-15}", "Hourly rate:")
                + string.Format("{0,-15}", "Bonus:")
                + string.Format("{0,-15}", "No. of Surgeries:")
                + "\r\n";

            foreach (Doctor values in doctorEmployee)
            {
                output += values.ToString();
            }

            output += "\r\nList of Nurses:\r\n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-10}", "Mobile:")
                + string.Format("{0,-15}", "Title:")
                + string.Format("{0,-7}", "Ward:")
                + string.Format("{0,-11}", "Fulltime:")
                + string.Format("{0,-15}", "Hours worked:")
                + string.Format("{0,-15}", "Hourly rate:")
                + "\r\n";

            foreach (Nurse values in nurseEmployee)
            {
                output += values.ToString();
            }

            output += "\r\nList of Students:\r\n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-10}", "Mobile:")
                + string.Format("{0,-15}", "Title:")
                + string.Format("{0,-7}", "Ward:")
                + string.Format("{0,-11}", "Fulltime:")
                + string.Format("{0,-15}", "Hours worked:")
                + string.Format("{0,-15}", "Hourly rate:")
                + string.Format("{0,-15}", "School name:")
                + "\r\n";

            foreach (Student values in studentEmployees)
            {
                output += values.ToString();
            }

            DetailUI.Text = output; //displaying the whole list
        }

        //Method for students who exceeded 20hrs/month
        public void CheckStudentOvertime(List<IWard> test)
        {
            DetailUI.Clear();

            var checkStudentOvertime = from value in test.OfType<Student>()
                                       where value.Hour > 20//students who did more than 20 hours in a month
                                       select value;

            output = "These following student/s worked overtime:\r\n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-15}", "Hours worked:")
                + string.Format("{0,-15}", "Overtime hours:")
                + "\r\n";

            foreach (Student values in checkStudentOvertime)
            {
                output += string.Format("{0,-15}", values.EmployeeId)
                    + string.Format("{0,-15}", values.FirstName)
                    + string.Format("{0,-15}", values.LastName)
                    + string.Format("{0,-15}", values.Hour)
                    + string.Format("{0,-15}", values.Hour - 20)
                    + "\r\n";
            }

            DetailUI.Text = output; //displaying the whole list
        }

        //Method for students who did not work overtime
        public void CheckStudentRegular(List<IWard> test)
        {
            DetailUI.Clear();

            var checkStudentRegular = from value in test.OfType<Student>()
                                      where value.Hour <= 20 //students who did NOT do more than 20 hours in a month
                                      select value;

            output = "These following student/s did not work overtime:\r\n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-15}", "Hours worked:")
                + "\r\n";

            foreach (Student values in checkStudentRegular)
            {
                output += string.Format("{0,-15}", values.EmployeeId)
                    + string.Format("{0,-15}", values.FirstName)
                    + string.Format("{0,-15}", values.LastName)
                    + string.Format("{0,-15}", values.Hour)
                    + "\r\n";
            }

            DetailUI.Text = output; //displaying the whole list
        }

        //Employees who worked overtime
        public void CheckOvertime(List<IWard> test)
        {
            DetailUI.Clear();

            var checkOvertimeWorked = from value in test.OfType<Employee>()
                                      where value.Hour > 160//employees who did more than 40 hours in a week, 160 is the whole month
                                      select value;

            //student overtime
            var checkStudentOvertime = from value in test.OfType<Student>()
                                       where value.Hour > 20//students who did more than 20 hours in a month
                                       select value;

            //combining the 2 lists
            var overtimeStaff = checkOvertimeWorked.Union(checkStudentOvertime).OrderBy(val => val.EmployeeId).ToList();


            output = "These following employees worked overtime: \n"
                +string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-15}", "Hours worked:")
                + "\r\n"
            ;
            
            foreach (var values in overtimeStaff)
            {
                output += string.Format("{0,-15}", values.EmployeeId)
                    + string.Format("{0,-15}", values.FirstName)
                    + string.Format("{0,-15}", values.LastName)
                    + string.Format("{0,-15}", values.Hour)
                    + "\r\n"
                ;
            }
            DetailUI.Text = output; //displaying the whole list
        }

        //Method to display any doctors which performed surgeries monthly.
        public void CheckBonus(List<IWard> test)
        {
            DetailUI.Clear();

            var checkSurgeryBonus = from value in test.OfType<Doctor>()
                                    where value.BonusSurgery > 0
                                    select value;

            output = "These following employees worked overtime: \n"
                + string.Format("{0,-15}", "Employee ID:")
                + string.Format("{0,-15}", "First name:")
                + string.Format("{0,-15}", "Last name:")
                + string.Format("{0,-15}", "Hours worked:")
                + string.Format("{0,-15}", "Bonus per surgery: ")
                + string.Format("{0,-15}", "Number of surgeries: ")
                + "\r\n";

            foreach (Doctor values in checkSurgeryBonus)
            {
                output += string.Format("{0,-15}", values.EmployeeId)
                    + string.Format("{0,-15}", values.FirstName)
                    + string.Format("{0,-15}", values.LastName)
                    + string.Format("{0,-15}", values.Hour)
                    + string.Format("{0,-15}", values.BonusSurgery)
                    + string.Format("{0,-20}", values.NumberOfSurgeries)
                    + "\r\n";
            }
            DetailUI.Text = output; //displaying the whole list
        }

        //Method to calculate every Wages' salary.
        public void ListWage(List<IWard> emp)
        {
            DetailUI.Clear();


            //query to retrieve employee's details
            var queryEmployee =
                (from value in emp.OfType<Employee>()
                 group value by new { value.Ward }
                 into grp
                 select new
                 {
                     grp.Key.Ward,
                     Salary = grp.Sum(value => value.GetSalary())
                 });

            //query to retrieve managers' details
            var queryManager =
                (from value in emp.OfType<Manager>()
                 group value by new { value.Ward }
                 into grp
                 select new
                 {
                     grp.Key.Ward,
                     Salary = grp.Sum(value => value.GetSalary())
                 });

            //creating another list to concatenate both the employee list and the manager list to display the total salary of each ward
            var wardSalary = queryEmployee.Concat(queryManager);

            //performing another query on the newly joined list (wardSalary) so that it sums and returns the employee and managers' salary.
            var totalSalary =
                (from value in wardSalary
                 orderby value.Ward
                 group value by new { value.Ward }               
                 into grp
                 select new
                 {
                     grp.Key.Ward,
                     Salary = grp.Sum(value => value.Salary) 
                 });

            output = "Wards' salary for the month: \n"
                + string.Format("{0,-7}", "Ward:")
                + string.Format("{0,-15}", "Salary:")
                + "\r\n"
            ;

            foreach (var value in totalSalary)
            {
                output += string.Format("{0,-7}", value.Ward)
                    + string.Format("{0,-15}", value.Salary)
                    + "\r\n"
                ; 
            }
            DetailUI.Text = output; //displaying the whole list
        }

        //Method to calculate the total hospitals' salary.
        private void HospitalSalary(List<IWard> emp)
        {
            DetailUI.Clear();
            //query to retrieve employee's salary
            var queryEmployee =
                (from value in emp.OfType<Employee>()
                 group value by new { }
                 into grp
                 select new
                 {
                     Salary = grp.Sum(value => value.GetSalary())
                 }).ToList();

            //query to retrieve managers' salary
            var queryManager =
                (from value in emp.OfType<Manager>()
                 group value by new { }
                 into grp
                 select new
                 {
                     Salary = grp.Sum(value => value.GetSalary())
                 }).ToList();

            //creating another list to concatenate both the employee list and the manager list to display the total salary of the hospital.
            var hospitalSalary = queryEmployee.Concat(queryManager);

            //performing another query on the newly joined list (hospitalSalary) so that it sums and returns the employee and managers' salary.
            var totalHospitalSalary =
                (from value in hospitalSalary
                 group value by new { }
                 into grp
                 select new
                 {
                     Salary = grp.Sum(value => value.Salary)
                 }).ToList();



            output = "Total salary of the hospital: "
            ;

            foreach (var value in totalHospitalSalary)
            {
                output += string.Format("{0,-15}", value.Salary)
                    + "\r\n"
                ;
            }
            DetailUI.Text = output; //displaying the whole list
        }

        public bool checkIfHasNumber(String number)
        {
            bool result = true;
            //loop to check that the chars are digits
            foreach (char i in number)
            {
                if (char.IsLetter(i))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool checkIfHasLetter(String text)
        {
            //string into array of char
            char[] charArray = text.ToCharArray();
            bool result = true;

            //loop to check that the chars are letters
            foreach (char i in text)
            {
                if (char.IsDigit(i))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        //Below methods are for event handling with buttons.
        private void ListAllEmployees_Click(object sender, EventArgs e)
        {
            listAllEmployees(List);
            readEmployees(List);
            DataSet dataset = new DataSet();
            dataset.ReadXml(@"Employees.xml");
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void OvertimeStudents_Click(object sender, EventArgs e)
        {
            CheckStudentOvertime(List);
            readOvertimeStudents(List);
            DataSet dataset = new DataSet();
            dataset.ReadXml(@"OvertimeStudent.xml");
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void RegularStudents_Click(object sender, EventArgs e)
        {
            CheckStudentRegular(List);
            readRegulartimeStudents(List);
            DataSet dataset = new DataSet();
            dataset.ReadXml(@"RegulartimeStudent.xml");
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void OvertimeEmployees_Click(object sender, EventArgs e)
        {
            CheckOvertime(List);
            readOvertimeEmployees(List);
            DataSet dataset = new DataSet();
            dataset.ReadXml(@"OvertimeEmployees.xml");
            dataGridView1.DataSource = dataset.Tables[0];
        }
        private void CheckBonus_Click(object sender, EventArgs e)
        {
            CheckBonus(List);
            readDoctorBonus(List);
            DataSet dataset = new DataSet();
            dataset.ReadXml(@"BonusDoctors.xml");
            dataGridView1.DataSource = dataset.Tables[0];
        }

        private void WardSalary_Click(object sender, EventArgs e)
        {
            ListWage(List);
        }
        private void HospitalSalary_Click(object sender, EventArgs e)
        {
            HospitalSalary(List);
        }

    }
}
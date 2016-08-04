using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2016_Lesson1_1_
{
    public partial class StudentDetailsForm : Form
    {
        // Public Properties

            //ref previous form
        public StudentListForm studentListForm { get; set; }

        //what type of form do i need
        public int FormType { get; set; }

        //what is the studet id of the row tht is clicked?
        public int StudentID { get; set; }
        public StudentDetailsForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // creates a reference to sql database
            StudentDataContext db = new StudentDataContext();
            Student newstudent = new Student();
            //Copy data into student object from form text boxes  
            newstudent.FirstName = FirstNameTextBox.Text;
            newstudent.LastName = LastNameTextBox.Text;
            newstudent.Number = StudentNumberTextBox.Text;

            // insery the new student object into the sql database
            db.GetTable<Student>().InsertOnSubmit(newstudent);

            // save changes
            db.SubmitChanges();

            // show student list form
            this.studentListForm.Show();

            // close this form
            this.Close();


        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.studentListForm.Show();
            this.Close();

        }

        private void StudentDetailsForm_Load(object sender, EventArgs e)
        {
            // create database object
            StudentDataContext db = new StudentDataContext();
            // check to ensure that you are asking for details , edit or delete form
            if (this.FormType > 3)
            {
                Student studentDetails = (from student in db.Students
                                          where student.StudentID == this.StudentID
                                          select student).FirstOrDefault();
                //display details in the text boxs of the form
                FirstNameTextBox.Text = studentDetails.FirstName;
                LastNameTextBox.Text = studentDetails.LastName;
                StudentNumberTextBox.Text = studentDetails.Number;
            }
            switch(this.FormType)
            {
                case (int)ColumnButton.details:
                    NewStdentLabel.Text = "Student Details";
                    this.Text = "Student Details";
                    SubmitButton.Visible = false;
                    FirstNameTextBox.ReadOnly = true;
                    LastNameTextBox.ReadOnly = true;
                    StudentNumberTextBox.ReadOnly = true;
                    CancelButton.Text = "Back";
                    break;

                case (int)ColumnButton.Edit:
                    NewStdentLabel.Text = "Edit Student";
                    this.Text = "Edit Student";
                    SubmitButton.Text = "Update";
                    break;
                // if the button clicked is the Delete Button
                case (int)ColumnButton.Delete:
                    NewStdentLabel.Text = "Delete Student";
                    this.Text = "Delete Student";
                    FirstNameTextBox.ReadOnly = true;
                    LastNameTextBox.ReadOnly = true;
                    StudentNumberTextBox.ReadOnly = true;
                    SubmitButton.Text = "Delete";
                    SubmitButton.BackColor = Color.Red;
                    break;
            }
            }
    }
}

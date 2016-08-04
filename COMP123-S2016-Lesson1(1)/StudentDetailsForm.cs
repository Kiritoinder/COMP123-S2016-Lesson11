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
    }
}

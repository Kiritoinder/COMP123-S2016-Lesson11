using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_S2016_Lesson1_1_
{
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cOMP123DataSet.Students' table. You can move, or remove it, as needed.

        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            StudentDetailsForm addStudentForm = new StudentDetailsForm();
            addStudentForm.studentListForm = this;
            addStudentForm.Show();
            this.Hide();
        }

        private void StudentListForm_Activated(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Fill(this.cOMP123DataSet.Students);

        }

        private void StudentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // creates a new studentsDetails form
            StudentDetailsForm StudentDetails = new StudentDetailsForm();
            StudentDetails.studentListForm = this; // make a reference to this form 
            StudentDetails.FormType = e.ColumnIndex; // send over the button that is clicked
            
            //get the student id from the studentDataGridView
            StudentDetails.StudentID = Convert.ToInt32(StudentDataGridView.Rows[e.RowIndex].Cells["StudentID"].Value);

            StudentDetails.Show(); // show the studentDetais Form

            this.Hide();// hides this form
        }
    }
}

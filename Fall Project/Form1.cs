using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fall_Project
{
    public partial class Form1 : Form
    {
        internal enum Grids
        {
            students, programs,courses,enrollment
        }

        internal static Form1 current;

        private Grids grid;


        private bool OKToChange = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.students;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourceStudents.DataSource = Data.Students.GetStudents();
                bindingSourceStudents.Sort = "stId";
                dataGridView1.DataSource = bindingSourceStudents;

                dataGridView1.Columns["stId"].HeaderText = "Id";
                dataGridView1.Columns["progId"].HeaderText = "Program Id";
                dataGridView1.Columns["stName"].HeaderText = "Name";

                dataGridView1.Columns["stId"].DisplayIndex = 0;
                dataGridView1.Columns["stName"].DisplayIndex = 1;
                dataGridView1.Columns["progId"].DisplayIndex = 2;
            }
            else
            {
                OKToChange = true;
            }

        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange && (grid != Grids.enrollment))
                //This prevents the enrollment table from refreshing when you select a row
            {
                grid = Grids.enrollment;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourceEnrollments.DataSource = Data.Enrollments.GetDisplayEnrollments();
                bindingSourceEnrollments.Sort = "stId,cId";
                dataGridView1.DataSource = bindingSourceEnrollments;

                
                dataGridView1.Columns["stId"].HeaderText = "Student Id";
                dataGridView1.Columns["cId"].HeaderText = "Course Id";
                dataGridView1.Columns["finalGrade"].HeaderText = "Final Grade";
                dataGridView1.Columns["stName"].HeaderText = "Student Name";
                dataGridView1.Columns["cName"].HeaderText = "Course Name";
                dataGridView1.Columns["progId"].HeaderText = "Program Id";
                dataGridView1.Columns["progName"].HeaderText = "Program Name";

                dataGridView1.Columns["stId"].DisplayIndex = 0;
                dataGridView1.Columns["stName"].DisplayIndex = 1;
                dataGridView1.Columns["cId"].DisplayIndex = 2;
                dataGridView1.Columns["cName"].DisplayIndex = 3;
                dataGridView1.Columns["progId"].DisplayIndex = 4;
                dataGridView1.Columns["progName"].DisplayIndex = 5;
                dataGridView1.Columns["finalGrade"].DisplayIndex = 6;
            }
            else
            {
                OKToChange = true;
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.courses;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourceCourses.DataSource = Data.Courses.GetCourses();
                bindingSourceCourses.Sort = "cId";
                dataGridView1.DataSource = bindingSourceCourses;

                dataGridView1.Columns["cId"].HeaderText = "Course Id";
                dataGridView1.Columns["progId"].HeaderText = "Program Id";
                dataGridView1.Columns["cName"].HeaderText = "Course Name";

                dataGridView1.Columns["cId"].DisplayIndex = 0;
                dataGridView1.Columns["cName"].DisplayIndex = 1;
                dataGridView1.Columns["progId"].DisplayIndex = 2;
            }
            else
            {
                OKToChange = true;
            }
        }

        private void programsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                grid = Grids.programs;
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourcePrograms.DataSource = Data.Programs.GetPrograms();
                bindingSourcePrograms.Sort = "progId";
                dataGridView1.DataSource = bindingSourcePrograms;

                dataGridView1.Columns["progId"].HeaderText = "Program Id";
                dataGridView1.Columns["progName"].HeaderText = "Program Name";

                dataGridView1.Columns["progName"].DisplayIndex = 1;
                dataGridView1.Columns["progId"].DisplayIndex = 0;
            }
            else
            {
                OKToChange = true;
            }
        }

        private void bindingSourcePrograms_CurrentChanged(object sender, EventArgs e)
        {
            
            if (BusinessLayer.Programs.UpdatePrograms() == -1)
            {
                bindingSourcePrograms.ResetBindings(false);
               
            }
        }

        private void bindingSourceStudents_CurrentChanged(object sender, EventArgs e)
        {
            if (BusinessLayer.Students.UpdateStudents() == -1)
            {
                bindingSourcePrograms.ResetBindings(false);
                
            }
        }

        private void bindingSourceCourses_CurrentChanged(object sender, EventArgs e)
        {
            BusinessLayer.Courses.UpdateCourses();
        }

        private void bindingSourceEnrollments_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            OKToChange = true;
            Validate();
            if (grid == Grids.courses)
            {
                
                if (BusinessLayer.Courses.UpdateCourses() == -1)
                {
                    OKToChange = false;
                }
            }
            else if (grid == Grids.programs)
            {

                if (BusinessLayer.Programs.UpdatePrograms() == -1)
                {
                    OKToChange = false;
                }
            }
            else if (grid == Grids.students)
            {

                if (BusinessLayer.Students.UpdateStudents() == -1)
                {
                    OKToChange = false;
                }
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BindingSource temp = (BindingSource)dataGridView1.DataSource;

            if (temp == bindingSourceCourses)
            {
                if (BusinessLayer.Courses.UpdateCourses() == -1)
                {
                    OKToChange = false;
                }
            }
            else if (temp == bindingSourcePrograms)
            {
                if (BusinessLayer.Programs.UpdatePrograms() == -1)
                {
                    OKToChange = false;
                }
            }
            else if (temp == bindingSourceStudents)
            {
                if (BusinessLayer.Students.UpdateStudents() == -1)
                {
                    OKToChange = false;
                }
            }


            if (!OKToChange)
            {
                e.Cancel = true;
                OKToChange = true;
            }
        }









        internal static void BLLMessage(string s)
        {
            MessageBox.Show("Business Layer: " + s);
        }

        internal static void DALMessage(string s)
        {
            MessageBox.Show("Data Layer: " + s);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;  
            OKToChange = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Form2();
            Form2.current.Visible = false;

            Text = "Main";
            dataGridView1.Dock = DockStyle.Fill;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.current.Start(Form2.Modes.ADD, null);
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           

            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for modification");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for modification");
            }
            else
            {
                if ("" + c[0].Cells["finalGrade"].Value == "")
                {
                    Form2.current.Start(Form2.Modes.MODIFY, c);
                }
                else
                {
                    MessageBox.Show("To modify this line, final grade value must be removed first.");
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            bool okToDelete = true;
            if (c.Count == 0)
            {
                MessageBox.Show("At least one line must be selected for deletion");
            }
            else // (c.Count > 1)
            {
                List<string[]> lId = new List<string[]>();
                for (int i = 0; i < c.Count; i++)
                {
                    if (c[i].Cells["finalGrade"].Value.ToString() != "")
                    {
                        MessageBox.Show("One of the selected lines has a grade");
                        okToDelete = false;
                        break;
                    }
                    lId.Add(new string[] { "" + c[i].Cells["stId"].Value,
                                           "" + c[i].Cells["cId"].Value });
                }
                if (okToDelete)
                {
                    Data.Enrollments.DeleteData(lId);
                }
                
            }
        }

        private void manageFinalGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection c = dataGridView1.SelectedRows;
            if (c.Count == 0)
            {
                MessageBox.Show("A line must be selected for final grade modification");
            }
            else if (c.Count > 1)
            {
                MessageBox.Show("Only one line must be selected for modification");
            }
            else
            {
                Form2.current.Start(Form2.Modes.GRADE, c);
            }
        }
    }//end for Form1
}

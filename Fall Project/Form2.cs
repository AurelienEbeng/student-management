using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fall_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            current = this;
            InitializeComponent();
        }

        internal enum Modes
        {
            ADD,MODIFY,GRADE
        }

        internal static Form2 current;

        private Modes mode = Modes.ADD;

        private string[] assignInitial;


        internal void Start(Modes m, DataGridViewSelectedRowCollection c)
        {
            mode = m;
            Text = "" + mode;

            
            comboBoxCId.DisplayMember = "cId";
            comboBoxCId.ValueMember = "cId";
            comboBoxCId.DataSource = Data.Courses.GetCourses();
            comboBoxCId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCId.SelectedIndex = 0;



            comboBoxProgId.DisplayMember = "progId";
            comboBoxProgId.ValueMember = "progId";
            comboBoxProgId.DataSource = Data.Programs.GetPrograms();//what does this line do?
            comboBoxProgId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProgId.SelectedIndex = 0;


            comboBoxStId.DisplayMember = "stId";
            comboBoxStId.ValueMember = "stId";
            comboBoxStId.DataSource = Data.Students.GetStudents();//what does this line do?
            comboBoxStId.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStId.SelectedIndex = 0;


            textBoxCName.ReadOnly = true;
            textBoxProgName.ReadOnly = true;
            textBoxStName.ReadOnly = true;
            textBoxFinalGrade.Enabled = false;

            if (mode == Modes.ADD)
            {
                textBoxFinalGrade.Enabled = false;
                comboBoxCId.Enabled = true;
                comboBoxProgId.Enabled = true;
                comboBoxStId.Enabled = true;
            }

            if (((mode == Modes.MODIFY) || (mode == Modes.GRADE)) && (c != null))
            {
                comboBoxStId.SelectedValue = c[0].Cells["stId"].Value;
                comboBoxCId.SelectedValue = c[0].Cells["cId"].Value;
                comboBoxProgId.SelectedValue = c[0].Cells["progId"].Value;
                textBoxFinalGrade.Text = "" + c[0].Cells["finalGrade"].Value;
                assignInitial = new string[] { (string)c[0].Cells["stId"].Value, (string)c[0].Cells["cId"].Value, (string)c[0].Cells["progId"].Value };
            }
            if (mode == Modes.MODIFY)
            {
                textBoxFinalGrade.Enabled = false;
                comboBoxCId.Enabled = true;
                comboBoxProgId.Enabled = true;
                comboBoxStId.Enabled = true;
            }
            if (mode == Modes.GRADE)
            {
                Text = "Final Grade";
                textBoxFinalGrade.Enabled = true;
                textBoxFinalGrade.ReadOnly = false;
                comboBoxCId.Enabled = false;
                comboBoxProgId.Enabled = false;
                comboBoxStId.Enabled = false;
            }

            ShowDialog();
        }

        private void comboBoxStId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxStId.SelectedItem != null)
            {
                var a = from r in Data.Students.GetStudents().AsEnumerable()
                        where r.Field<string>("stId") == (string)comboBoxStId.SelectedValue
                        select new { Name = r.Field<string>("stName") };
                textBoxStName.Text = a.Single().Name;
            }
        }

        private void comboBoxCId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxCId.SelectedItem != null)
            {
                var a = from r in Data.Courses.GetCourses().AsEnumerable()
                        where r.Field<string>("cId") == (string)comboBoxCId.SelectedValue
                        select new { Name = r.Field<string>("cName") };
                textBoxCName.Text= a.Single().Name;
            }
        }

        private void comboBoxProgId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxProgId.SelectedItem != null)
            {
                var a = from r in Data.Programs.GetPrograms().AsEnumerable()
                        where r.Field<string>("progId") == (string)comboBoxProgId.SelectedValue
                        select new { Name = r.Field<string>("progName") };
                textBoxProgName.Text= a.Single().Name;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int r = -1;
            if (mode == Modes.ADD)
            {
                r = Data.Enrollments.InsertData(new string[] { (string)comboBoxStId.SelectedValue, (string)comboBoxCId.SelectedValue, (string)comboBoxProgId.SelectedValue });
            }
            if (mode == Modes.MODIFY)
            {
                List<string[]> lId = new List<string[]>();
                lId.Add(assignInitial);

                r = Data.Enrollments.InsertData(new string[] { (string)comboBoxStId.SelectedValue, (string)comboBoxCId.SelectedValue, (string)comboBoxProgId.SelectedValue });

                if (r == 0)
                {
                    r = Data.Enrollments.DeleteData(lId);
                }
            }
            if (mode == Modes.GRADE)
            {
                r = BusinessLayer.Enrollments.UpdateEnrollments(assignInitial, textBoxFinalGrade.Text);
            }

            if (r == 0) { Close(); }
        }
    }
}

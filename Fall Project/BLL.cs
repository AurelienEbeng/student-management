using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    internal class Programs
    {
        internal static int UpdatePrograms()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["programs"]
                              .GetChanges(DataRowState.Added | DataRowState.Modified);
            if (dt != null)
            {
                Regex regex = new Regex(@"^P\d{4}$");
                if (dt.AsEnumerable().Any(r => !regex.IsMatch(r.Field<string>("progId"))))
                {
                    Fall_Project.Form1.BLLMessage("Invalid program ID");
                    ds.RejectChanges();
                    return -1;
                }
                
            }

            return Data.Programs.UpdatePrograms();
            
        }

        
    }

    internal class Students
    {
        internal static int UpdateStudents()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["students"]
                              .GetChanges(DataRowState.Added | DataRowState.Modified);
            if (dt != null)
            {
                

                Regex regex = new Regex(@"^S\d{9}$");
                //check if student id exist
                if (dt.AsEnumerable().Any(r => !regex.IsMatch(r.Field<string>("stId"))))
                {
                    Fall_Project.Form1.BLLMessage("Invalid student ID");
                    ds.RejectChanges();
                    return -1;
                }

            }

            return Data.Students.UpdateStudents();
        }
        
    }


    internal class Courses
    {
        internal static int UpdateCourses()
        {
            DataSet ds = Data.DataTables.getDataSet();

            DataTable dt = ds.Tables["courses"]
                              .GetChanges(DataRowState.Added | DataRowState.Modified);
            if (dt != null)
            {
                Regex regex = new Regex(@"^C\d{6}$");
                if (dt.AsEnumerable().Any(r => !regex.IsMatch(r.Field<string>("progId"))))
                {
                    Fall_Project.Form1.BLLMessage("Invalid course ID");
                    ds.RejectChanges();
                    return -1;
                }

            }

            return Data.Courses.UpdateCourses();
        }

    }

    internal class Enrollments
    {
        internal static int UpdateEnrollments(string[] a, string ev)
        {
            Nullable<int> eval;
            
            Regex regex = new Regex(@"(^\d{1,2}$)|(^100$)");

            if (ev == "")
            {
                eval = null;
            }
            else if (regex.IsMatch(ev))
            {
                eval = Convert.ToInt32(ev);
            }
            else
            {
                Fall_Project.Form1.BLLMessage(
                          "Final grade must be an integer between 0 and 100"
                          );
                return -1;
            }

            return Data.Enrollments.UpdateFinalGrade(a, eval);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Fall_Project;

namespace Data
{
    internal class Connect
    {
        private static String College1enConnectionString = GetConnectString();

        internal static String ConnectionString { get => College1enConnectionString; }

        private static String GetConnectString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "College1en";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;
        }
    }// end of internal class Connect

    internal class DataTables
    {
        private static SqlDataAdapter adapterPrograms = InitAdapterPrograms();
        private static SqlDataAdapter adapterCourses = InitAdapterCourses();
        private static SqlDataAdapter adapterStudents = InitAdapterStudents();
        private static SqlDataAdapter adapterEnrollments = InitAdapterEnrollments();

        public static DataSet ds = InitDataSet();
        private static SqlDataAdapter InitAdapterPrograms()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * from programs order by progId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterCourses()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * from courses order by cId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterStudents()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * from students order by stId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterEnrollments()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                "SELECT * from enrollments order by stId",
                Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }



        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();

            loadPrograms(ds);
            loadCourses(ds);
            loadStudents(ds);
            loadEnrollments(ds);
            createFKCourses(ds);
            createFKStudents(ds);
            createFKEnrollments(ds);
            return ds;
        }

        private static void loadCourses(DataSet ds)
        {
            adapterCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterCourses.Fill(ds, "courses");
        }

        private static void loadPrograms(DataSet ds)
        {
            adapterPrograms.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterPrograms.Fill(ds, "programs");
        }

        private static void loadStudents(DataSet ds)
        {
            adapterStudents.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterStudents.Fill(ds, "students");
        }

        private static void loadEnrollments(DataSet ds)
        {
            adapterEnrollments.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapterEnrollments.Fill(ds, "enrollments");
        }


        private static void createFKCourses(DataSet ds)
        {
            ForeignKeyConstraint fk_courses_prog = new ForeignKeyConstraint("fk_courses_prog",
                new DataColumn[]
                {
                    ds.Tables["programs"].Columns["progId"],
                },
                new DataColumn[]
                {
                    ds.Tables["courses"].Columns["progId"],
                });
            fk_courses_prog.DeleteRule = Rule.Cascade;
            fk_courses_prog.UpdateRule = Rule.Cascade;
            ds.Tables["courses"].Constraints.Add(fk_courses_prog);
        }


        private static void createFKStudents(DataSet ds)
        {
            ForeignKeyConstraint fk_students_prog = new ForeignKeyConstraint("fk_enroll_stud",
                new DataColumn[]
                {
                    ds.Tables["programs"].Columns["progId"],
                },
                new DataColumn[]
                {
                    ds.Tables["students"].Columns["progId"],
                });
            fk_students_prog.DeleteRule = Rule.None;
            fk_students_prog.UpdateRule = Rule.Cascade;
            ds.Tables["students"].Constraints.Add(fk_students_prog);
        }


        private static void createFKEnrollments(DataSet ds)
        {
            ForeignKeyConstraint fk_enroll_stud = new ForeignKeyConstraint("fk_enroll_stud",
                new DataColumn[]
                {
                    ds.Tables["students"].Columns["stId"],
                },
                new DataColumn[]
                {
                    ds.Tables["enrollments"].Columns["stId"],
                });
            fk_enroll_stud.DeleteRule = Rule.Cascade;
            fk_enroll_stud.UpdateRule = Rule.Cascade;
            ds.Tables["enrollments"].Constraints.Add(fk_enroll_stud);




            ForeignKeyConstraint fk_enroll_courses = new ForeignKeyConstraint("fk_enroll_courses",
                new DataColumn[]
                {
                    ds.Tables["courses"].Columns["cId"],
                },
                new DataColumn[]
                {
                    ds.Tables["enrollments"].Columns["cId"],
                });
            fk_enroll_courses.DeleteRule = Rule.None;
            fk_enroll_courses.UpdateRule = Rule.None;
            ds.Tables["enrollments"].Constraints.Add(fk_enroll_courses);
        }



        internal static SqlDataAdapter getAdapterPrograms()
        {
            return adapterPrograms;
        }

        internal static SqlDataAdapter getAdapterCourses()
        {
            return adapterCourses;
        }

        internal static SqlDataAdapter getAdapterStudents()
        {
            return adapterStudents;
        }

        internal static SqlDataAdapter getAdapterEnrollments()
        {
            return adapterEnrollments;
        }



        internal static DataSet getDataSet()
        {
            return ds;
        }

        
    }// end of internal class DataTables


    internal class Programs
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterPrograms();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetPrograms()
        {
            return ds.Tables["programs"];
        }

        internal static int UpdatePrograms()
        {
            if (!ds.Tables["programs"].HasErrors)
            {
                return adapter.Update(ds.Tables["programs"]);
            }
            else
            {
                return -1;
            }
        }
    }//end of internal class Programs


    internal class Courses
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCourses();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetCourses()
        {
            return ds.Tables["courses"];
        }

        internal static int UpdateCourses()
        {
            if (!ds.Tables["courses"].HasErrors)
            {
                return adapter.Update(ds.Tables["courses"]);
            }
            else
            {
                return -1;
            }
        }
    }//end of internal class Courses





    internal class Students
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterStudents();
        private static DataSet ds = DataTables.getDataSet();

        internal static DataTable GetStudents()
        {
            return ds.Tables["students"];
        }

        internal static int UpdateStudents()
        {
            if (!ds.Tables["students"].HasErrors)
            {
                return adapter.Update(ds.Tables["students"]);
            }
            else
            {
                return -1;
            }
        }
    }//end of internal class Students




    internal class Enrollments
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterEnrollments();
        private static DataSet ds = DataTables.getDataSet();
        private static DataTable displayEnroll = null;

        internal static DataTable GetDisplayEnrollments()
        {
            ds.Tables["enrollments"].AcceptChanges();

            var query = (
                               from enroll in ds.Tables["enrollments"].AsEnumerable()
                               from students in ds.Tables["students"].AsEnumerable()
                               from courses in ds.Tables["courses"].AsEnumerable()
                               from programs in ds.Tables["programs"].AsEnumerable()
                               where enroll.Field<string>("stId") == students.Field<string>("stId")
                               where enroll.Field<string>("cId") == courses.Field<string>("cId")
                               where programs.Field<string>("progId") == students.Field<string>("progId")
                               select new
                               {
                                   stId = students.Field<string>("stid"),
                                   stName= students.Field<string>("stName"),
                                   cId = courses.Field<string>("cId"),
                                   cName = courses.Field<string>("cName"),
                                   finalGrade = enroll.Field<Nullable<int>>("finalGrade"),
                                   progId=programs.Field<string>("progId"),
                                   progName=programs.Field<string>("progName")
                               });
            
            //Creating enrollPK new table in memory
            DataTable result = new DataTable();
            result.Columns.Add("stId");
            result.Columns.Add("stName");
            result.Columns.Add("cId");
            result.Columns.Add("cName");
            result.Columns.Add("finalGrade");
            result.Columns.Add("progId");
            result.Columns.Add("progName");

            //populate table result
            foreach (var x in query)
            {
                object[] allFields = { x.stId, x.stName, x.cId, x.cName, x.finalGrade, x.progId, x.progName };
                result.Rows.Add(allFields);
            }
            displayEnroll = result;
            return displayEnroll;
        }// end of GetDisplayEnrollments





        internal static int InsertData(string[] enrollPK)
        {
            //verify if student already in course
            var test = (
                   from enroll in ds.Tables["enrollments"].AsEnumerable()
                   where enroll.Field<string>("stId") == enrollPK[0]
                   where enroll.Field<string>("cId") == enrollPK[1]
                   select enroll);
            if (test.Count() > 0)
            {
                Fall_Project.Form1.DALMessage("This enrollment already exists");
                return -1;
            }


            //if student progId== course progId, insert
            var stProg = (
                   from students in ds.Tables["students"].AsEnumerable()
                   where students.Field<string>("stId") == enrollPK[0]
                   select new
                   {
                       progId = students.Field<string>("progId")
                   });

            var cProg = (
                   from courses in ds.Tables["courses"].AsEnumerable()
                   where courses.Field<string>("cId") == enrollPK[1]
                   select new
                   {
                       progId = courses.Field<string>("progId")
                   });

            foreach(var x in stProg)
            {
                foreach(var y in cProg)
                {
                    if (x.progId != y.progId)
                    {
                        Form1.BLLMessage("The student can not be inserted in a course that is not in his program");
                        return -1;
                    }
                }

                if(x.progId != enrollPK[2])
                {
                    Form1.BLLMessage("The student is not in the selected program");
                    return -1;
                }
            }

            try
            {
                
                DataRow line = ds.Tables["enrollments"].NewRow();
                line.SetField("stId", enrollPK[0]);
                line.SetField("cId", enrollPK[1]);
                ds.Tables["enrollments"].Rows.Add(line);
                

                adapter.Update(ds.Tables["enrollments"]);
                

                if (displayEnroll != null)
                {
                    var query = (
                           from students in ds.Tables["students"].AsEnumerable()
                           from courses in ds.Tables["courses"].AsEnumerable()
                           from programs in ds.Tables["programs"].AsEnumerable()
                           where students.Field<string>("stId") == enrollPK[0]
                           where courses.Field<string>("cId") == enrollPK[1]
                           where programs.Field<string>("progId") == enrollPK[2]
                           select new
                           {
                               stId = students.Field<string>("stId"),
                               stName = students.Field<string>("stName"),
                               cId = courses.Field<string>("cId"),
                               cName = courses.Field<string>("cName"),
                               finalGrade = line.Field<Nullable<int>>("finalGrade"),
                               progId = programs.Field<string>("progId"),
                               progName = programs.Field<string>("progName")
                           });

                    

                    var r = query.Single(); 
                    displayEnroll.Rows.Add(new object[] { r.stId, r.stName, r.cId, r.cName, r.finalGrade,r.progId,r.progName });
                }
                return 0;
            }
            catch (Exception)
            {
                Fall_Project.Form1.DALMessage("Insertion / Update rejected");
                return -1;
            }
        }//end of insert data





        internal static int DeleteData(List<string[]> lId)
        {
            try
            {
                var lines = ds.Tables["enrollments"].AsEnumerable()
                                .Where(s =>
                                   lId.Any(x => (x[0] == s.Field<string>("stId") && x[1] == s.Field<string>("cId"))));
                

                foreach (var line in lines)
                {
                    line.Delete();
                }

                adapter.Update(ds.Tables["enrollments"]);

                if (displayEnroll != null)
                {
                    foreach (var p in lId)
                    {
                        var r = displayEnroll.AsEnumerable()
                                .Where(s => (s.Field<string>("stId") == p[0] && s.Field<string>("cId") == p[1]))
                                .Single();
                        displayEnroll.Rows.Remove(r);
                    }
                }
                return 0;
            }
            catch (Exception)
            {
                Fall_Project.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }//end of DeleteData





        internal static int UpdateFinalGrade(string[] a, Nullable<int> grade)
        {
            try
            {
                var line = ds.Tables["enrollments"].AsEnumerable()
                                    .Where(s =>
                                      (s.Field<string>("stId") == a[0] && s.Field<string>("cId") == a[1]))
                                    .Single();

                line.SetField("finalGrade", grade);

                adapter.Update(ds.Tables["enrollments"]);

                if (displayEnroll != null)
                {
                    var r = displayEnroll.AsEnumerable()
                                    .Where(s =>
                                      (s.Field<string>("stId") == a[0] && s.Field<string>("cId") == a[1]))
                                    .Single();
                    r.SetField("finalGrade", grade);
                }
                return 0;
            }
            catch (Exception)
            {
                Fall_Project.Form1.DALMessage("Update / Deletion rejected");
                return -1;
            }
        }//end of UpdateFinalGrade



       







    }//end of internal class Enrollments


}// end of namespace Data

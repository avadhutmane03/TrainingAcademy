using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TraiAca
{
    class StudDAL
    {
        public SqlDataReader GetStudent()
        {
            SqlDataReader reader =null;
            try{
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=DESKTOP-IM773OV\\SQLEXPRESS;Database=TrainingAcademy;trusted_connection=true";
            con.Open();

            SqlCommand cmd = new SqlCommand("GetStudData",con);
            cmd.CommandType = CommandType.StoredProcedure;
            reader = cmd.ExecuteReader();
            }
            catch(SqlException ex)
            {
                Console.WriteLine("Exception" + ex.Message);
            }
            return reader;
        }
        public SqlDataReader GetStudentUsingStudID(int Stud_ID)
        {
            SqlDataReader reader = null;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=DESKTOP-IM773OV\\SQLEXPRESS;Database=TrainingAcademy;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("GetStudentUsingStudID", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("Stud_ID", Stud_ID);
                cmd.Parameters.Add(param);

                reader = cmd.ExecuteReader();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return reader;
        }

        public int InsertStudent(int Batch_ID,int Stud_ID,string Stud_Name,string Stud_Loc,int Marks,string Result)
        {
             int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=DESKTOP-IM773OV\\SQLEXPRESS;Database=TrainingAcademy;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Batch_ID", Batch_ID);
                cmd.Parameters.AddWithValue("Stud_ID", Stud_ID);
                cmd.Parameters.AddWithValue("Stud_Name", Stud_Name);
                cmd.Parameters.AddWithValue("Stud_Loc", Stud_Loc);
                cmd.Parameters.AddWithValue("Marks", Marks);
                cmd.Parameters.AddWithValue("Result", Result);
                no = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return no;

        }

        public int UpdateStudent(int Batch_ID,int Stud_ID,string Stud_Name,string Stud_Loc,int Marks,string Result)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=Server=DESKTOP-IM773OV\\SQLEXPRESS;Database=TrainingAcademy;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Batch_ID", Batch_ID);
                cmd.Parameters.AddWithValue("Stud_ID", Stud_ID);
                cmd.Parameters.AddWithValue("Stud_Name", Stud_Name);
                cmd.Parameters.AddWithValue("Stud_Loc", Stud_Loc);
                cmd.Parameters.AddWithValue("Marks", Marks);
                cmd.Parameters.AddWithValue("Result", Result);
                no = cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return no;

        }

        public int DeleteStudent(int Stud_ID)
        {
            int no = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=DESKTOP-IM773OV\\SQLEXPRESS;Database=TrainingAcademy;trusted_connection=true";
                con.Open();

                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Stud_ID", Stud_ID);
                no = cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Exception " + ex.Message);
            }
            return no;

        }
    }

    class Student
    {
        StudDAL dal = new StudDAL();
        public int Batch_ID
        {
            get;
            set;
        }

        public int Stud_ID
        {
            get;
            set;
        }

        public string Stud_Name
        {
            get;
            set;
        }

        public string Stud_Loc
        {
            get;
            set;
        }
        public int Marks
        {
            get;
            set;
        }
        public string Result
        {
            get;
            set;
        }

        public void GetStudentData()
        {
            SqlDataReader reader = dal.GetStudent();
            Console.WriteLine("Batch_ID\tStud_ID\tStud_Name\tStud_Loc\tMarks\tResult");
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t" +reader[4] + "\t"+ reader[5] );
            }
        }

        public void GetStudentUsingStudID()
        {
            SqlDataReader reader = dal.GetStudentUsingStudID(Stud_ID);
            Console.WriteLine("Batch_ID\tStud_ID\tStud_Name\tStud_Loc\tMarks\tResult");
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t" + reader[3] + "\t"+ reader[4] + "\t"+ reader[5]);
            }
        }

        public void InsertStudent()
        {
            int no = dal.InsertStudent(Batch_ID, Stud_ID, Stud_Name, Stud_Loc, Marks, Result);
            if (no > 0)
            {
                Console.WriteLine("Data Inserted Successfully");
            }
        }

        public void UpdateStudent()
        {
            int no = dal.UpdateStudent(Batch_ID, Stud_ID, Stud_Name, Stud_Loc, Marks, Result);
            if (no > 0)
            {
                Console.WriteLine("Data Updated Successfully");
            }
        }

        public void DeleteStudent()
        {
            int no = dal.DeleteStudent(Stud_ID);

            if (no > 0)
            {
                Console.WriteLine("Data Deleted Successfully");
            }
        }



        internal void GetStudData()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            int choice;
            char ch;

            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.Print All Student Batches");
                Console.WriteLine("2.Print Student based on Stud_ID");
                Console.WriteLine("3.Insert Students");
                Console.WriteLine("4.Update Students");
                Console.WriteLine("5.Delete Students");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Student d = new Student();
                        d.GetStudentData();
                        break;

                    case 2:
                        Student d1 = new Student();
                        Console.WriteLine("Enter Stud_ID to view details");
                        d1.Stud_ID = Convert.ToInt32(Console.ReadLine());
                        d1.GetStudentUsingStudID();
                        break;

                    case 3:
                        Student d2 = new Student();
                        Console.WriteLine("Enter Student Details to Enter Batch_ID, Stud_ID, Stud_Name, Stud_Loc, Marks, Result");
                        d2.Batch_ID = Convert.ToInt32(Console.ReadLine());
                        d2.Stud_ID = Convert.ToInt32(Console.ReadLine());
                        d2.Stud_Name = Console.ReadLine();
                        d2.Stud_Loc = Console.ReadLine();
                        d2.Marks = Convert.ToInt32(Console.ReadLine());
                        d2.Result = Console.ReadLine();
                        d2.InsertStudent();
                        break;

                    case 4:
                        Student d3 = new Student();
                        Console.WriteLine("Enter Student Details to Enter Batch_ID, Stud_ID, Stud_Name, Stud_Loc, Marks, Result");
                        d3.Batch_ID = Convert.ToInt32(Console.ReadLine());
                        d3.Stud_ID = Convert.ToInt32(Console.ReadLine());
                        d3.Stud_Name = Console.ReadLine();
                        d3.Stud_Loc = Console.ReadLine();
                        d3.Marks = Convert.ToInt32(Console.ReadLine());
                        d3.Result = Console.ReadLine();
                        d3.UpdateStudent();
                        break;

                    case 5:
                        Student d4 = new Student();
                        Console.WriteLine("Enter Stud_ID to delete");
                        d4.Stud_ID = Convert.ToInt32(Console.ReadLine());
                        d4.DeleteStudent();
                        break;

                    default:
                        Console.WriteLine("Invalid Case");
                        break;
                }

                Console.WriteLine("Enter y r Y to continue");
                ch = Convert.ToChar(Console.ReadLine());

            }
            while (ch == 'Y' || ch == 'y');
            Console.ReadLine();
        }
    }
}


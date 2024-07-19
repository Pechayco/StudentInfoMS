using StudentInfoModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoDL
{
    internal class SqlDBData
    {
        string connection = "Data Source =DESKTOP-7KK6NG5\\SQLEXPRESS; Initial Catalog = StudentInfoManagement; Integrated Security = True;";

        SqlConnection sqlConnection;

        public SqlDBData()
        {
            this.sqlConnection = new SqlConnection(connection);
        }
        public List<StudentInfo> GetStudent()
        {
            string SELECT = "Select * FROM Student";

            SqlCommand selcom = new SqlCommand(SELECT, sqlConnection);

            sqlConnection.Open();
            List<StudentInfo> stud = new List<StudentInfo>();

            SqlDataReader read = selcom.ExecuteReader();

            while (read.Read())
            {
                string studentID = read["StudentID"].ToString();
                string name = read["Name"].ToString();
                string email = read["Email"].ToString();
                string phonenum = read["phonenum"].ToString() ;
                string address = read["Address"].ToString();

                StudentInfo readStudent = new StudentInfo();
                readStudent.s_studentID = studentID;
                readStudent.s_name = name;
                readStudent.s_email = email;
                readStudent.s_phonenum = phonenum;
                readStudent.s_address = address;

                stud.Add(readStudent);

            }
            sqlConnection.Close();

            return stud;
        }
        public int AddStudent(string studentID, string name, string email, string phonenum, string address)
        {
            int success;

            string INSERT = "INSERT INTO Student VALUES (@StudentID, @Name, @Email, @Phone Number, @Address)";
            
            SqlCommand incom = new SqlCommand(INSERT, sqlConnection);

            incom.Parameters.AddWithValue("@StudentID", studentID);
            incom.Parameters.AddWithValue("@Name", name);
            incom.Parameters.AddWithValue("@Email", email);
            incom.Parameters.AddWithValue("@Phone Number", phonenum);
            incom.Parameters.AddWithValue("@Address", address);
            sqlConnection.Close();

            success = incom.ExecuteNonQuery();

            sqlConnection.Close();
            
            return success;

        }

        public int UpdateStudent(string studentID, string name, string email, string phonenum, string address)
        {
            int success;

            string UPDATE = $"UPDATE Student SET Name = @Name, Email = @Email, Phone Number = @Phone Number, Address = @Address WHERE StduentID = @StudentID";


            SqlCommand upcom = new SqlCommand(UPDATE, sqlConnection);

            upcom.Parameters.AddWithValue("@Student ID", studentID);
            upcom.Parameters.AddWithValue("@Name", name);
            upcom.Parameters.AddWithValue("@Email", email);
            upcom.Parameters.AddWithValue("@Phone Number", phonenum);
            upcom.Parameters.AddWithValue("@Address", address);
            sqlConnection.Close();

            success = upcom.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteStudent(string studentID)
        {
            int success;

            string DELETE = $"DELETE FROM Student WHERE StudentID = @StudentID";
            SqlCommand delcom = new SqlCommand(DELETE, sqlConnection);
            sqlConnection.Open();

            delcom.Parameters.AddWithValue("@StudentID", studentID );

            success = delcom.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}

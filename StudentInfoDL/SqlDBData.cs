using StudentInfoModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentInfoDL
{
    public class SqlDBData
    {
        string connection = "Data Source =DESKTOP-7KK6NG5\\SQLEXPRESS; Initial Catalog = StudentInfoManagement; Integrated Security = True;";
        //static string connection = "Server=tcp:20.205.142.95,1433; Database=StudentInfoManagement; User Id=sa; Password=Pechayco019!";

        SqlConnection sqlConnection;

        public SqlDBData()
        {
            sqlConnection = new SqlConnection(connection);
        }


        public List<StudentInfo> GetStudent()
        {
            string SELECT = "SELECT * FROM Student";

            SqlCommand selcom = new SqlCommand(SELECT, sqlConnection);

            sqlConnection.Open();
            List<StudentInfo> stud = new List<StudentInfo>();

            SqlDataReader re = selcom.ExecuteReader();

            while (re.Read())
            {
                string studentID = re["StudentID"].ToString();
                string name = re["Name"].ToString();
                string email = re["Email"].ToString();
                string phonenum = re["phonenum"].ToString();
                string address = re["Address"].ToString();

                StudentInfo read = new StudentInfo();
                read.s_studentID = studentID;
                read.s_name = name;
                read.s_email = email;
                read.s_phonenum = phonenum;
                read.s_address = address;

                stud.Add(read);
                
            }
            sqlConnection.Close();

            return stud;
        }

        public int AddStudent(string studentID, string name, string email, string phonenum, string address)
        {
            int success;

            string INSERT = "INSERT INTO Student VALUES(@StudentID, @Name, @Email,@PhoneNumber, @Address)";

            SqlCommand incom = new SqlCommand(INSERT, sqlConnection);

            incom.Parameters.AddWithValue("@StudentID", studentID);
            incom.Parameters.AddWithValue("@Name", name);
            incom.Parameters.AddWithValue("@Email", email);
            incom.Parameters.AddWithValue("@PhoneNumber", phonenum);
            incom.Parameters.AddWithValue("@Address", address);
            sqlConnection.Open();

            success = incom.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
        public int UpdateStudent(string studentID, string name, string email, string phonenum, string address)
        {
            int success;

            string UPDATE = $"UPDATE Student SET Name = @Name, Email = @Email, @PhoneNumber = phonenum, Address = @Address WHERE StudentID = @StudentID";

            SqlCommand upcom = new SqlCommand(UPDATE, sqlConnection);


            upcom.Parameters.AddWithValue("@StudentID", studentID);
            upcom.Parameters.AddWithValue("@Name", name);
            upcom.Parameters.AddWithValue("@Email", email);
            upcom.Parameters.AddWithValue("@PhoneNumber", phonenum);
            upcom.Parameters.AddWithValue("@Address", address);
            sqlConnection.Open();

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

            delcom.Parameters.AddWithValue("@StudentID", studentID);

            success = delcom.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}
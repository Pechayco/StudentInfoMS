using System.Data;
using StudentInfoModel;

namespace StudentInfoDL
{
    public class StudentOperator
    {
        List<StudentInfo> infos;
        SqlDBData sqlData;

        public StudentOperator()
        {
            infos = new List<StudentInfo>();
            sqlData = new SqlDBData();
        }

        public List<StudentInfo> GetStudent()
        {
            infos = sqlData.GetStudent();
            return infos;
        }

        public int AddStudent(StudentInfo infos)
        {
            return sqlData.AddStudent(infos.s_studentID, infos.s_name, infos.s_email, infos.s_phonenum, infos.s_address);
        }
        public int UpdateStudent(StudentInfo infos)
        {
            return sqlData.UpdateStudent(infos.s_studentID, infos.s_name, infos.s_email, infos.s_phonenum, infos.s_address);
        }
        public int DeleteStudent(StudentInfo infos)
        {
            return sqlData.DeleteStudent(infos.s_studentID);
        }

    }
}


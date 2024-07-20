using StudentInfoDL;
using StudentInfoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoBS
{
    public class StudentTransactionServices
    {
        StudentValidationServices sc = new StudentValidationServices();
        StudentData so = new StudentData();

        public bool CreateStudent (StudentInfo infos)
        {
            bool st = false;

            if(sc.IsloggedIn(infos.s_studentID))
            {
                st = so.AddStudent(infos) > 0;
            }
            return st;
        }
        public bool CreateStudent(string studentID, string name, string email, string phonenum,string address)
        {
            StudentInfo si = new StudentInfo { s_studentID = studentID, s_name = name, s_email = email, s_phonenum = phonenum, s_address = address };
            
            return CreateStudent(si);
        }

        public bool UpdateStudent (StudentInfo infos) {
        
            bool st = false;

            if(sc.IsloggedIn (infos.s_studentID))
            {
                st = so.UpdateStudent(infos) > 0;
            }
            return st;
        }
        public bool UpdateStudent(string studentID, string name, string email, string phonenum, string address)
        {
            StudentInfo si = new StudentInfo { s_studentID = studentID, s_name = name, s_email = email, s_phonenum = phonenum, s_address = address };

            return UpdateStudent(si);
        }
        public bool DeleteStudent(StudentInfo infos)
        {
            bool st = false;

            if (sc.IsloggedIn(infos.s_studentID))
            {
                st = so.DeleteStudent(infos) > 0;
            }
            return st;
        }
    }
}

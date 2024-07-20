using StudentInfoDL;
using StudentInfoModel;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace StudentInfoBS
{
    public class StudentGetServices
    {
       public List<StudentInfo> GetStudentInfos()
        {
            StudentData studentOperator = new StudentData();
            return studentOperator.GetStudent();
        }
        public StudentInfo GetstudentID (string s_studentID)
        {
            StudentInfo si = new StudentInfo();

            foreach(var stud in GetStudentInfos())
            {
                if(stud.s_studentID == s_studentID)
                {
                    si =stud;
                }
            }
            return si;
        }

        public StudentInfo GetName (string s_name)
        {
            StudentInfo si = new StudentInfo();

            foreach (var stud in GetStudentInfos())
            {
                if (stud.s_name == s_name)
                {
                    si = stud;
                }
            }
            return si;
        }
    }
    }


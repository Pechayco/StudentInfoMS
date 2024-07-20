using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInfoDL;
using StudentInfoModel;

namespace StudentInfoBS
{
    internal class StudentValidationServices
    {
        StudentGetServices gs = new StudentGetServices();

        public bool IsLoggedIn (string s_studentID)
        {
            bool result = gs.GetstudentID(s_studentID) != null;
            return result;
        }
        public bool IsloggedIn (string s_name)
        {
            bool result = gs.GetName(s_name) != null;
            return result;
        }
    }
}

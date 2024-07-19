using Microsoft.AspNetCore.Mvc;
using StudentInfoBS;
using StudentInfoDL;
using StudentInfoModel;


namespace StudentInfoManagement.API.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class UserController : Controller
    {
        GetService _userGetService;
        RSI _rSI;

        public UserController()
        {
            _userGetService = new GetService();
            _rSI = new RSI();
        }

        [HttpGet]
        public IEnumerable<StudentInfoMS.API.User> GetUsers()
        {
            var activeusers = _userGetService.GetStudentInfos();

            List<StudentInfoMS.API.User> users = new List<StudentInfoMS.API.User>(1);

            foreach (var item in activeusers)
            {
                users.Add(new StudentInfoMS.API.User { s_studentID = item.s_studentID, s_name = item.s_name, s_email = item.s_email, s_phonenum = item.s_phonenum, s_address = item.s_address });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(StudentInfoMS.API.User request)
        {
            var result = _rSI.CreateStudent(request.s_studentID, request.s_name, request.s_email, request.s_phonenum, request.s_address);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateStudent(StudentInfoMS.API.User request)
        {
            var result = _rSI.UpdateStudent(request.s_studentID, request.s_name, request.s_email, request.s_phonenum, request.s_address);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteCar(StudentInfoMS.API.User request)
        {
            var deleteStudent = new StudentInfoModel.StudentInfo
            {
                s_studentID = request.s_studentID
            };

            var result = _rSI.DeleteStudent(deleteStudent);

            return new JsonResult(result);
        }

    }

}
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
        StudentGetServices _userGetService;
        StudentTransactionServices _studentTransactionServices;

        public UserController()
        {
            _userGetService = new StudentGetServices();
            _studentTransactionServices = new StudentTransactionServices();
        }

        [HttpGet]
        public IEnumerable<StudentInfoMS.API.Student> GetUsers()
        {
            var activeusers = _userGetService.GetStudentInfos();

            List<StudentInfoMS.API.Student> users = new List<StudentInfoMS.API.Student>(1);

            foreach (var item in activeusers)
            {
                users.Add(new StudentInfoMS.API.Student { s_studentID = item.s_studentID, s_name = item.s_name, s_email = item.s_email, s_phonenum = item.s_phonenum, s_address = item.s_address });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(StudentInfoMS.API.Student request)
        {
            var result = _studentTransactionServices.CreateStudent(request.s_studentID, request.s_name, request.s_email, request.s_phonenum, request.s_address);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateStudent(StudentInfoMS.API.Student request)
        {
            var result = _studentTransactionServices.UpdateStudent(request.s_studentID, request.s_name, request.s_email, request.s_phonenum, request.s_address);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteCar(StudentInfoMS.API.Student request)
        {
            var deleteStudent = new StudentInfoModel.StudentInfo
            {
                s_studentID = request.s_studentID
            };

            var result = _studentTransactionServices.DeleteStudent(deleteStudent);

            return new JsonResult(result);
        }

    }

}
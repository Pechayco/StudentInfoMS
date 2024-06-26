using StudentInfoBS;
using StudentInfoModel;
using StudentInfoDL;
using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("======================");
            Console.WriteLine("Student Information Management System");
            Console.WriteLine("======================");

            GetService gs = new GetService();

            var infos = gs.GetStudentInfos();

            foreach (var item in infos)
            {
                Console.WriteLine($"Student ID: {item.s_studentID}");
                Console.WriteLine($"Student Name: {item.s_name}");
                Console.WriteLine($"Email Address: {item.s_email}");
                Console.WriteLine($"Phone Number: {item.s_phonenum}");
                Console.WriteLine($"Address: {item.s_address}");
                Console.WriteLine("=======================");

            }

        }
    }
}

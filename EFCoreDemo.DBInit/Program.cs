using System;
using System.Linq;

namespace EFCoreDemo.DBInit
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFCoreDemoDbContext())
            {
                var students = ctx.Student.ToList();

                foreach (var item in students)
                {
                    Console.WriteLine(string.Format("Id:{0},first_name:{1},last_name:{2}", item.Id, item.FirstName, item.LastName));
                }
            }

            Console.WriteLine("OK!");
            Console.ReadKey();
        }
    }
}

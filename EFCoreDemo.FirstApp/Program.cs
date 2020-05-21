using System;

namespace EFCoreDemo.FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //第一个demo
            using (var ctx= new EFCoreDemoDbContext())
            {
                var student = new Student 
                {
                    Name= "zhangsan"
                };

                ctx.Student.Add(student);
                ctx.SaveChanges();
            }

            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}

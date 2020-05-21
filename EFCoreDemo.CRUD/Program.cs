using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreDemo.CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            //1，新增
            //Add();

            //2，查询
            //var students = Get();

            //3，更新
            //Update();

            //4，删除
            Delete();

            Console.WriteLine("OK!");
            Console.ReadKey();
        }

        static void Delete()
        {
            using (var ctx = new EFCoreDemoDbContext())
            {
                var student = ctx.Student.FirstOrDefault(p => p.FirstName == "li");
                if (student != null)
                {
                    ctx.Student.Remove(student);//或者：ctx.Remove<Student>(student);
                    ctx.SaveChanges();
                }
            }
        }

        static void Update()
        {
            using (var ctx = new EFCoreDemoDbContext())
            {
                var student = ctx.Student.First(p => p.FirstName == "zhang");
                if (student != null)
                {
                    student.LastName = "san_new";
                    ctx.SaveChanges();
                }
            }
        }

        static List<Student> Get()
        {
            using (var ctx = new EFCoreDemoDbContext())
            {
                return ctx.Student.Where(p => p.FirstName == "zhang").ToList();
            }
        }

        static void Add()
        {
            using (var ctx = new EFCoreDemoDbContext())
            {
                var student = new Student
                {
                    FirstName = "li",
                    LastName = "si"
                };

                ctx.Student.Add(student);//或：ctx.Add<Student>(student);
                ctx.SaveChanges();
            }
        }
    }
}

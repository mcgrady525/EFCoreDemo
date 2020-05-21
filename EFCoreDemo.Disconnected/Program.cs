using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Disconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            /*****Disconnected Scenario（离线模式）*****/
            //1，Attach an entity to DbContext with an appropriate EntityState e.g. Added, Modified, or Deleted
            //2，Call SaveChanges() method

            //新增
            //Add();

            //更新
            //Update();

            //删除
            Delete();

            Console.WriteLine("OK!");
            Console.ReadKey();
        }

        static void Delete()
        {
            var student = new Student 
            {
                Id= 2
            };

            using (var ctx= new EFCoreDemoDbContext())
            {
                ctx.Student.Remove(student);

                //or the followings are also valid
                //ctx.Remove<Student>(student);
                //ctx.Attach<Student>(student).State = EntityState.Deleted;
                //ctx.Entry<Student>(student).State = EntityState.Deleted;

                ctx.SaveChanges();
            }
        }

        static void Update()
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "zhang",
                LastName = "san_new"
            };

            using (var ctx = new EFCoreDemoDbContext())
            {
                ctx.Student.Update(student);

                //or the followings are also valid
                //ctx.Update<Student>(student);
                //ctx.Student.Attach(student).State = EntityState.Modified;
                //ctx.Entry<Student>(student).State = EntityState.Modified;


                ctx.SaveChanges();
            }

        }

        static void Add()
        {
            var student = new Student
            {
                FirstName = "xi",
                LastName = "jp"
            };
            using (var ctx = new EFCoreDemoDbContext())
            {
                ctx.Attach<Student>(student);

                //or
                //ctx.Entry<Student>(student).State = EntityState.Added;

                //or
                //ctx.Student.Add(student);

                //or
                //ctx.Add<Student>(student);

                ctx.SaveChanges();
            }
        }
    }
}

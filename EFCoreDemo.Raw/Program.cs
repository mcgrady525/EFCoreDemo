using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreDemo.Raw
{
    class Program
    {
        static void Main(string[] args)
        {
            //1，执行原生SQL查询
            //ExecuteRawSQL();

            //2，执行存储过程
            ExecuteStoredProcedure();

            Console.WriteLine("OK!");
            Console.ReadKey();
        }

        static void ExecuteStoredProcedure()
        {
            //方法一：DbSet<TEntity>.FromSql()，适用于查询
            //方法二：DbContext.Database.ExecuteSqlCommand()，适用于修改

            //查询
            using (var ctx = new EFCoreDemoDbContext())
            {
                var firstName = "xi";
                var students = ctx.Student.FromSqlInterpolated($"exec sp_GetStudents {firstName}").ToList();
            }

            //修改
            using (var ctx = new EFCoreDemoDbContext())
            {
                var firstName = "xi";
                ctx.Database.ExecuteSqlInterpolated($"exec sp_UpdateStudents {firstName}");
            }

        }

        static void ExecuteRawSQL()
        {
            using (var ctx = new EFCoreDemoDbContext())
            {
                var students = ctx.Student.FromSqlRaw("SELECT * FROM dbo.t_student WHERE first_name='xi'").ToList();

                var firstName = "xi";
                var students2 = ctx.Student.FromSqlInterpolated($"SELECT * FROM dbo.t_student WHERE first_name={firstName}").ToList();
            }
        }
    }
}

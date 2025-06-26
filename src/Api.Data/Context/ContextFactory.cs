using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para Criar as Migrações
            var connectionString = "Server=localhost;Port=3306;DataBase=CourseAPI2;Uid=root;Pwd=DevSysth2025@";
            //var connectionString = "Server=.\\SQLEXPRESS2017;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))
            );
            //optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}

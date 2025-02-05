﻿using Microsoft.EntityFrameworkCore;

namespace CookBook.DAL.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory<CookBookDbContext>
    {
        private readonly string _connectionString;
        private readonly bool _seedTestingData;

        public SqlServerDbContextFactory(string connectionString, bool seedTestingData = false)
        {
            _connectionString = connectionString;
            _seedTestingData = seedTestingData;
        }

        public CookBookDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CookBookDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            //optionsBuilder.LogTo(System.Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
            //optionsBuilder.EnableSensitiveDataLogging();

            return new CookBookDbContext(optionsBuilder.Options, _seedTestingData);
        }
    }
}
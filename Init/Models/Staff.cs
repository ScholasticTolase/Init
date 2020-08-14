using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Added
using System.Data.Entity;

namespace Init.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    public class StaffDbContext : DbContext
    {
        //Constructor with the Cnnection String name
        public StaffDbContext() : base("StaffDC") {}

        // Creating a DBset 
        public DbSet<Staff> Staffs { get;set; }
    }
}
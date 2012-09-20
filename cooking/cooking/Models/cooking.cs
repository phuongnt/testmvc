using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace cooking.Models
{
    public class Cook
    {
        public int CookID { get; set; }

        [Required(ErrorMessage = "Please enter a Dinner Title")]
        [StringLength(20, ErrorMessage = "Title is too long")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the Date of the Dinner")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please enter the location of the Dinner")]
        [StringLength(30, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string HostedBy { get; set; }

        public virtual ICollection<RSVP> RSVPs { get; set; }
    }

    public class RSVP
    {
        public int RsvpID { get; set; }
        public int DinnerID { get; set; }
        public string AttendeeEmail { get; set; }
        public virtual Cook Dinner { get; set; }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public virtual ClassRoom Class { get; set; }

        //public int ClassID { get; set; }        
    }
    public class ClassRoom
    {
        public int ClassRoomID { get; set; }
        public string ClassName { get; set; }
        public string Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }

    // 
    // Our EF Code First Context class.  This class handles persistence and
    // interactions with the database.  This could have also been implemented
    // in a separate class library.
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ParentID { get; set; }
    }
    public class Product
    {
        public int ProductID{get;set;}
        public string ProductName { get; set; }
        public string Description { get; set; }
        
    }
    public class Cookingdb : DbContext
    {
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<RSVP> RSVPs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassRoom> Classs { get; set; }
    }
}
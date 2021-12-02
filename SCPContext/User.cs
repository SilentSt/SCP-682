using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SCPData
{
    public class User
    {
        [Key]
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public bool Admin { get; set; }
        public string FamilyID { get; set; }
        //public ICollection<Point> Points { get; set; }
    }
    public class Point
    {
        [Key]
        public int ID { get; set; }
        public string UserPhone { get; set; }
        //public virtual User User { get; set; }
        public int Battery { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Time { get; set; }
    }
    public class SafeZone
    {
        [Key]
        public int ZoneId { get; set; }
        public string FamilyID { get; set; }
        public string Zone { get; set; }
        public string Color { get; set; }
    }
}

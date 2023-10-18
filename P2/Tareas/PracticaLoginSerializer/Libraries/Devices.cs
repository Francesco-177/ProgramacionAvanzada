using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraries{
    public class Device{
        public int ID { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public int? YearEntered { get; set; }
        public string? BrandName { get; set; }
        public bool? Category { get; set; }
        public double? InitialPrice { get; set; }
        public double? ActualPrice { get; set; }
        public Device(){} 
        public Device(int id, string model, string description, int yearEntered, string brandName, bool category, double initialPrice, double actualPrice){
            ID = id;
            Model = model;
            Description = description;
            YearEntered = yearEntered;
            BrandName = brandName;
            Category = category;
            InitialPrice = initialPrice;
            ActualPrice = actualPrice;
        }
    }
}
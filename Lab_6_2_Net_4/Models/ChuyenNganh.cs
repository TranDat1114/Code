﻿using System.ComponentModel.DataAnnotations;

namespace Lab_6_2_Net_4.Models
{
    public class ChuyenNganh
    {
        public string Image_string { get; set; }
        [Display(Name = "Subtring")]
        public string Subname_string { get; set; }

        public ChuyenNganh()
        {

        }
        public ChuyenNganh(string image_string, string subname_string)
        {
            Image_string = image_string;
            Subname_string = subname_string;
        }
    }

}

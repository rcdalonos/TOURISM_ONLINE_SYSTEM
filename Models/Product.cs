using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


using System.Web.Mvc;
using ADO_EXAMPLE.DAL; //DAL MEANING DATA ACCESS LAYER
using ADO_EXAMPLE.Models;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using PagedList.Mvc;
using PagedList;

namespace ADO_EXAMPLE.Models
{
    public class Product
    {
        [Key]
        public int ProductID{ get; set; }
        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [DisplayName("Quantity")]
        [Required]
        public int Qty { get; set; }
        public string Remarks { get; set; }

        [DisplayName("Gender")]
        [Required]
        public int GenderId { get; set; }

        public List<SelectList>ListofGender { get; set; }
        public List<SelectList> getGenderList { get; set; }
    }
}
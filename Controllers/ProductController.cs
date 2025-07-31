using System;
using System.Collections.Generic;
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

namespace ADO_EXAMPLE.Controllers
{
    public class ProductController : Controller
    {
        Product_DAL _productDAL = new Product_DAL();
        // GET: Product

        //[HttpPost]
        public ActionResult Index(string SearchString, int? i)
        {




            //List<Customer> customers = this.Context.SearchCustomers(customerName).ToList();
            //var productList = _productDAL.search_product_name(SearchString).ToList();
            if (SearchString == null)
            {
                SearchString = "";
            }
             List <Product> productList = _productDAL.search_product_name(SearchString).ToList();
            
            //return View(productList.ToPagedList(i ?? 1, 10));
            return View(productList.ToPagedList(i ?? 1,10));
            //productList.ToPagedList()
        }


        //public ActionResult Index()
        //{
        //    var productList = _productDAL.GetAllProducts();

        //    if(productList.Count == 0)
        //    {
        //        TempData["InfoMessage"] = "Currently No Available Products in the Database.";
        //    }
            
        //    return View(productList);
        //}

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //[HttpGet]
        public ActionResult Create()
        {
            var model = new Product();
            model.ListofGender = new List<SelectList>();

            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection connection = new SqlConnection(constring);
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "sp_PopulateGender";
            connection.Open();
            SqlDataAdapter sqlDA = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            ViewBag.GenderList = ds.Tables[0];

            List<SelectListItem> getGenderList = new List<SelectListItem>();
            foreach (System.Data.DataRow dr in ViewBag.GenderList.Rows)
            {
                //getGenderList.Add(new SelectListItem { Text = @dr["Gender"].ToString(), Value = @dr["GenderId"].ToString() });
                //model.ListofGender.Add(new SelectListItem { Text = dr["Gender"].ToString(), Value = @dr["GenderId"].ToString() });
            }
            ViewBag.GenderListing = getGenderList;
            //ViewBag.GenderListing = new SelectList(getGenderList, "GenderId", "Gender");
            connection.Close();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            bool IsInserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted = _productDAL.InsertProduct(product);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Product Details saved Successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to save the Product Details.";
                    }

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

       
        public ActionResult Edit(int id)
        {
            var products = _productDAL.GetProductsByID(id).FirstOrDefault();
            if (products == null)
            {
                TempData["InfoMessage"] = "Product not available with ID " + id.ToString();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // POST: Product/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult UpdateProduct(Product product)
        {
            try {
                if (ModelState.IsValid)
                {
                    bool IsUpdated = _productDAL.UpdateProduct(product);
                    if(IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Product details updated successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unable to update the product details!";

                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            return View();
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

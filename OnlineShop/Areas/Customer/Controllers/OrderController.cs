using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Models;
using OnlineShop.Utility;
using OnlineShop.Services;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(Order objOrder)
        {
            objOrder.OrderNo = GetOrderNo();
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");

            List<string[]> OrderDetailsList = new List<string[]>();
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.PorductId = product.Id;
                    objOrder.OrderDetails.Add(orderDetails);

                    OrderDetailsList.Add(new string[] { objOrder.OrderNo, Convert.ToString(product.Id) });
                }
            }

            string result = string.Empty;
            result = _orderServices.InsertOrder(objOrder);

            // Convert to DataTable.
            DataTable table = ConvertListToDataTable(OrderDetailsList);
            result = _orderServices.InsertOrderDetails(table);

            HttpContext.Session.Set("products", new List<Product>());

            TempData["AlertMessage"] = "Order Placed Successfully!";
            return RedirectToAction("Index","Home");

            return View();
        }


        public string GetOrderNo()
        {
            Order objOrder = new Order();
            int rowCount = _orderServices.GetOrderCount(objOrder) + 1;
            return rowCount.ToString("000");
        }

        static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrugManagementAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace DrugManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private static List<Supplier> supplierList = new List<Supplier>()
        {
             new Supplier
             {
                 Name= "Sup1",  
                 SupplierId=1455,
                 Address="mangalore",
                 Company="mangalore suppliers"
             },
             new Supplier
             {
                 Name= "canara suppliers",
                 SupplierId=1788,
                 Address="mangalore",
                 Company="Karnataka suppliers"
             }
        };
        [HttpGet]
        public List<Supplier> GetSuppliers()
        {

            return supplierList;
        }
        [HttpPost]
        public void AddSupplier(Supplier supplier)
        {
            supplierList.Add(supplier);
        }
        [HttpDelete]
        public void DeleteSupplier(int supplierId)
        {
            var supplier = supplierList.Where(s => s.SupplierId == supplierId).FirstOrDefault();
            supplierList.Remove(supplier);
        }
        [HttpGet("{supplierId:int}")]
        public Supplier GetSupplierById(int supplierId)
        {
            var supplier = supplierList.Where(d => d.SupplierId == supplierId).FirstOrDefault();
            return supplier;
        }
    }
}

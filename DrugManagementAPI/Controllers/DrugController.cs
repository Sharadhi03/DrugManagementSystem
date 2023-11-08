using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrugManagementAPI.Models;
using DrugManagement.Data.Entities;
using DrugManagement.Data.Repositories;

namespace DrugManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        public DrugRepository DrugRepository {  get; set; }
        public DrugController() 
        { 
            this.DrugRepository = new DrugRepository();
        }
        [HttpGet]
        public List<TblDrug> GetAllDrugs()
        {
             return this.DrugRepository.GetAllDrugs();
        }
        [HttpPost]
        public void AddDrug(Drug drug)
        {
            TblDrug tbldrug = new TblDrug();
            tbldrug.SupplierId = 1;
            tbldrug.ExpiryDate = drug.ExpiredDate;
            tbldrug.SerialNumber= drug.SerialNumber;
            tbldrug.Name = drug.Name;
            this.DrugRepository.AddDrug(tbldrug);
        }
        [HttpDelete]
        public void DeleteDrug(int DrugId)
        {
            this.DrugRepository.DeleteDrug(DrugId);
        }
        [HttpGet("{DrugId:int}")]
        public Drug GetDrugById(int DrugId,int SupplierId)
        {
            //var drugBy = Druglist.Where(d => d.Id == DrugId).FirstOrDefault();
            return new Drug();
        }
    }
}

    


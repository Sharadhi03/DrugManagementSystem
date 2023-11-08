using DrugManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugManagement.Data.Repositories
{
    public class DrugRepository
    {
        DmsContext DmsDbContext { get; set; }
        public DrugRepository()
        {
            this.DmsDbContext = new DmsContext();
        }
        public List<TblDrug> GetAllDrugs()
        {
            return this.DmsDbContext.TblDrugs.ToList();
        }
        public void AddDrug(TblDrug drug)
        {
            this.DmsDbContext.TblDrugs.Add(drug);
            this.DmsDbContext.SaveChanges();
        }
        public void DeleteDrug(int DrugId) 
        { 
            var drugNeedsTobeDeleted =this.DmsDbContext.TblDrugs.Where(d =>d.Id==DrugId).FirstOrDefault();
            if(drugNeedsTobeDeleted != null)
            {
                this.DmsDbContext.Remove(drugNeedsTobeDeleted);
                this.DmsDbContext.SaveChanges();
            }
        }
    }
}

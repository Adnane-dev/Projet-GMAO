using GMAO.Models.Connection; // Assuming this namespace contains GMAOContext
using GMAO.Models.Entities;
using System.Collections.Generic; // Using the correct namespace for ICollection
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/* public static void AddStock(Stocks stock)
 {
     using (var context = new GMAOContext())
     {
         // Assuming the model is configured correctly for EF
         var Stock = new Stocks { Produit = "d", Quantite = 2, PrixUnitaire = 200 };
         context.Stocks.Add(stock);
         context.Stocks.Add(Stock);
         context.SaveChanges();
     }
 }*/


namespace GMAO.Models.DAL
{
    public class DAL_Stocks
    {
        internal static void AddStock(Stocks stocks)
        {
            throw new NotImplementedException();
        }
/*
        public  void AddStock(Stocks stock)
        {
            using (var context = new GMAOContext())
            {
                // Assuming the model is configured correctly for EF
                var Stock = new Stocks { Produit = "d", Quantite = 2, PrixUnitaire = 200 };
                context.Stocks.Add(stock);
                context.Stocks.Add(Stock);
                context.SaveChanges();
            }
*/
        public class StocksRepository
        {
            private readonly GMAOContext _dbContext;

            public StocksRepository()
            {
                _dbContext = new GMAOContext();
            }



            // Create
            public  void AddStock(Stocks stock)
            {
                _dbContext.Stocks.Add(stock);
                _dbContext.SaveChanges();
            }

            // Read
            public List<Stocks> GetAllStocks()
            {
                return _dbContext.Stocks.ToList();
            }

            public Stocks GetStockById(int id)
            {
                return _dbContext.Stocks.Find(id);
            }

            // Update
            public void UpdateStock(Stocks stock)
            {
                _dbContext.Entry(stock).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }

            // Delete
            public void DeleteStock(int id)
            {
                var stock = _dbContext.Stocks.Find(id);
                _dbContext.Stocks.Remove(stock);
                _dbContext.SaveChanges();
            }
        }
    }
}
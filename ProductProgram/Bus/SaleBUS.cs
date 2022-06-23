using ProductProgram.DAO;
using ProductProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProgram.Bus
{
    internal class SaleBUS
    {
        public void SaveSale(SaleModel product)
        {
            SaleDAO exec = new SaleDAO();

            exec.ExecuteSaleInsert(product);
        }
    }
}

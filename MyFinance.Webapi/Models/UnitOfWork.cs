using MyFinance.Webapi.Models.Domains;
using MyFinance.Webapi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Webapi.Models
{
    public class UnitOfWork
    {
        private readonly MyFinancesContext _context;

        public UnitOfWork(MyFinancesContext context)
        {
            _context = context;
            Operation = new OperationRepository(context);
        }

        public OperationRepository Operation { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}

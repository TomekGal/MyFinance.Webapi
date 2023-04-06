using MyFinance.Webapi.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Webapi.Models.Repositories
{
    public class OperationRepository
    {
        private readonly MyFinancesContext _context;

        public OperationRepository(MyFinancesContext context)
        {
            _context = context;
        }
        public IEnumerable<Operations>Get()
        {
            return _context.Operations;
        }

        public Operations Get(int id)
        {

            return _context.Operations.FirstOrDefault(x => x.Id == id);
        }
        public void Add(Operations operation)
        {
            operation.Data = DateTime.Now;
            _context.Operations.Add(operation);
                       
        }

        public void Update(Operations operation)
        {
            var operationToUpdate = _context.Operations.First(x => x.Id == operation.Id);

            operationToUpdate.CategoryId = operation.CategoryId;
            operationToUpdate.Description = operation.Description;
            operationToUpdate.Name = operation.Name;
            operationToUpdate.Value = operation.Value;

        }

        public void Delete(int id)
        {
            var operationToDelete = _context.Operations.First(x => x.Id == id);
            _context.Operations.Remove(operationToDelete);
        }

        public IEnumerable<Operations> Get(int recordsCount, int page)
        {
            return _context.Operations.Skip(recordsCount*(page-1)).Take(recordsCount);
        }
    }
}

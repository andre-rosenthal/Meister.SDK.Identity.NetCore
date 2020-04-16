using Meister.SDK.Identity.NetCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meister.SDK.Identity.NetCore.Models
{
    public class CompanyDTO : IDataRepository<Company>
    {
        readonly CompanyContext _CompanyContext;
        public CompanyDTO(CompanyContext context)
        {
            _CompanyContext = context;
        }
        public IEnumerable<Company> GetAll()
        {
            return _CompanyContext.Company.ToList();
        }
        public Company Get(long id)
        {
            return _CompanyContext.Company.FirstOrDefault(c => c.Id == id);
        }
        public void Add(Company entity)
        {
            _CompanyContext.Company.Add(entity);
            _CompanyContext.SaveChanges();
        }

        public void Update(Company Company, Company entity)
        {
            Company.Name = entity.Name;
            _CompanyContext.SaveChanges();
        }

        public void Delete(Company Company)
        {
            _CompanyContext.Company.Remove(Company);
            _CompanyContext.SaveChanges();
        }
    }
}

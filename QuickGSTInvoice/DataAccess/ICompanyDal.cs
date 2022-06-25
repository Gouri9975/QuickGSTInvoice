using System.Collections.Generic;

namespace DataAccess
{
  public interface ICompanyDal
  {
        //bool Exists(int id);
        CompanyEntity Get(Guid id);
        List<CompanyEntity> Get();
        CompanyEntity Insert(CompanyEntity company);
        CompanyEntity Update(CompanyEntity company);
        bool Delete(Guid id);
  }
}

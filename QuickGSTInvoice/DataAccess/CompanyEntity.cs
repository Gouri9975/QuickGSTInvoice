using SQLite;
using System;
using System.Collections.Generic;

using System.Text;

namespace DataAccess
{
  public class CompanyEntity
  {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

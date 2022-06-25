using SQLite;
using System;
using System.Collections.Generic;

using System.Text;

namespace DataAccess
{
  public class PersonEntity
  {
    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}

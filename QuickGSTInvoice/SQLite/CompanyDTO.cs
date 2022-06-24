using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class CompanyDTO: SQLiteBase
    {
        public Guid ID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
       
    }

    public interface SQLiteBase
    {
        [PrimaryKey]
        public Guid ID { get; set; }

    }
 }

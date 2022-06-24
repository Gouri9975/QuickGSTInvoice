#if !UNO
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace e2.CDM.Lib
{
    public class XLToDataSet
    {
        public static DataSet GetDataTableFromExcel(Stream stream, bool hasHeader = true)
        {
            DataSet ds = new DataSet();
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(stream);
                //using (stream)
                //{
                //    pck.Load(stream);
                //}

                DataTable dt;
                foreach (var workSheet in workbook.Worksheets)
                {
                    dt = new DataTable();
                    dt = new DataTable(workSheet.Name);
                    dt = workSheet.ExportDataTable(workSheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                    //dt = workSheet.ExportDataTable(1, 1, workSheet.Columns.Count(), workSheet.Rows.Count(), new ExcelExportDataTableOptions() { });


                    #region Temporary Fix
                    var columnNames = dt.Columns;
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName.Contains("AM"))
                        {
                            column.ColumnName = "9AM";
                        }
                    }
                    #endregion

                    ds.Tables.Add(dt);


                    //dt.TableName = workSheet.Name;


                    //foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Columns])
                    //          {
                    //              dt.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                    //          }
                    //          var startRow = hasHeader ? 2 : 1;
                    //for (int rowNum = startRow; rowNum <= workSheet.ExportDataTable(.Dimension.End.Row; rowNum++)
                    //{
                    //  var wsRow = workSheet.Cells[rowNum, 1, rowNum, workSheet.Dimension.End.Column];
                    //  DataRow row = dt.Rows.Add();
                    //  foreach (var cell in wsRow)
                    //  {
                    //    row[cell.Start.Column - 1] = cell.Text.Trim();
                    //  }
                    //}
                    //ds.Tables.Add(dt);
                }
                return ds;

                #region UnUsed
                ///Commented - 20200715, Instead of using EPPluse used Syncfustion

                //var ws = pck.Workbook.Worksheets.First();
                //DataTable tbl = new DataTable();
                //foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                //{
                //    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                //}
                //var startRow = hasHeader ? 2 : 1;
                //for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                //{
                //    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                //    DataRow row = tbl.Rows.Add();
                //    foreach (var cell in wsRow)
                //    {
                //        row[cell.Start.Column - 1] = cell.Text;
                //    }
                //}
                //return tbl; 
                #endregion
            }
        }

        //public static List<string> GetWorkSheets(Stream stream)
        //{
        //  DataSet ds = new DataSet();
        //  using (var pck = new OfficeOpenXml.ExcelPackage())
        //  {
        //    using (stream)
        //    {
        //      pck.Load(stream);
        //    }

        //    List<string> sheets = pck.Workbook.Worksheets.Select(x => x.Name).ToList();
        //    return sheets;


        //  }
        //}

        //public static List<string> GetColumnNames(Stream stream, string sheetName)
        //{
        //  List<string> columns = new List<string>();
        //  using (var pck = new OfficeOpenXml.ExcelPackage())
        //  {
        //    using (stream)
        //    {
        //      pck.Load(stream);
        //    }
        //    DataTable dt;

        //    var workSheet = pck.Workbook.Worksheets.Where(x => x.Name.ToLower().Equals(sheetName)).FirstOrDefault();
        //    if (workSheet != null)
        //    {
        //      foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
        //      {
        //        columns.Add(firstRowCell.Text);
        //      }
        //    }
        //  }
        //  return columns;
        //}

        //public static void DataSetToExcel(DataTable dt, string file)
        //{
        //  FileInfo fileInfo = new FileInfo(file);
        //  using (ExcelPackage pck = new ExcelPackage(fileInfo))
        //  {
        //    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Errors");
        //    ws.Cells["A1"].LoadFromDataTable(dt, true);
        //    pck.Save();
        //  }

        //}

    }
}
#endif

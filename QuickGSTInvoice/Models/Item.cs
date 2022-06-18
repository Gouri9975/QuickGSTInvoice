using System;

namespace QuickGSTInvoice.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Value { get; set; }
    }

    public class SOItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string HSN { get; set; }
        public decimal Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal CGST_Rate { get; set; }
        public decimal SGST_Rate { get; set; }
        public decimal IGST_Rate { get; set; }
        public decimal Taxable_Amt { get; set; }
        public decimal CGST_Amt { get; set; }
        public decimal SGST_Amt { get; set; }
        public decimal IGST_Amt { get; set; }
        public decimal Total_Amt { get; set; }

    }
    public class SalesInvoice
    {
        public decimal Totoal_Taxable_Amt { get; set; }
        public decimal CGST_Amt { get; set; }
        public decimal SGST_Amt { get; set; }
        public decimal IGST_Amt { get; set; }
        public decimal Total_InvAmt { get; set; }
        public List<SOItem> SOItems { get; set; }
        public  bool IsIGST { get; set; }
        public void calculateTax()
        {
            foreach(var item in SOItems)
            {
                item.IGST_Amt = 0;
                item.CGST_Amt = 0;
                item.SGST_Amt = 0;
                item.Taxable_Amt =decimal.Round( item.Qty * item.Rate,0);
                if (IsIGST)
                {
                    item.IGST_Amt = item.Taxable_Amt * (item.IGST_Rate / 100);
                    item.Total_Amt = item.Taxable_Amt + item.IGST_Amt;
                }
                else
                {
                    item.CGST_Amt = item.Taxable_Amt * (item.CGST_Rate / 100);
                    item.SGST_Amt = item.Taxable_Amt * (item.SGST_Rate / 100);
                    item.Total_Amt = item.Taxable_Amt + item.CGST_Amt + item.SGST_Amt;
                }
                

            }

            this.CGST_Amt=decimal.Round(SOItems.Sum(x=>x.CGST_Amt),0);       
            this.SGST_Amt = decimal.Round(SOItems.Sum(x => x.SGST_Amt), 0);
            this.IGST_Amt = decimal.Round(SOItems.Sum(x => x.IGST_Amt), 0);
            this.Totoal_Taxable_Amt= decimal.Round(SOItems.Sum(x => x.Taxable_Amt), 0);
            if (!this.IsIGST)
                this.Total_InvAmt = decimal.Round(Totoal_Taxable_Amt + this.CGST_Amt + this.SGST_Amt,0);
            else
                this.Total_InvAmt = decimal.Round(Totoal_Taxable_Amt + this.IGST_Amt,0);
        }

    }
}
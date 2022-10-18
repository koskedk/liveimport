namespace LiveImport.MyBill.Domain;

public class PhoneBill
{
    public string InvoiceNumber { get; set; }
    public DateTime Date { get; set; }
    public string DialledNo { get; set; }
    public double Charge { get; set; }
}
namespace LiveImport.Accounting.Domain;

public enum InvoiceStatus
{
    Official,NotPaid,Paid
}

public class Invoice
{
    public string Number { get; set; }
    public long Phone { get; set; }
    public string Employee { get; set; }
    public double Amount { get; set; }
    public InvoiceStatus Status { get; set; }
}
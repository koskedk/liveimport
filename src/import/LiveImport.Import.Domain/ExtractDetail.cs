using CSharpFunctionalExtensions;

namespace LiveImport.Import.Domain;

public  class ExtractDetail:Entity<long>
{
    public string InvoiceNo { get; set; }
    public string Cell01 { get; set; }
    public string Cell02 { get; set; }
    public Guid ExtractId   { get; set; }
}
using CSharpFunctionalExtensions;

namespace LiveImport.Import.Domain;

public class Extract:Entity<Guid>
{
    public string Provider { get; set; }
    public string FileName { get; set; }
    public ICollection<ExtractDetail> Details { get; set; } = new List<ExtractDetail>();
}

public interface IExtractRepository
{
    Task Save(Extract extract);
    Task TagInvoiceNo();
}
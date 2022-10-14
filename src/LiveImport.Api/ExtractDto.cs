using System;

namespace LiveImport.Api;

public class ExtractDto
{
    public string File { get; set; }
    public DateTime Date { get; private set; } = DateTime.Now;
}
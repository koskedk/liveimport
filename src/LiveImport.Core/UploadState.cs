using System;
using MassTransit;

namespace LiveImport.Core
{
    public record Progress(int perc, string info);
    public class UploadState:
        SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public Progress Progress  { get; set; }
        public string FileName { get; set; }

        public void Init()
        {
            Progress = new Progress(0,"Uploading...");
        }

        public void ReportProgress(int perc, string info)
        {
            Progress = new Progress(perc, info);
        }
    }
}
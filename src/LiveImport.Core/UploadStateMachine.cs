using System;
using LiveImport.Contracts;
using MassTransit;

namespace LiveImport.Core
{
    public class UploadStateMachine : MassTransitStateMachine<UploadState>
    {
        // State
        public State Uploaded { get; private set; }
        public State Staged { get; private set; }
        public State Validated { get; private set; }
        public State Formatted { get; private set; }
        public State Loaded { get; private set; }
    
        //Event
        public Event<Extract> Upload { get; private set; }
        public Event Stage { get; private set; }
        public Event Validate { get; private set; }
        public Event Format { get; private set; }
        public Event Load { get; private set; }
    
        public Event Halted { get; private set; }

        
        public UploadStateMachine()
        {
            InstanceState(x => x.CurrentState);
        
            Initially(
                When(Upload).
                    Then(ctx=>ctx.Instance.FileName=ctx.Data.FileName).
                    Then(ctx=>ctx.Instance.Init()).
                    TransitionTo(Uploaded)
            );
            
            DuringAny(
                When(Stage).
                    Then(ctx=>ctx.Instance.ReportProgress(25,"Staging...")).
                    TransitionTo(Staged)
            );
            
            DuringAny(
                When(Validate).
                    Then(ctx=>ctx.Instance.ReportProgress(25,"Validating...")).
                    TransitionTo(Validated)
            );
            
            DuringAny(
                When(Format).
                    Then(ctx=>ctx.Instance.ReportProgress(25,"Formatting...")).
                    TransitionTo(Formatted)
            );
            
            DuringAny(
                When(Load).
                    Then(ctx=>ctx.Instance.ReportProgress(25,"Loading...")).
                    Publish(context => new Vault{FileName = context.Saga.FileName,DateLocked = DateTime.Now}).
                    TransitionTo(Loaded)
            );
        }
    }
}
using System;
using Automatonymous;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LiveImport.Core.Tests
{
    [TestFixture]
    public class UploadStateMachineTests
    {
        private UploadStateMachine _machine;
        private UploadState _state;
        private Extract _extract;
        [OneTimeSetUp]
        public void SetUp()
        {
            _state = new UploadState();
            _machine = TestInitializer.ServiceProvider.GetService<UploadStateMachine>();
            _extract = new Extract() {FileName = "c:\\livebill\\uploads\\safaricom-oct-22.txt"};
        }
    

        [Test]
        public void should_Change_State()
        {
        

            _machine.RaiseEvent(_state, _machine.Upload, _extract);

            Assert.That(_state.CurrentState, Is.EqualTo(_machine.Uploaded));
        
            _machine.RaiseEvent(_state, _machine.Stage, _extract);

            Assert.That(_state.CurrentState, Is.EqualTo(_machine.Staged));
        }
    
        [Test]
        public void should_Not_Change_Other_State()
        {
            _machine.RaiseEvent(_state, _machine.Halted, _extract);

            Assert.That(_state.CurrentState, Is.EqualTo(_machine.Halted));
        }
    }
}
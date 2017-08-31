namespace ResumeApi.xTests
{
    using ResumeApi.Common.Extensions;
    using System;
    using Xunit;

    public class DisposableTests
    {
        private class MockDisposable : IDisposable
        {
            public bool Disposed { get; private set; }           
            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {                
                Disposed = true;             
            }            
        }

        [Fact]
        public void ShouldDispose_Func()
        {
            var mock = new MockDisposable();
            Assert.False(mock.Disposed);

            var x = Disposable.Using(() => mock, _ => 42);

            Assert.True(mock.Disposed);
            Assert.Equal(42, x);
        }

        [Fact]
        public void ShouldDispose_Action()
        {
            var mock = new MockDisposable();
            Assert.False(mock.Disposed);
            var x = 41;

            Disposable.Using(() => mock, _ => { x = x + 1; });

            Assert.True(mock.Disposed);
            Assert.Equal(42, x);
        }

        [Fact]
        public void ShouldThrow_NullFactoryFunc()
        {                       
            Assert.Throws<ArgumentNullException>(() =>
            {
                Func<MockDisposable> ctor = null;
                Disposable.Using(ctor, _ => 42);
            });            
        }

        [Fact]
        public void ShouldThrow_NullAction()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Action<IDisposable> action = null;
                Disposable.Using(() => new MockDisposable(), action);
            });
        }

        [Fact]
        public void ShouldThrow_NullFunc()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Func<IDisposable, int> func = null;
                Disposable.Using(() => new MockDisposable(), func);
            });
        }
    }
}

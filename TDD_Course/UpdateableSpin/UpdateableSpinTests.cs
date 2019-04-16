using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_Course
{
    [TestFixture]
    public class UpdateableSpinTests
    {
        [Test]
        public void Wait_NoPulse_ReturnsFalse()
        {
            UpdateableSpin spin = new UpdateableSpin();
            bool wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));
            Assert.IsFalse(wasPulsed);
        }

        [Test]
        public void Wait_Pulse_ReturnsTrue()
        {
            UpdateableSpin spin = new UpdateableSpin();

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                spin.Set();
            });

            bool wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));
            Assert.IsTrue(wasPulsed);
        }

        [Test]
        public void Wait50Millisec_CallIsActuallyWaitingFor50Millisec()
        {
            var spin = new UpdateableSpin();
            
            Stopwatch watcher = new Stopwatch();
            watcher.Start();

            spin.Wait(TimeSpan.FromMilliseconds(50));

            watcher.Stop();
            
            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);

            //sets boundary because time won't be exact
            TimeSpan leftBoundary = TimeSpan.FromMilliseconds(50 - (50 * 0.1));
            TimeSpan rightBoundary = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

            Assert.IsTrue(actual > leftBoundary && actual < rightBoundary);
        }

        [Test]
        public void Wait50Millisec_UpdateAfter300Millisec_TotalWaitingIsApprox800Millisec()
        {
            var spin = new UpdateableSpin();

            var watcher = new Stopwatch();
            watcher.Start();

            const int timeout = 500;
            const int spanBeforeUpdate = 300;

            Task.Factory.StartNew(() => {
                Thread.Sleep(spanBeforeUpdate);
                spin.UpdateTimeout();
            });

            spin.Wait(TimeSpan.FromMilliseconds(timeout));

            watcher.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            const int expected = timeout + spanBeforeUpdate;

            TimeSpan leftBoundary = TimeSpan.FromMilliseconds(expected - (expected * 0.1));
            TimeSpan rightBoundary = TimeSpan.FromMilliseconds(expected + (expected * 0.1));

            Assert.IsTrue(actual > leftBoundary && actual < rightBoundary);
        }
    }
}

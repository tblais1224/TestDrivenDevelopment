using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
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
            Assert.IsFalse(wasPulsed);
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
            TimeSpan leftEpsilon = TimeSpan.FromMilliseconds(50 - (50 * 0.1));
            TimeSpan rightEpsilon = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

            Assert.IsTrue(actual > leftEpsilon && actual < rightEpsilon);
        }

        [Test]
        public void Wait50Millisec_UpdateAfter300Millisec_TotalWaitingIsApprox800Millisec()
        {
            var spin = new UpdateableSpin();

            var watcher = new Stopwatch();
            watcher.Start();

            const int timeout = 500;
            const int spanBeforeUpdate = 300;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(spanBeforeUpdate);
                spin.UpdateTimeout();
            });

            spin.Wait(TimeSpan.FromMilliseconds(50));

            watcher.Stop();

            TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
            const int expected = timeout + spanBeforeUpdate;

            TimeSpan left = TimeSpan.FromMilliseconds(50 - (50 * 0.1));
            TimeSpan right = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

            Assert.IsTrue(actual > left && actual < right);
        }
    }

    public class UpdateableSpin
    {
        private readonly object _lockObj = new object();
        private bool _shouldWait = true;
        private long _executionStartingTime;
        public void Set()
        {
            lock (_lockObj)
            {
                _shouldWait = false;
            }
        }
        public bool Wait(TimeSpan timeout, int spinDuration = 0)
        {
            UpdateTimeout();
            while (true)
            {
                lock (_lockObj)
                {
                    if (!_shouldWait)
                        return true;
                    if (DateTime.UtcNow.Ticks - _executionStartingTime > timeout.Ticks)
                        return false;
                }
                Thread.Sleep(spinDuration);
            }
        }

        public void UpdateTimeout()
        {
            lock (_lockObj)
            {
                _executionStartingTime = DateTime.UtcNow.Ticks;
            }
        }
    }
}

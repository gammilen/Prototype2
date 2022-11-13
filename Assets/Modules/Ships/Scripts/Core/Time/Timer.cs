using System;
using System.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace Ships.Core
{
    public class Timer : ITimeProgress
    {
        private CancellationTokenSource _cancellaionTokenSource;
        private float _startTime;

        public float TimeInSeconds { get; private set; }
        public bool IsInProcess { get; private set; }

        public event Action OnExpired;

        public Timer(float seconds)
        {
            _cancellaionTokenSource = new CancellationTokenSource();
            TimeInSeconds = seconds;
        }

        public void Restart()
        {
            _startTime = Time.time;
            _cancellaionTokenSource.Cancel();
            _cancellaionTokenSource.Dispose();
            _cancellaionTokenSource = new CancellationTokenSource();
            StartTimer(_cancellaionTokenSource.Token);
            IsInProcess = true;
        }

        public void Stop()
        {
            _cancellaionTokenSource.Cancel();
            IsInProcess = false;
        }

        public float GetProgress()
        {
            return (Time.time - _startTime) / TimeInSeconds;
        }

        private async void StartTimer(CancellationToken token)
        {
            while (Time.time - _startTime < TimeInSeconds)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                await Task.Yield();
            }
            IsInProcess = false;
            OnExpired?.Invoke();
        }
    }
}
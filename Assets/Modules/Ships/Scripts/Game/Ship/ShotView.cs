using System;
using UnityEngine;
using Ships.Core;

namespace Ships.Game
{
    public class ShotView : MonoBehaviour
    {
        private ITimeProgress _progress;
        private Vector3 _startPosition;
        private Vector3 _finishPosition;

        private void Update()
        {
            if (_progress.IsInProcess)
            {
                transform.position = Vector3.Lerp(_startPosition, _finishPosition, _progress.GetProgress());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public void Init(Shot shot, Vector3 position, Vector3 direction)
        {
            _progress = shot.ShotData.FlightProgress;
            transform.position = _startPosition = position;
            transform.forward = direction;
            _finishPosition = position + transform.forward * shot.Speed * _progress.TimeInSeconds;
            gameObject.SetActive(true);
        }
    }
}
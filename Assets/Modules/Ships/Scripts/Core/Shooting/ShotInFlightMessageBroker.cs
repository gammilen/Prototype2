using System;
using System.Collections.Generic;

namespace Ships.Core
{
    public class ShotInFlightMessageBroker : IPublishingMessageBroker<ShotInFlight>, ISubscribingMessageBroker<ShotInFlight, IShipState>
    {
        private readonly Dictionary<IShipState, List<IInfoHandler<ShotInFlight>>> _subscribers = new();

        public void Publish(ShotInFlight shot)
        {
            if (_subscribers.ContainsKey(shot.Source))
            {
                foreach (var subscriber in _subscribers[shot.Source])
                {
                    subscriber.Handle(shot);
                }
            }
        }

        public void AddSubscriber(IInfoHandler<ShotInFlight> subscriber, IShipState ship)
        {
            if (!_subscribers.ContainsKey(ship))
            {
                _subscribers.Add(ship, new List<IInfoHandler<ShotInFlight>>());
            }
            if (!_subscribers[ship].Contains(subscriber))
            {
                _subscribers[ship].Add(subscriber);
            }
        }

        public void RemoveSubscriber(IInfoHandler<ShotInFlight> subscriber, IShipState ship)
        {
            if (_subscribers.ContainsKey(ship))
            {
                _subscribers[ship].Remove(subscriber);
            }
        }
    }
}
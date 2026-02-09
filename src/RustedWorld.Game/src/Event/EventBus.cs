using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Godot;
using RustedWorld.Api.Event;

namespace RustedWorld.Game.Event;

public partial class EventBus: Node, IEventBus {
	public static EventBus Instance { private set; get; } = null!;

	private readonly HashSet<Delegate> _subscribers = [];

	public void Subscribe<T>(EventAction<T> action) where T : IEvent => _subscribers.Add(action);

	public void Unsubscribe<T>(EventAction<T> action) where T : IEvent => _subscribers.Remove(action);

	public async Task Raise<T>(T @event) where T : IEvent {
		foreach (Delegate subscriber in _subscribers)
			if (subscriber.GetType().IsSubclassOf(typeof(EventAction<>)) && subscriber.GetType().GetGenericArguments()[0].IsSubclassOf(typeof(T)))
				try {
					await (Task)subscriber.DynamicInvoke(@event)!;
				}
				catch (Exception exception) {
					// ignore
				}
	}

	public override void _Ready() {
		Instance = this;
	}
}
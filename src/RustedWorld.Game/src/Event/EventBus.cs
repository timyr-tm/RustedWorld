using Godot;
using System;
using Serilog;
using RustedWorld.Api.Event;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RustedWorld.Game.Event;

public partial class EventBus: Node, IEventBus {
	public static EventBus Instance { get; private set; } = null!;
	private static readonly ILogger Logger = Log.ForContext<EventBus>();

	private readonly HashSet<Delegate> _subscribers = [];

	public void Subscribe<T>(EventAction<T> action) where T : IEvent => _subscribers.Add(action);

	public void Unsubscribe<T>(EventAction<T> action) where T : IEvent => _subscribers.Remove(action);

	public async Task Raise<T>(T @event) where T : IEvent {
		foreach (Delegate subscriber in _subscribers) {
			if (subscriber.GetType().GetGenericArguments().Length != 1)
				continue;
			if (!subscriber.GetType().GetGenericArguments()[0].IsAssignableFrom(typeof(T)))
				continue;
			await (Task) subscriber.DynamicInvoke(@event)!;
		}
	}

	public override void _Ready() {
		Logger.Information("Is Ready");
		Instance = this;
	}
}
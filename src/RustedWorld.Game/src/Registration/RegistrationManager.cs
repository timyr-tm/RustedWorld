using System.Collections.Generic;
using RustedWorld.Game.Event;
using Serilog;

namespace RustedWorld.Game.Registration;

using Godot;
using RustedWorld.Api.Registration;


public partial class RegistrationManager: Node {
	public static RegistrationManager Instance { get; private set; } = null!;
	
	private static readonly ILogger Logger = Log.ForContext<RegistrationManager>();

	private readonly Dictionary<IRegistrationType, HashSet<Registration>> _registrations = new();
	
	public T AddRegistration<T>(RegistrationType<T> type, T registration) where T : Registration {
		if (!_registrations.ContainsKey(type))
			_registrations[type] = [];
		_registrations[type].Add(registration);
		return registration;
	}

	public override async void _Ready() {
		Logger.Information("Is ready");
		Instance = this;
		Logger.Information("Start registration");
		await EventBus.Instance.Raise(new RegisterEvent(this));
	}
}
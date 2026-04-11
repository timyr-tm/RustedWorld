namespace RustedWorld.Game.Registration;

using RustedWorld.Api.Registration;

public class RegisterEvent(RegistrationManager manager): IRegistrationEvent {
	public T Register<T>(RegistrationType<T> type, T registration) where T : Registration => manager.AddRegistration(type, registration);
}
using RustedWorld.Api.Event;

namespace RustedWorld.Api.Registration;

public interface IRegistrationEvent: IEvent {
	public T Register<T>(RegistrationType<T> type, T registration) where T: Registration;
}
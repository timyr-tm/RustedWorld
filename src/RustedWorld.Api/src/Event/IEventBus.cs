using System.Threading.Tasks;

namespace RustedWorld.Api.Event;

public interface IEventBus {
	public void Subscribe<T>(EventAction<T> action) where T: IEvent;
	public void Unsubscribe<T>(EventAction<T> action) where T: IEvent;
	public Task Raise<T>(T @event) where T: IEvent;
}
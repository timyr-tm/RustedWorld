using System.Threading.Tasks;

namespace RustedWorld.Api.Event;

public delegate Task EventAction<in T>(T @event) where T: IEvent;
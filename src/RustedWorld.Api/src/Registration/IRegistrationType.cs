using System;

namespace RustedWorld.Api.Registration;

public interface IRegistrationType {
	public string Name { get; }
	public Type Type { get; }
}
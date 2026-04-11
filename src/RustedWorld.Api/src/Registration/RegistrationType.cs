using System;

namespace RustedWorld.Api.Registration;

public class RegistrationType<T>(string name): IRegistrationType where T: Registration {
	public string Name { get; } = name;
	public Type Type { get; } = typeof(T);
	
	public override int GetHashCode() => Name.GetHashCode() ^ Type.GetHashCode();
}
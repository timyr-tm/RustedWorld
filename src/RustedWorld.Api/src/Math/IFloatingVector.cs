using System;
using System.Numerics;

namespace RustedWorld.Api.Math;

public interface IFloatingVector<TSelf, T>: IVector<TSelf, T> where TSelf: IFloatingVector<TSelf, T> where T: IFloatingPoint<T> {
	public virtual TSelf Ceiling() => Round(0, MidpointRounding.ToPositiveInfinity);
	
	public virtual TSelf Floor() => Round(0, MidpointRounding.ToNegativeInfinity);
	
	public virtual TSelf Round() => Round(0, MidpointRounding.ToEven);
	public virtual TSelf Round(int digits) => Round(digits, MidpointRounding.ToEven);
	public abstract TSelf Round(int digits, MidpointRounding mode);

	public virtual TSelf Truncate() => Round(0, MidpointRounding.ToZero);
}
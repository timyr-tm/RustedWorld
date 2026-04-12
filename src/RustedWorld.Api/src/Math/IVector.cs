using System.Collections.Generic;
using System.Numerics;

namespace RustedWorld.Api.Math;

public interface IVector<TSelf, T>: IEnumerable<KeyValuePair<char, T>>, IMinMaxValue<TSelf> where TSelf: IVector<TSelf, T> where T: INumber<T> {
	public T this[int index] { get; set; }
	public T this[char name] { get; set; }
	
	public float Length();
	
	public TSelf Abs();
	
	public TSelf Clamp(TSelf min, TSelf max);
	public TSelf Clamp(T min, T max);
	
	public virtual TSelf Max(TSelf left, TSelf right) => left > right ? left : right;
	
	public virtual TSelf Min(TSelf left, TSelf right) => left < right ? left : right;
	
	public abstract void operator ++();
	public abstract void operator --();
	
	public abstract void operator +=(TSelf vector);
	public abstract void operator -=(TSelf vector);
	public abstract void operator *=(TSelf vector);
	public abstract void operator /=(TSelf vector);
	
	public abstract void operator +=(T number);
	public abstract void operator -=(T number);
	public abstract void operator *=(T number);
	public abstract void operator /=(T number);
	
	public static abstract TSelf operator +(TSelf left, TSelf right);
	public static abstract TSelf operator -(TSelf left, TSelf right);
	public static abstract TSelf operator *(TSelf left, TSelf right);
	public static abstract TSelf operator /(TSelf left, TSelf right);
	
	public static abstract TSelf operator +(TSelf vector, T number);
	public static abstract TSelf operator -(TSelf vector, T number);
	public static abstract TSelf operator *(TSelf vector, T number);
	public static abstract TSelf operator /(TSelf vector, T number);
	
	public static abstract TSelf operator +(TSelf vector);
	public static abstract TSelf operator -(TSelf vector);
	
	public static abstract bool operator ==(TSelf left, TSelf right);
	public static abstract bool operator !=(TSelf left, TSelf right);
	
	public static abstract bool operator ==(TSelf vector, T number);
	public static abstract bool operator !=(TSelf vector, T number);
	
	public static abstract bool operator >(TSelf left, TSelf right);
	public static abstract bool operator <(TSelf left, TSelf right);
	public static abstract bool operator >=(TSelf left, TSelf right);
	public static abstract bool operator <=(TSelf left, TSelf right);
	
	public static abstract bool operator >(TSelf vector, T number);
	public static abstract bool operator <(TSelf vector, T number);
	public static abstract bool operator >=(TSelf vector, T number);
	public static abstract bool operator <=(TSelf vector, T number);
}
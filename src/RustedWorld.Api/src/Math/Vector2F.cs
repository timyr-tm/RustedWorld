using System;
using System.Collections;
using System.Collections.Generic;

namespace RustedWorld.Api.Math;

public record struct Vector2F(float X, float Y): IFloatingVector<Vector2F, float> {
	public static Vector2F MinValue => new(float.MinValue, float.MinValue);
	public static Vector2F MaxValue => new(float.MaxValue, float.MaxValue);
	
	public float Length() => MathF.Sqrt(MathF.Pow(X, 2) + MathF.Pow(Y, 2));

	public float this[int index] {
		get => index switch {
			0 => X,
			1 => Y,
			_ => throw new IndexOutOfRangeException()
		};
		set {
			switch (index) {
				case 0: X = value; return;
				case 1: Y = value; return;
				default: throw new IndexOutOfRangeException();
			}
		}
	}

	public float this[char name] {
		get => name switch {
			'x' => X,
			'y' => Y,
			_ => throw new KeyNotFoundException()
		};
		set {
			switch (name) {
				case 'x': X = value; return;
				case 'y': Y = value; return;
				default: throw new KeyNotFoundException(name.ToString());
			}
		}
	}

	public Vector2F Abs() => new(float.Abs(X), float.Abs(Y));

	public Vector2F Clamp(Vector2F min, Vector2F max) => new(
		float.Clamp(X, min.X, max.X),
		float.Clamp(Y, min.Y, max.Y)
	);
	public Vector2F Clamp(float min, float max) => new(
		float.Clamp(X, min, max),
		float.Clamp(Y, min, max)
	);
	
	public Vector2F Round(int digits, MidpointRounding mode) => new(
		float.Round(X, digits, mode),
		float.Round(Y, digits, mode)
	);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<KeyValuePair<char, float>> GetEnumerator() {
		yield return new('x', X);
		yield return new('y', Y);
	}

	public void operator ++() {
		X++;
		Y++;
	}
	public void operator --() {
		X--;
		Y--;
	}

	public void operator += (Vector2F vector) {
		X += vector.X;
		Y += vector.Y;
	}
	public void operator -= (Vector2F vector) {
		X -= vector.X;
		Y -= vector.Y;
	}
	public void operator *= (Vector2F vector) {
		X *= vector.X;
		Y *= vector.Y;
	}
	public void operator /= (Vector2F vector) {
		X /= vector.X;
		Y /= vector.Y;
	}

	public void operator += (float number) {
		X += number;
		Y += number;
	}
	public void operator -= (float number) {
		X -= number;
		Y -= number;
	}
	public void operator *= (float number) {
		X *= number;
		Y *= number;
	}
	public void operator /= (float number) {
		X /= number;
		Y /= number;
	}

	public static Vector2F operator +(Vector2F left, Vector2F right) => new(left.X + right.X, left.Y + right.Y);
	public static Vector2F operator -(Vector2F left, Vector2F right) => new(left.X - right.X, left.Y - right.Y);
	public static Vector2F operator *(Vector2F left, Vector2F right) => new(left.X * right.X, left.Y * right.Y);
	public static Vector2F operator /(Vector2F left, Vector2F right) => new(left.X / right.X, left.Y / right.Y);

	public static Vector2F operator +(Vector2F vector, float number) => new(vector.X + number, vector.Y + number);
	public static Vector2F operator -(Vector2F vector, float number) => new(vector.X - number, vector.Y - number);
	public static Vector2F operator *(Vector2F vector, float number) => new(vector.X * number, vector.Y * number);
	public static Vector2F operator /(Vector2F vector, float number) => new(vector.X / number, vector.Y / number);

	public static Vector2F operator +(Vector2F vector) => vector;
	public static Vector2F operator -(Vector2F vector) => new(-vector.X, -vector.Y);

	public static bool operator ==(Vector2F vector, float number) => (vector.X == number) && (vector.Y == number);
	public static bool operator !=(Vector2F vector, float number) => (vector.X == number) && (vector.Y == number);

	public static bool operator >(Vector2F left, Vector2F right) => (left.X > right.X) && (left.Y > right.Y);
	public static bool operator <(Vector2F left, Vector2F right) => (left.X < right.X) && (left.Y < right.Y);
	public static bool operator >=(Vector2F left, Vector2F right) => (left.X >= right.X) && (left.Y >= right.Y);
	public static bool operator <=(Vector2F left, Vector2F right) => (left.X <= right.X) && (left.Y <= right.Y);

	public static bool operator >(Vector2F vector, float number) => (vector.X > number) && (vector.Y > number);
	public static bool operator <(Vector2F vector, float number) => (vector.X < number) && (vector.Y < number);
	public static bool operator >=(Vector2F vector, float number) => (vector.X >= number) && (vector.Y >= number);
	public static bool operator <=(Vector2F vector, float number) => (vector.X <= number) && (vector.Y <= number);

	public static implicit operator Vector2I(Vector2F vector) => new((int) vector.X, (int) vector.Y);
}
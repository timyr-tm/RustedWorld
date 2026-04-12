using System;
using System.Collections;
using System.Collections.Generic;

namespace RustedWorld.Api.Math;

public record struct Vector3F(float X, float Y, float Z): IFloatingVector<Vector3F, float> {
	public static Vector3F MinValue => new(float.MinValue, float.MinValue, float.MinValue);
	public static Vector3F MaxValue => new(float.MaxValue, float.MaxValue, float.MaxValue);

	public float this[int index] {
		get => index switch {
			0 => X,
			1 => Y,
			2 => Z,
			_ => throw new IndexOutOfRangeException()
		};
		set {
			switch (index) {
				case 0: X = value; return;
				case 1: Y = value; return;
				case 2: Z = value; return;
				default: throw new IndexOutOfRangeException();
			}
		}
	}
	public float this[char name] {
		get => name switch {
			'x' => X,
			'y' => Y,
			'z' => Z,
			_ => throw new KeyNotFoundException()
		};
		set {
			switch (name) {
				case 'x': X = value; return;
				case 'y': Y = value; return;
				case 'z': Z = value; return;
				default: throw new KeyNotFoundException(name.ToString());
			}
		}
	}

	public float Length() => MathF.Sqrt(MathF.Pow(X, 2) + MathF.Pow(Y, 2) + MathF.Pow(Z, 2));

	public Vector3F Abs() => new(float.Abs(X), float.Abs(Y), float.Abs(Z));

	public Vector3F Clamp(Vector3F min, Vector3F max) => new(
		float.Clamp(X, min.X, max.X),
		float.Clamp(Y, min.Y, max.Y),
		float.Clamp(Z, min.Z, max.Z)
	);
	public Vector3F Clamp(float min, float max) => new(
		float.Clamp(X, min, max),
		float.Clamp(Y, min, max),
		float.Clamp(Z, min, max)
	);

	public Vector3F Round(int digits, MidpointRounding mode) => new(
		float.Round(X, digits, mode),
		float.Round(Y, digits, mode),
		float.Round(Z, digits, mode)
	);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<KeyValuePair<char, float>> GetEnumerator() {
		yield return new('x', X);
		yield return new('y', Y);
		yield return new('z', Z);
	}

	public void operator ++() {
		X++;
		Y++;
		Z++;
	}

	public void operator --() {
		X--;
		Y--;
		Z--;
	}

	public void operator += (Vector3F vector) {
		X += vector.X;
		Y += vector.Y;
		Z += vector.Z;
	}
	public void operator -= (Vector3F vector) {
		X -= vector.X;
		Y -= vector.Y;
		Z -= vector.Z;
	}
	public void operator *= (Vector3F vector) {
		X *= vector.X;
		Y *= vector.Y;
		Z *= vector.Z;
	}
	public void operator /= (Vector3F vector) {
		X /= vector.X;
		Y /= vector.Y;
		Z /= vector.Z;
	}

	public void operator += (float number) {
		X += number;
		Y += number;
		Z += number;
	}
	public void operator -= (float number) {
		X -= number;
		Y -= number;
		Z -= number;
	}
	public void operator *= (float number) {
		X *= number;
		Y *= number;
		Z *= number;
	}
	public void operator /= (float number) {
		X /= number;
		Y /= number;
		Z /= number;
	}

	public static Vector3F operator +(Vector3F left, Vector3F right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	public static Vector3F operator -(Vector3F left, Vector3F right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	public static Vector3F operator *(Vector3F left, Vector3F right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	public static Vector3F operator /(Vector3F left, Vector3F right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

	public static Vector3F operator +(Vector3F vector, float number) => new(vector.X + number, vector.Y + number, vector.Z + number);
	public static Vector3F operator -(Vector3F vector, float number) => new(vector.X - number, vector.Y - number, vector.Z - number);
	public static Vector3F operator *(Vector3F vector, float number) => new(vector.X * number, vector.Y * number, vector.Z * number);
	public static Vector3F operator /(Vector3F vector, float number) => new(vector.X / number, vector.Y / number, vector.Z / number);

	public static Vector3F operator +(Vector3F vector) => vector;
	public static Vector3F operator -(Vector3F vector) => new(-vector.X, -vector.Y, -vector.Z);

	public static bool operator ==(Vector3F vector, float number) => (vector.X == number) && (vector.Y == number) && (vector.Z == number);
	public static bool operator !=(Vector3F vector, float number) => (vector.X == number) && (vector.Y == number) && (vector.Z == number);

	public static bool operator >(Vector3F left, Vector3F right) => (left.X > right.X) && (left.Y > right.Y) && (left.Z > right.Z);
	public static bool operator <(Vector3F left, Vector3F right) => (left.X < right.X) && (left.Y < right.Y) && (left.Z < right.Z);
	public static bool operator >=(Vector3F left, Vector3F right) => (left.X >= right.X) && (left.Y >= right.Y) && (left.Z >= right.Z);
	public static bool operator <=(Vector3F left, Vector3F right) => (left.X <= right.X) && (left.Y <= right.Y) && (left.Z <= right.Z);

	public static bool operator >(Vector3F vector, float number) => (vector.X > number) && (vector.Y > number) && (vector.Z > number);
	public static bool operator <(Vector3F vector, float number) => (vector.X < number) && (vector.Y < number) && (vector.Z < number);
	public static bool operator >=(Vector3F vector, float number) => (vector.X >= number) && (vector.Y >= number) && (vector.Z >= number);
	public static bool operator <=(Vector3F vector, float number) => (vector.X <= number) && (vector.Y <= number) && (vector.Z <= number);
	
	public static implicit operator Vector3I(Vector3F vector) => new((int) vector.X, (int) vector.Y, (int) vector.Z);
}
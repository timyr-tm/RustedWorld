using System;
using System.Collections;
using System.Collections.Generic;

namespace RustedWorld.Api.Math;

public record struct Vector3I(int X, int Y, int Z): IVector<Vector3I, int> {
	public static Vector3I MinValue => new(int.MinValue, int.MinValue, int.MinValue);
	public static Vector3I MaxValue => new(int.MaxValue, int.MaxValue, int.MaxValue);

	public int this[int index] {
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
	public int this[char name] {
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

	public Vector3I Abs() => new(int.Abs(X), int.Abs(Y), int.Abs(Z));

	public Vector3I Clamp(Vector3I min, Vector3I max) => new(
		int.Clamp(X, min.X, max.X),
		int.Clamp(Y, min.Y, max.Y),
		int.Clamp(Z, min.Z, max.Z)
	);
	public Vector3I Clamp(int min, int max) => new(
		int.Clamp(X, min, max),
		int.Clamp(Y, min, max),
		int.Clamp(Z, min, max)
	);
	
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<KeyValuePair<char, int>> GetEnumerator() {
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

	public void operator += (Vector3I vector) {
		X += vector.X;
		Y += vector.Y;
		Z += vector.Z;
	}
	public void operator -= (Vector3I vector) {
		X -= vector.X;
		Y -= vector.Y;
		Z -= vector.Z;
	}
	public void operator *= (Vector3I vector) {
		X *= vector.X;
		Y *= vector.Y;
		Z *= vector.Z;
	}
	public void operator /= (Vector3I vector) {
		X /= vector.X;
		Y /= vector.Y;
		Z /= vector.Z;
	}

	public void operator += (int number) {
		X += number;
		Y += number;
		Z += number;
	}
	public void operator -= (int number) {
		X -= number;
		Y -= number;
		Z -= number;
	}
	public void operator *= (int number) {
		X *= number;
		Y *= number;
		Z *= number;
	}
	public void operator /= (int number) {
		X /= number;
		Y /= number;
		Z /= number;
	}

	public static Vector3I operator +(Vector3I left, Vector3I right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	public static Vector3I operator -(Vector3I left, Vector3I right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	public static Vector3I operator *(Vector3I left, Vector3I right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	public static Vector3I operator /(Vector3I left, Vector3I right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

	public static Vector3I operator +(Vector3I vector, int number) => new(vector.X + number, vector.Y + number, vector.Z + number);
	public static Vector3I operator -(Vector3I vector, int number) => new(vector.X - number, vector.Y - number, vector.Z - number);
	public static Vector3I operator *(Vector3I vector, int number) => new(vector.X * number, vector.Y * number, vector.Z * number);
	public static Vector3I operator /(Vector3I vector, int number) => new(vector.X / number, vector.Y / number, vector.Z / number);

	public static Vector3I operator +(Vector3I vector) => vector;
	public static Vector3I operator -(Vector3I vector) => new(-vector.X, -vector.Y, -vector.Z);

	public static bool operator ==(Vector3I vector, int number) => (vector.X == number) && (vector.Y == number) && (vector.Z == number);
	public static bool operator !=(Vector3I vector, int number) => (vector.X == number) && (vector.Y == number) && (vector.Z == number);

	public static bool operator >(Vector3I left, Vector3I right) => (left.X > right.X) && (left.Y > right.Y) && (left.Z > right.Z);
	public static bool operator <(Vector3I left, Vector3I right) => (left.X < right.X) && (left.Y < right.Y) && (left.Z < right.Z);
	public static bool operator >=(Vector3I left, Vector3I right) => (left.X >= right.X) && (left.Y >= right.Y) && (left.Z >= right.Z);
	public static bool operator <=(Vector3I left, Vector3I right) => (left.X <= right.X) && (left.Y <= right.Y) && (left.Z <= right.Z);

	public static bool operator >(Vector3I vector, int number) => (vector.X > number) && (vector.Y > number) && (vector.Z > number);
	public static bool operator <(Vector3I vector, int number) => (vector.X < number) && (vector.Y < number) && (vector.Z < number);
	public static bool operator >=(Vector3I vector, int number) => (vector.X >= number) && (vector.Y >= number) && (vector.Z >= number);
	public static bool operator <=(Vector3I vector, int number) => (vector.X <= number) && (vector.Y <= number) && (vector.Z <= number);
	
	public static explicit operator Vector3F(Vector3I vector) => new(vector.X, vector.Y, vector.Z);
}
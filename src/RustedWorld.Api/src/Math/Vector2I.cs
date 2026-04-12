using System;
using System.Collections;
using System.Collections.Generic;

namespace RustedWorld.Api.Math;

public record struct Vector2I(int X, int Y): IVector<Vector2I, int> {
	public static Vector2I MaxValue => new(int.MaxValue, int.MaxValue);
	public static Vector2I MinValue => new(int.MinValue, int.MinValue);

	public int this[int index] {
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

	public int this[char name] {
		get =>  name switch {
			'x' => X,
			'y' => Y,
			_ => throw new KeyNotFoundException(name.ToString())
		};
		set {
			switch (name) {
				case 'x': X = value; return;
				case 'y': Y = value; return;
				default: throw new KeyNotFoundException(name.ToString());
			}
		}
	}

	public float Length() => MathF.Sqrt(MathF.Pow(X, 2) + MathF.Pow(Y, 2));

	public Vector2I Abs() => new(int.Abs(X), int.Abs(Y));

	public Vector2I Clamp(Vector2I min, Vector2I max) => new(
		int.Clamp(X, min.X, max.X),
		int.Clamp(Y, min.Y, max.Y)
	);

	public Vector2I Clamp(int min, int max) => new(
		int.Clamp(X, min, max),
		int.Clamp(Y, min, max)
	);

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<KeyValuePair<char, int>> GetEnumerator() {
		yield return new('x', X);
		yield return new('y', Y);
	}

	public void operator += (Vector2I vector) {
		X += vector.X;
		Y += vector.Y;
	}
	
	public void operator -= (Vector2I vector) {
		X -= vector.X;
		Y -= vector.Y;
	}

	public void operator *= (Vector2I vector) {
		X *= vector.X;
		Y *= vector.Y;
	}

	public void operator /= (Vector2I vector) {
		X /= vector.X;
		Y /= vector.Y;
	}

	public void operator += (int number) {
		X += number;
		Y += number;
	}

	public void operator -= (int number) {
		X -= number;
		Y -= number;
	}

	public void operator *= (int number) {
		X *= number;
		Y *= number;
	}

	public void operator /= (int number) {
		X /= number;
		Y /= number;
	}

	public void operator ++ () {
		X++;
		Y++;
	}

	public void operator -- () {
		X--;
		Y--;
	}

	public static Vector2I operator +(Vector2I left, Vector2I right) => new(left.X + right.X, left.Y + right.Y);
	public static Vector2I operator -(Vector2I left, Vector2I right) => new(left.X - right.X, left.Y - right.Y);
	public static Vector2I operator *(Vector2I left, Vector2I right) => new(left.X * right.X, left.Y * right.Y);
	public static Vector2I operator /(Vector2I left, Vector2I right) => new(left.X / right.X, left.Y / right.Y);

	public static Vector2I operator +(Vector2I vector, int number) => new(vector.X + number, vector.Y + number);
	public static Vector2I operator -(Vector2I vector, int number) => new(vector.X - number, vector.Y - number);
	public static Vector2I operator *(Vector2I vector, int number) => new(vector.X * number, vector.Y * number);
	public static Vector2I operator /(Vector2I vector, int number) => new(vector.X / number, vector.Y / number);

	public static Vector2I operator +(Vector2I left) => left;
	public static Vector2I operator -(Vector2I left) => new(-left.X, -left.Y);

	public static bool operator ==(Vector2I vector, int number) => (vector.X == number) && (vector.Y == number);
	public static bool operator !=(Vector2I vector, int number) => (vector.X == number) && (vector.Y == number);

	public static bool operator > (Vector2I left, Vector2I right) => (left.X > right.X) && (left.Y > right.Y);
	public static bool operator < (Vector2I left, Vector2I right) => (left.X < right.X) && (left.Y < right.Y);
	public static bool operator >= (Vector2I left, Vector2I right) => (left.X >= right.X) && (left.Y >= right.Y);
	public static bool operator <= (Vector2I left, Vector2I right) => (left.X <= right.X) && (left.Y <= right.Y);
	
	public static bool operator > (Vector2I vector, int right) => (vector.X > right) && (vector.Y > right);
	public static bool operator < (Vector2I vector, int right) => (vector.X < right) && (vector.Y < right);
	public static bool operator >= (Vector2I vector, int right) => (vector.X >= right) && (vector.Y >= right);
	public static bool operator <= (Vector2I vector, int right) => (vector.X <= right) && (vector.Y <= right);
	
	public static explicit operator Vector2F(Vector2I vector) => new(vector.X, vector.Y);
}
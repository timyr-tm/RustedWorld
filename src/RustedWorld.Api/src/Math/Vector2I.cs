using System.Numerics;

namespace RustedWorld.Api.Math;

public readonly record struct Vector2I(int X, int Y):
	IVectorFunctions<Vector2I>,
	IMinMaxValue<Vector2I>,

	IIncrementOperators<Vector2I>,
	IDecrementOperators<Vector2I>,
	
	IAdditionOperators<Vector2I, Vector2I, Vector2I>,
	IAdditionOperators<Vector2I, int, Vector2I>,
	
	ISubtractionOperators<Vector2I, Vector2I, Vector2I>,
	ISubtractionOperators<Vector2I, int, Vector2I>,
	
	IMultiplyOperators<Vector2I, Vector2I, Vector2I>,
	IMultiplyOperators<Vector2I, int, Vector2I>,
	
	IDivisionOperators<Vector2I, Vector2I, Vector2I>,
	IDivisionOperators<Vector2I, int, Vector2I>
{
	
	#region MinMaxValue
	public static Vector2I MaxValue => new(int.MaxValue, int.MaxValue);
	public static Vector2I MinValue => new(int.MinValue, int.MinValue);
	#endregion

	public static Vector2I Abs(Vector2I vector) => new(System.Math.Abs(vector.X), System.Math.Abs(vector.Y));

	#region IncrementOperators
	public static Vector2I operator ++(Vector2I value) => new(value.X + 1, value.Y + 1);
	#endregion

	#region DecrementOperators
	public static Vector2I operator --(Vector2I value) => new(value.X - 1, value.Y - 1);
	#endregion

	#region AdditionOperators
	public static Vector2I operator +(Vector2I left, Vector2I right) => new(left.X + right.X, left.Y + right.Y);
	public static Vector2I operator +(Vector2I left, int right) => new(left.X + right, left.Y + right);
	#endregion

	#region SubtractionOperators
	public static Vector2I operator -(Vector2I left, Vector2I right) => new(left.X - right.X, left.Y - right.Y);
	public static Vector2I operator -(Vector2I left, int right) => new(left.X - right, left.Y - right);
	#endregion

	#region MultiplyOperators
	public static Vector2I operator *(Vector2I left, Vector2I right) => new(left.X * right.X, left.Y * right.Y);
	public static Vector2I operator *(Vector2I left, int right) => new(left.X * right, left.Y * right);
	#endregion

	#region DivisionOperators
	public static Vector2I operator /(Vector2I left, Vector2I right) => new(left.X / right.X, left.Y / right.Y);
	public static Vector2I operator /(Vector2I left, int right) => new(left.X / right, left.Y / right);
	#endregion
};
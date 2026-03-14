using System.Numerics;

namespace RustedWorld.Api.Math;

public readonly record struct Vector2F(float X, float Y):
	IVectorFunctions<Vector2F>,
	IMinMaxValue<Vector2F>,

	IIncrementOperators<Vector2F>,
	IDecrementOperators<Vector2F>,
	
	IAdditionOperators<Vector2F, Vector2F, Vector2F>,
	IAdditionOperators<Vector2F, float, Vector2F>,
	
	ISubtractionOperators<Vector2F, Vector2F, Vector2F>,
	ISubtractionOperators<Vector2F, float, Vector2F>,
	
	IMultiplyOperators<Vector2F, Vector2F, Vector2F>,
	IMultiplyOperators<Vector2F, float, Vector2F>,
	
	IDivisionOperators<Vector2F, Vector2F, Vector2F>,
	IDivisionOperators<Vector2F, float, Vector2F>
{
	
	#region MinMaxValue
	public static Vector2F MaxValue => new(float.MaxValue, float.MaxValue);
	public static Vector2F MinValue => new(float.MinValue, float.MinValue);
	#endregion

	public static Vector2F Abs(Vector2F vector) => new(System.Math.Abs(vector.X), System.Math.Abs(vector.Y));

	#region IncrementOperators
	public static Vector2F operator ++(Vector2F value) => new(value.X + 1, value.Y + 1);
	#endregion

	#region DecrementOperators
	public static Vector2F operator --(Vector2F value) => new(value.X - 1, value.Y - 1);
	#endregion

	#region AdditionOperators
	public static Vector2F operator +(Vector2F left, Vector2F right) => new(left.X + right.X, left.Y + right.Y);
	public static Vector2F operator +(Vector2F left, float right) => new(left.X + right, left.Y + right);
	#endregion

	#region SubtractionOperators
	public static Vector2F operator -(Vector2F left, Vector2F right) => new(left.X - right.X, left.Y - right.Y);
	public static Vector2F operator -(Vector2F left, float right) => new(left.X - right, left.Y - right);
	#endregion

	#region MultiplyOperators
	public static Vector2F operator *(Vector2F left, Vector2F right) => new(left.X * right.X, left.Y * right.Y);
	public static Vector2F operator *(Vector2F left, float right) => new(left.X * right, left.Y * right);
	#endregion

	#region DivisionOperators
	public static Vector2F operator /(Vector2F left, Vector2F right) => new(left.X / right.X, left.Y / right.Y);
	public static Vector2F operator /(Vector2F left, float right) => new(left.X / right, left.Y / right);
	#endregion
}
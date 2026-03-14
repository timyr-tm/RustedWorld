using System.Numerics;

namespace RustedWorld.Api.Math;

public readonly record struct Vector3F(float X, float Y, float Z):
	IVectorFunctions<Vector3F>,
	IMinMaxValue<Vector3F>,

	IIncrementOperators<Vector3F>,
	IDecrementOperators<Vector3F>,
	
	IAdditionOperators<Vector3F, Vector3F, Vector3F>,
	IAdditionOperators<Vector3F, float, Vector3F>,
	
	ISubtractionOperators<Vector3F, Vector3F, Vector3F>,
	ISubtractionOperators<Vector3F, float, Vector3F>,
	
	IMultiplyOperators<Vector3F, Vector3F, Vector3F>,
	IMultiplyOperators<Vector3F, float, Vector3F>,
	
	IDivisionOperators<Vector3F, Vector3F, Vector3F>,
	IDivisionOperators<Vector3F, float, Vector3F>
{
	#region MinMaxValue
	public static Vector3F MaxValue => new(float.MaxValue, float.MaxValue, float.MaxValue);
	public static Vector3F MinValue => new(float.MinValue, float.MinValue, float.MinValue);
	#endregion

	public static Vector3F Abs(Vector3F vector) => new(System.Math.Abs(vector.X), System.Math.Abs(vector.Y), System.Math.Abs(vector.Z));

	#region IncrementOperators
	public static Vector3F operator ++(Vector3F value) => new(value.X + 1, value.Y + 1, value.Z + 1);
	#endregion

	#region DecrementOperators
	public static Vector3F operator --(Vector3F value) => new(value.X - 1, value.Y - 1, value.Z - 1);
	#endregion

	#region AdditionOperators
	public static Vector3F operator +(Vector3F left, Vector3F right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	public static Vector3F operator +(Vector3F left, float right) => new(left.X + right, left.Y + right, left.Z + right);
	#endregion

	#region SubtractionOperators
	public static Vector3F operator -(Vector3F left, Vector3F right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	public static Vector3F operator -(Vector3F left, float right) => new(left.X - right, left.Y - right, left.Z - right);
	#endregion

	#region MultiplyOperators
	public static Vector3F operator *(Vector3F left, Vector3F right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	public static Vector3F operator *(Vector3F left, float right) => new(left.X * right, left.Y * right, left.Z * right);
	#endregion

	#region DivisionOperators
	public static Vector3F operator /(Vector3F left, Vector3F right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	public static Vector3F operator /(Vector3F left, float right) => new(left.X / right, left.Y / right, left.Z / right);
	#endregion
}
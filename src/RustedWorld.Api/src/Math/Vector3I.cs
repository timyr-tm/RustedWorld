using System.Numerics;

namespace RustedWorld.Api.Math;

public readonly record struct Vector3I(int X, int Y, int Z):
	IVectorFunctions<Vector3I>,
	IMinMaxValue<Vector3I>,

	IIncrementOperators<Vector3I>,
	IDecrementOperators<Vector3I>,
	
	IAdditionOperators<Vector3I, Vector3I, Vector3I>,
	IAdditionOperators<Vector3I, int, Vector3I>,
	
	ISubtractionOperators<Vector3I, Vector3I, Vector3I>,
	ISubtractionOperators<Vector3I, int, Vector3I>,
	
	IMultiplyOperators<Vector3I, Vector3I, Vector3I>,
	IMultiplyOperators<Vector3I, int, Vector3I>,
	
	IDivisionOperators<Vector3I, Vector3I, Vector3I>,
	IDivisionOperators<Vector3I, int, Vector3I>
{
	#region MinMaxValue
	public static Vector3I MaxValue => new(int.MaxValue, int.MaxValue, int.MaxValue);
	public static Vector3I MinValue => new(int.MinValue, int.MinValue, int.MinValue);
	#endregion

	public static Vector3I Abs(Vector3I vector) => new(System.Math.Abs(vector.X), System.Math.Abs(vector.Y), System.Math.Abs(vector.Z));

	#region IncrementOperators
	public static Vector3I operator ++(Vector3I value) => new(value.X + 1, value.Y + 1, value.Z + 1);
	#endregion

	#region DecrementOperators
	public static Vector3I operator --(Vector3I value) => new(value.X - 1, value.Y - 1, value.Z - 1);
	#endregion

	#region AdditionOperators
	public static Vector3I operator +(Vector3I left, Vector3I right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
	public static Vector3I operator +(Vector3I left, int right) => new(left.X + right, left.Y + right, left.Z + right);
	#endregion

	#region SubtractionOperators
	public static Vector3I operator -(Vector3I left, Vector3I right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
	public static Vector3I operator -(Vector3I left, int right) => new(left.X - right, left.Y - right, left.Z - right);
	#endregion

	#region MultiplyOperators
	public static Vector3I operator *(Vector3I left, Vector3I right) => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
	public static Vector3I operator *(Vector3I left, int right) => new(left.X * right, left.Y * right, left.Z * right);
	#endregion

	#region DivisionOperators
	public static Vector3I operator /(Vector3I left, Vector3I right) => new(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
	public static Vector3I operator /(Vector3I left, int right) => new(left.X / right, left.Y / right, left.Z / right);
	#endregion
}
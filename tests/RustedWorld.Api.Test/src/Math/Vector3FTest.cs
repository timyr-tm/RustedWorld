using RustedWorld.Api.Math;

namespace RustedWorld.Api.Test.Math;

public static class Vector3FTest {
	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, 1, 1)]
	[InlineData(-1, -1, -1)]
	public static void Create(float x, float y, float z) {
		Vector3F vector = new(x, y, z);
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}

	[Fact]
	public static void MinValue() {
		Assert.Equal(float.MinValue, Vector3F.MinValue.X);
		Assert.Equal(float.MinValue, Vector3F.MinValue.Y);
	}
	
	[Fact]
	public static void MaxValue() {
		Assert.Equal(float.MaxValue, Vector3F.MaxValue.X);
		Assert.Equal(float.MaxValue, Vector3F.MaxValue.Y);
	}

	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, 1, 1)]
	[InlineData(-1, -1, -1)]
	public static void Increment(float x, float y, float z) {
		Vector3F vector = new(x, y, z);
		vector++;
		Assert.Equal(vector.X, x + 1);
		Assert.Equal(vector.Y, y + 1);
	}
	
	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, 1, 1)]
	[InlineData(-1, -1, -1)]
	public static void Decrement(float x, float y, float z) {
		Vector3F vector = new(x, y, z);
		vector--;
		Assert.Equal(vector.X, x - 1);
		Assert.Equal(vector.Y, y - 1);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	public static void VectorAddition(float x0, float y0, float z0, float x1, float y1, float z1) {
		Vector3F vector = new Vector3F(x0, y0, z0) + new Vector3F(x1, y1, z1);
		Assert.Equal(vector.X, x0 + x1);
		Assert.Equal(vector.Y, y0 + y1);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void FloatAddition(float x0, float y0, float z0, float value) {
		Vector3F vector = new Vector3F(x0, y0, z0) + value;
		Assert.Equal(vector.X, x0 + value);
		Assert.Equal(vector.Y, y0 + value);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	public static void VectorSubtraction(float x0, float y0, float z0, float x1, float y1, float z1) {
		Vector3F vector = new Vector3F(x0, y0, z0) - new Vector3F(x1, y1, z1);
		Assert.Equal(vector.X, x0 - x1);
		Assert.Equal(vector.Y, y0 - y1);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void FloatSubtraction(float x0, float y0, float z0, float value) {
		Vector3F vector = new Vector3F(x0, y0, z0) - value;
		Assert.Equal(vector.X, x0 - value);
		Assert.Equal(vector.Y, y0 - value);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	public static void VectorMultiply(float x0, float y0, float z0, float x1, float y1, float z1) {
		Vector3F vector = new Vector3F(x0, y0, z0) * new Vector3F(x1, y1, z1);
		Assert.Equal(vector.X, x0 * x1);
		Assert.Equal(vector.Y, y0 * y1);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void FloatMultiply(float x0, float y0, float z0, float value)  {
		Vector3F vector = new Vector3F(x0, y0, z0) * value;
		Assert.Equal(vector.X, x0 * value);
		Assert.Equal(vector.Y, y0 * value);
	}
	
	[Theory]
	[InlineData(1, 1, 1, 2, 2, 2)]
	public static void VectorDivision(float x0, float y0, float z0, float x1, float y1, float z1) {
		Vector3F vector = new Vector3F(x0, y0, z0) / new Vector3F(x1, y1, z1);
		Assert.Equal(vector.X, x0 / x1);
		Assert.Equal(vector.Y, y0 / y1);
	}
	
	[Theory]
	[InlineData(1, 1, 1, 2)]
	public static void FloatDivision(float x0, float y0, float z0, float value)  {
		Vector3F vector = new Vector3F(x0, y0, z0) / value;
		Assert.Equal(vector.X, x0 / value);
		Assert.Equal(vector.Y, y0 / value);
	}
}
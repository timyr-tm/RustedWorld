using RustedWorld.Api.Math;

namespace RustedWorld.Api.Test.Math;

public static class Vector3ITest {
	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, 1, 1)]
	[InlineData(-1, -1, -1)]
	public static void Create(int x, int y, int z) {
		Vector3I vector = new(x, y, z);
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}

	[Fact]
	public static void MinValue() {
		Assert.Equal(int.MinValue, Vector3I.MinValue.X);
		Assert.Equal(int.MinValue, Vector3I.MinValue.Y);
	}

	[Fact]
	public static void MaxValue() {
		Assert.Equal(int.MaxValue, Vector3I.MaxValue.X);
		Assert.Equal(int.MaxValue, Vector3I.MaxValue.Y);
	}

	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, 1, 1)]
	[InlineData(-1, -1, -1)]
	public static void Increment(int x, int y, int z) {
		Vector3I vector = new(x, y, z);
		vector++;
		Assert.Equal(vector.X, x + 1);
		Assert.Equal(vector.Y, y + 1);
	}

	[Theory]
	[InlineData(0, 0, 0)]
	[InlineData(1, 1, 1)]
	[InlineData(-1, -1, -1)]
	public static void Decrement(int x, int y, int z) {
		Vector3I vector = new(x, y, z);
		vector--;
		Assert.Equal(vector.X, x - 1);
		Assert.Equal(vector.Y, y - 1);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	public static void VectorAddition(int x0, int y0, int z0, int x1, int y1, int z1) {
		Vector3I vector = new Vector3I(x0, y0, z0) + new Vector3I(x1, y1, z1);
		Assert.Equal(vector.X, x0 + x1);
		Assert.Equal(vector.Y, y0 + y1);
	}

	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void IntAddition(int x0, int y0, int z0, int value) {
		Vector3I vector = new Vector3I(x0, y0, z0) + value;
		Assert.Equal(vector.X, x0 + value);
		Assert.Equal(vector.Y, y0 + value);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	public static void VectorSubtraction(int x0, int y0, int z0, int x1, int y1, int z1) {
		Vector3I vector = new Vector3I(x0, y0, z0) - new Vector3I(x1, y1, z1);
		Assert.Equal(vector.X, x0 - x1);
		Assert.Equal(vector.Y, y0 - y1);
	}

	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void IntSubtraction(int x0, int y0, int z0, int value) {
		Vector3I vector = new Vector3I(x0, y0, z0) - value;
		Assert.Equal(vector.X, x0 - value);
		Assert.Equal(vector.Y, y0 - value);
	}

	[Theory]
	[InlineData(0, 0, 0, 0, 0, 0)]
	public static void VectorMultiply(int x0, int y0, int z0, int x1, int y1, int z1) {
		Vector3I vector = new Vector3I(x0, y0, z0) * new Vector3I(x1, y1, z1);
		Assert.Equal(vector.X, x0 * x1);
		Assert.Equal(vector.Y, y0 * y1);
	}

	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void IntMultiply(int x0, int y0, int z0, int value) {
		Vector3I vector = new Vector3I(x0, y0, z0) * value;
		Assert.Equal(vector.X, x0 * value);
		Assert.Equal(vector.Y, y0 * value);
	}

	[Theory]
	[InlineData(1, 1, 1, 2, 2, 2)]
	public static void VectorDivision(int x0, int y0, int z0, int x1, int y1, int z1) {
		Vector3I vector = new Vector3I(x0, y0, z0) / new Vector3I(x1, y1, z1);
		Assert.Equal(vector.X, x0 / x1);
		Assert.Equal(vector.Y, y0 / y1);
	}

	[Theory]
	[InlineData(1, 1, 1, 2)]
	public static void IntDivision(int x0, int y0, int z0, int value) {
		Vector3I vector = new Vector3I(x0, y0, z0) / value;
		Assert.Equal(vector.X, x0 / value);
		Assert.Equal(vector.Y, y0 / value);
	}
}
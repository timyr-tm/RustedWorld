using RustedWorld.Api.Math;

namespace RustedWorld.Api.Test.Math;

public static class Vector2ITest {
	[Theory]
	[InlineData(0, 0)]
	[InlineData(1, 1)]
	[InlineData(-1, -1)]
	public static void Create(int x, int y) {
		Vector2I vector = new(x, y);
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}

	[Fact]
	public static void MinValue() {
		Assert.Equal(int.MinValue, Vector2I.MinValue.X);
		Assert.Equal(int.MinValue, Vector2I.MinValue.Y);
	}
	
	[Fact]
	public static void MaxValue() {
		Assert.Equal(int.MaxValue, Vector2I.MaxValue.X);
		Assert.Equal(int.MaxValue, Vector2I.MaxValue.Y);
	}

	[Theory]
	[InlineData(0, 0)]
	[InlineData(1, 1)]
	[InlineData(-1, -1)]
	public static void Increment(int x, int y) {
		Vector2I vector = new(x, y);
		vector++;
		Assert.Equal(vector.X, x + 1);
		Assert.Equal(vector.Y, y + 1);
	}
	
	[Theory]
	[InlineData(0, 0)]
	[InlineData(1, 1)]
	[InlineData(-1, -1)]
	public static void Decrement(int x, int y) {
		Vector2I vector = new(x, y);
		vector--;
		Assert.Equal(vector.X, x - 1);
		Assert.Equal(vector.Y, y - 1);
	}

	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void VectorAddition(int x0, int y0, int x1, int y1) {
		Vector2I vector = new Vector2I(x0, y0) + new Vector2I(x1, y1);
		Assert.Equal(vector.X, x0 + x1);
		Assert.Equal(vector.Y, y0 + y1);
	}
	
	[Theory]
	[InlineData(0, 0, 0)]
	public static void IntAddition(int x0, int y0, int value) {
		Vector2I vector = new Vector2I(x0, y0) + value;
		Assert.Equal(vector.X, x0 + value);
		Assert.Equal(vector.Y, y0 + value);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void VectorSubtraction(int x0, int y0, int x1, int y1) {
		Vector2I vector = new Vector2I(x0, y0) - new Vector2I(x1, y1);
		Assert.Equal(vector.X, x0 - x1);
		Assert.Equal(vector.Y, y0 - y1);
	}
	
	[Theory]
	[InlineData(0, 0, 0)]
	public static void IntSubtraction(int x0, int y0, int value) {
		Vector2I vector = new Vector2I(x0, y0) - value;
		Assert.Equal(vector.X, x0 - value);
		Assert.Equal(vector.Y, y0 - value);
	}
	
	[Theory]
	[InlineData(0, 0, 0, 0)]
	public static void VectorMultiply(int x0, int y0, int x1, int y1) {
		Vector2I vector = new Vector2I(x0, y0) * new Vector2I(x1, y1);
		Assert.Equal(vector.X, x0 * x1);
		Assert.Equal(vector.Y, y0 * y1);
	}
	
	[Theory]
	[InlineData(0, 0, 0)]
	public static void IntMultiply(int x0, int y0, int value) {
		Vector2I vector = new Vector2I(x0, y0) * value;
		Assert.Equal(vector.X, x0 * value);
		Assert.Equal(vector.Y, y0 * value);
	}
	
	[Theory]
	[InlineData(1, 1, 2, 2)]
	public static void VectorDivision(int x0, int y0, int x1, int y1) {
		Vector2I vector = new Vector2I(x0, y0) / new Vector2I(x1, y1);
		Assert.Equal(vector.X, x0 / x1);
		Assert.Equal(vector.Y, y0 / y1);
	}
	
	[Theory]
	[InlineData(1, 1, 2)]
	public static void IntDivision(int x0, int y0, int value) {
		Vector2I vector = new Vector2I(x0, y0) / value;
		Assert.Equal(vector.X, x0 / value);
		Assert.Equal(vector.Y, y0 / value);
	}
}
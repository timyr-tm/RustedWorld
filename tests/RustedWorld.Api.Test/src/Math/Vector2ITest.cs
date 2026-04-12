using RustedWorld.Api.Math;
using Xunit.Abstractions;

namespace RustedWorld.Api.Test.Math;

public class Vector2ITest(ITestOutputHelper output) {
	[Fact(DisplayName = "Vector2I.MaxValue")]
	public void MaxValue() => Assert.Equal(Vector2I.MaxValue, new(int.MaxValue, int.MaxValue));
	
	[Fact(DisplayName = "Vector2I.MinValue")]
	public void MinValue() => Assert.Equal(Vector2I.MinValue, new(int.MinValue, int.MinValue));

	[Theory(DisplayName = "Vector2I[int] {get;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void GetValueByIndex(int x, int y) {
		Vector2I vector = new(x, y);
		Assert.Equal(vector[0], x);
		Assert.Equal(vector[1], y);
	}
	
	[Theory(DisplayName = "Vector2I[char] {get;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void GetValueByName(int x, int y) {
		Vector2I vector = new(x, y);
		Assert.Equal(vector['x'], x);
		Assert.Equal(vector['y'], y);
	}
	
	[Theory(DisplayName = "Vector2I[int] {set;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void SetValueByIndex(int x, int y) {
		Vector2I vector = new() {
			[0] = x,
			[1] = y
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}
	
	[Theory(DisplayName = "Vector2I[char] {set;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void SetValueByName(int x, int y) {
		Vector2I vector = new() {
			['x'] = x,
			['y'] = y
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}

	[Theory(DisplayName = "Vector2I.Length()")]
	[InlineData(5, -10)]
	[InlineData(10, -5)]
	[InlineData(-5, 10)]
	[InlineData(-10, 5)]
	public void Length(int x, int y) => Assert.Equal(
		new Vector2I(x, y).Length(),
		MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2))
	);

	[Theory(DisplayName = "Vector2I.Abs()")]
	[InlineData(-1, -5)]
	[InlineData(-5, 1)]
	[InlineData(1, -5)]
	public void Abs(int x, int y) {
		Vector2I vector = new Vector2I(x, y).Abs();
		Assert.Equal(vector.X, int.Abs(x));
		Assert.Equal(vector.Y, int.Abs(y));
	}

	[Theory(DisplayName = "Vector2I.Clamp(int, int)")]
	[InlineData(-10, 10, -5, 5)]
	public void ClampByNumber(int x, int y, int min, int max) {
		Vector2I vector = new Vector2I(x, y).Clamp(min, max);
		Assert.InRange(vector.X, min, max);
		Assert.InRange(vector.Y, min, max);
	}
	
	[Theory(DisplayName = "Vector2I.Clamp(Vector2I, Vector2I)")]
	[InlineData(-10, 10, -5, -5, 5, 5)]
	public void ClampByVector(int x, int y, int minX, int minY, int maxX, int maxY) {
		Vector2I vector = new Vector2I(x, y).Clamp(
			new Vector2I(minX, maxX),
			new Vector2I(minY, maxY)
		);
		Assert.InRange(vector.X, minX, maxX);
		Assert.InRange(vector.Y, minY, maxY);
	}
}
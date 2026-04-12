using RustedWorld.Api.Math;
using Xunit.Abstractions;

namespace RustedWorld.Api.Test.Math;

public class Vector2FTest(ITestOutputHelper output) {
	[Fact(DisplayName = "Vector2F.MaxValue")]
	public void MaxValue() => Assert.Equal(Vector2F.MaxValue, new(float.MaxValue, float.MaxValue));
	
	[Fact(DisplayName = "Vector2F.MinValue")]
	public void MinValue() => Assert.Equal(Vector2F.MinValue, new(float.MinValue, float.MinValue));

	[Theory(DisplayName = "Vector2F[float] {get;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void GetValueByIndex(float x, float y) {
		Vector2F vector = new(x, y);
		Assert.Equal(vector[0], x);
		Assert.Equal(vector[1], y);
	}
	
	[Theory(DisplayName = "Vector2F[char] {get;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void GetValueByName(float x, float y) {
		Vector2F vector = new(x, y);
		Assert.Equal(vector['x'], x);
		Assert.Equal(vector['y'], y);
	}
	
	[Theory(DisplayName = "Vector2F[float] {set;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void SetValueByIndex(float x, float y) {
		Vector2F vector = new() {
			[0] = x,
			[1] = y
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}
	
	[Theory(DisplayName = "Vector2F[char] {set;}")]
	[InlineData(2, 4)]
	[InlineData(7, 3)]
	public void SetValueByName(float x, float y) {
		Vector2F vector = new() {
			['x'] = x,
			['y'] = y
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
	}

	[Theory(DisplayName = "Vector2F.Length()")]
	[InlineData(5, -10)]
	[InlineData(10, -5)]
	[InlineData(-5, 10)]
	[InlineData(-10, 5)]
	public void Length(float x, float y) => Assert.Equal(
		new Vector2F(x, y).Length(),
		MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2))
	);

	[Theory(DisplayName = "Vector2F.Abs()")]
	[InlineData(-1, -5)]
	[InlineData(-5, 1)]
	[InlineData(1, -5)]
	public void Abs(float x, float y) {
		Vector2F vector = new Vector2F(x, y).Abs();
		Assert.Equal(vector.X, float.Abs(x));
		Assert.Equal(vector.Y, float.Abs(y));
	}

	[Theory(DisplayName = "Vector2F.Clamp(float, float)")]
	[InlineData(-10, 10, -5, 5)]
	public void Clamp(float x, float y, float min, float max) {
		Vector2F vector = new Vector2F(x, y).Clamp(min, max);
		Assert.InRange(vector.X, min, max);
		Assert.InRange(vector.Y, min, max);
	}

	[Theory(DisplayName = "Vector2F.Clamp(int, MidpointRounding)")]
	[InlineData(System.Math.PI, System.Math.PI, 3, MidpointRounding.ToEven)]
	public void Round(float x, float y, int digits, MidpointRounding mode) {
		Vector2F vector = new Vector2F(x, y).Round(digits, mode);
		Assert.Equal(vector.X, float.Round(x, digits, mode), digits, mode);
		Assert.Equal(vector.Y, float.Round(y, digits, mode), digits, mode);
	}
}
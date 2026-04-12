using RustedWorld.Api.Math;
using Xunit.Abstractions;

namespace RustedWorld.Api.Test.Math;

public class Vector3ITest(ITestOutputHelper output) {
	[Fact(DisplayName = "Vector3I.MaxValue")]
	public void MaxValue() => Assert.Equal(Vector3I.MaxValue, new(int.MaxValue, int.MaxValue, int.MaxValue));
	
	[Fact(DisplayName = "Vector3I.MinValue")]
	public void MinValue() => Assert.Equal(Vector3I.MinValue, new(int.MinValue, int.MinValue, int.MinValue));

	[Theory(DisplayName = "Vector3I[int] {get;}")]
	[InlineData(2, 4, 6)]
	[InlineData(7, 3, 4)]
	public void GetValueByIndex(int x, int y, int z) {
		Vector3I vector = new(x, y, z);
		Assert.Equal(vector[0], x);
		Assert.Equal(vector[1], y);
		Assert.Equal(vector[2], z);
	}
	
	[Theory(DisplayName = "Vector3I[char] {get;}")]
	[InlineData(2, 4, 6)]
	[InlineData(7, 3, 4)]
	public void GetValueByName(int x, int y, int z) {
		Vector3I vector = new(x, y, z);
		Assert.Equal(vector['x'], x);
		Assert.Equal(vector['y'], y);
		Assert.Equal(vector['z'], z);
	}
	
	[Theory(DisplayName = "Vector3I[int] {set;}")]
	[InlineData(2, 4, 6)]
	[InlineData(7, 3, 4)]
	public void SetValueByIndex(int x, int y, int z) {
		Vector3I vector = new() {
			[0] = x,
			[1] = y,
			[2] = z
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
		Assert.Equal(vector.Z, z);
	}
	
	[Theory(DisplayName = "Vector3I[char] {set;}")]
	[InlineData(2, 4, 6)]
	[InlineData(7, 3, 4)]
	public void SetValueByName(int x, int y, int z) {
		Vector3I vector = new() {
			['x'] = x,
			['y'] = y,
			['z'] = z
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
		Assert.Equal(vector.Z, z);
	}

	[Theory(DisplayName = "Vector3I.Length()")]
	[InlineData(5, -10, 7)]
	[InlineData(10, -5, 7)]
	[InlineData(-5, 10, -7)]
	[InlineData(-10, 5, 7)]
	public void Length(int x, int y, int z) => Assert.Equal(
		new Vector3I(x, y, z).Length(),
		MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2) + MathF.Pow(z, 2))
	);

	[Theory(DisplayName = "Vector3I.Abs()")]
	[InlineData(-1, -5, -7)]
	[InlineData(-5, 1, 2)]
	[InlineData(1, -5, -4)]
	public void Abs(int x, int y, int z) {
		Vector3I vector = new Vector3I(x, y, z).Abs();
		Assert.Equal(vector.X, int.Abs(x));
		Assert.Equal(vector.Y, int.Abs(y));
		Assert.Equal(vector.Z, int.Abs(z));
	}

	[Theory(DisplayName = "Vector3I.Clamp(int, int)")]
	[InlineData(-10, 10, 15, -5, 5)]
	public void Clamp(int x, int y, int z, int min, int max) {
		Vector3I vector = new Vector3I(x, y, z).Clamp(min, max);
		Assert.InRange(vector.X, min, max);
		Assert.InRange(vector.Y, min, max);
		Assert.InRange(vector.Z, min, max);
	}
}
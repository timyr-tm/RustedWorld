using RustedWorld.Api.Math;
using Xunit.Abstractions;

namespace RustedWorld.Api.Test.Math;

public class Vector3FTest(ITestOutputHelper output) {
	[Fact(DisplayName = "Vector3F.MaxValue")]
	public void MaxValue() => Assert.Equal(Vector3F.MaxValue, new(float.MaxValue, float.MaxValue, float.MaxValue));
	
	[Fact(DisplayName = "Vector3F.MinValue")]
	public void MinValue() => Assert.Equal(Vector3F.MinValue, new(float.MinValue, float.MinValue, float.MinValue));

	[Theory(DisplayName = "Vector3F[float] {get;}")]
	[InlineData(2.5, 4.7, 3.9)]
	[InlineData(7.9, 3.9, 2.4)]
	public void GetValueByIndex(float x, float y, float z) {
		Vector3F vector = new(x, y, z);
		Assert.Equal(vector[0], x, 2);
		Assert.Equal(vector[1], y, 2);
		Assert.Equal(vector[2], z, 2);
	}
	
	[Theory(DisplayName = "Vector3F[char] {get;}")]
	[InlineData(2.5, 4.7, 3.9)]
	[InlineData(7.9, 3.9, 2.4)]
	public void GetValueByName(float x, float y, float z) {
		Vector3F vector = new(x, y, z);
		Assert.Equal(vector['x'], x);
		Assert.Equal(vector['y'], y);
		Assert.Equal(vector['z'], z);
	}
	
	[Theory(DisplayName = "Vector3F[float] {set;}")]
	[InlineData(2.5, 4.7, 3.9)]
	[InlineData(7.9, 3.9, 2.4)]
	public void SetValueByIndex(float x, float y, float z) {
		Vector3F vector = new() {
			[0] = x,
			[1] = y,
			[2] = z
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Y, y);
		Assert.Equal(vector.Z, z);
	}
	
	[Theory(DisplayName = "Vector3F[char] {set;}")]
	[InlineData(2.5, 4.7, 3.9)]
	[InlineData(7.9, 3.9, 2.4)]
	public void SetValueByName(float x, float y, float z) {
		Vector3F vector = new() {
			['x'] = x,
			['y'] = y,
			['z'] = z
		};
		Assert.Equal(vector.X, x);
		Assert.Equal(vector.Z, z);
	}

	[Theory(DisplayName = "Vector3F.Length()")]
	[InlineData(5.4, -10.2, 6.9)]
	[InlineData(-10.2, -5.4, -6.9)]
	[InlineData(-5.4, 10.2, 6.9)]
	[InlineData(-10.2, 5.5, -6.9)]
	public void Length(float x, float y, float z) => Assert.Equal(
		new Vector3F(x, y, z).Length(),
		MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2) + MathF.Pow(z, 2))
	);

	[Theory(DisplayName = "Vector3F.Abs()")]
	[InlineData(5.4, -10.2, 6.9)]
	[InlineData(-10.2, -5.4, -6.9)]
	[InlineData(-5.4, 10.2, 6.9)]
	[InlineData(-10.2, 5.5, -6.9)]
	public void Abs(float x, float y, float z) {
		Vector3F vector = new Vector3F(x, y, z).Abs();
		Assert.Equal(vector.X, float.Abs(x));
		Assert.Equal(vector.Y, float.Abs(y));
		Assert.Equal(vector.Z, float.Abs(z));
	}

	[Theory(DisplayName = "Vector3F.Clamp(float, float)")]
	[InlineData(-10.9, 10.2, 10.5, -5, 5)]
	public void ClampByNumber(float x, float y, float z,float min, float max) {
		Vector3F vector = new Vector3F(x, y, z).Clamp(min, max);
		Assert.InRange(vector.X, min, max);
		Assert.InRange(vector.Y, min, max);
		Assert.InRange(vector.Z, min, max);
	}
	
	[Theory(DisplayName = "Vector3F.Clamp(Vector3F, Vector3F)")]
	[InlineData(-10.9, 10.2, 10.5, -5, -5, -5, 5, 5, 5)]
	public void ClampByVector(float x, float y, float z, float minX, float minY, float minZ, float maxX, float maxY, float maxZ) {
		Vector3F vector = new Vector3F(x, y, z).Clamp(
			new Vector3F(minX, minY, minZ),
			new Vector3F(maxX, maxY, maxZ)
		);
		Assert.InRange(vector.X, minX, maxX);
		Assert.InRange(vector.Y, minY, maxY);
		Assert.InRange(vector.Z, minZ, maxZ);
	}
}
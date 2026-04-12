using GodotVector2I = Godot.Vector2I;
using GodotVector2F = Godot.Vector2;
using GodotVector3I = Godot.Vector3I;
using GodotVector3F = Godot.Vector3;

using ApiVector2I = RustedWorld.Api.Math.Vector2I;
using ApiVector2F = RustedWorld.Api.Math.Vector2F;
using ApiVector3I = RustedWorld.Api.Math.Vector3I;
using ApiVector3F = RustedWorld.Api.Math.Vector3F;

namespace RustedWorld.Api.Extensions.Godot.Math;

public static class VectorConversionExtension {
	public static GodotVector2I ToVector(this ApiVector2I vector) => new(vector.X, vector.Y);
	public static GodotVector2F ToVector(this ApiVector2F vector) => new(vector.X, vector.Y);
	public static GodotVector3I ToVector(this ApiVector3I vector) => new(vector.X, vector.Y, vector.Z);
	public static GodotVector3F ToVector(this ApiVector3F vector) => new(vector.X, vector.Y, vector.Z);
	
	public static ApiVector2I ToVector(this GodotVector2I vector) => new(vector.X, vector.Y);
	public static ApiVector2F ToVector(this GodotVector2F vector) => new(vector.X, vector.Y);
	public static ApiVector3I ToVector(this GodotVector3I vector) => new(vector.X, vector.Y, vector.Z);
	public static ApiVector3F ToVector(this GodotVector3F vector) => new(vector.X, vector.Y, vector.Z);
}
namespace RustedWorld.Api.Math;

public interface IVectorFunctions<TSelf> where TSelf: IVectorFunctions<TSelf> {
	public static abstract TSelf Abs(TSelf vector);
}
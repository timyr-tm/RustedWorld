using RustedWorld.Api.Registration;

namespace RustedWorld.Api.Test.Registration;

public static class RegistrationPathTest {
	[Theory]
	[InlineData("test", new[] {"a", "b", "c"})]
	[InlineData("_-.", new[] {"_-.", "_-.", "_-."})]
	public static void CreateFromItems(string modId, string[] path) => Assert.True(
		Record.Exception(() => new RegistrationPath(modId, path)) is null
	);
	
	[Theory]
	[InlineData("test:/a/b/c")]
	[InlineData("_-.:/-_./-_.")]
	public static void CreateFromString(string path) => Assert.True(
		Record.Exception(() => new RegistrationPath(path)) is null
	);
}
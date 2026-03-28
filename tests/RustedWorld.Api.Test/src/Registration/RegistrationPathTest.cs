using RustedWorld.Api.Registration;

namespace RustedWorld.Api.Test.Registration;

public static class RegistrationPathTest {
	[Theory]
	[InlineData("mod_id", "item.1", "item.2")]
	public static void CreateFromItems(string modId, params string[] items) => Assert.True(
		Record.Exception(() => new RegistrationPath(modId, items)) is null
	);
	
	[Theory]
	[InlineData("mod-id:/item.1/item.2/")]
	public static void CreateFromString(string path) => Assert.True(
		Record.Exception(() => new RegistrationPath(path)) is null
	);
}
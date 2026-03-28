using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace RustedWorld.Api.Registration;

public readonly partial record struct RegistrationPath {
	[GeneratedRegex(@"^[^\s]|[\w\._]+$", RegexOptions.Singleline)]
	private static partial Regex PathItemRegex { get; }
	
	[GeneratedRegex(@"^(?'ModId'[^\s]|[\w\._]+):(?:/(?'Item'[^\s]|[\w\._]+))+/?$", RegexOptions.Singleline)]
	private static partial Regex FullPathRegex { get; }

	public readonly string ModId;
	public readonly ImmutableArray<string> Items;
	
	private readonly int _hashCode;
	
	public RegistrationPath(string modId, params string[] items) {
		ModId = PathItemRegex.IsMatch(modId)
			? modId
			: throw new ArgumentException("Incorrect argument format", nameof(modId));
		Items = items.All(item => PathItemRegex.IsMatch(item))
			? [..items]
			: throw new ArgumentException("Incorrect argument format", nameof(items));
		_hashCode = GenerateHashCode();
	}

	public RegistrationPath(string path) {
		Match match = FullPathRegex.Match(path);
		if (!match.Success)
			throw new ArgumentException("Incorrect argument format", nameof(path));
		ModId = match.Groups["ModId"].Value;
		Items = [..match.Groups["Item"].Captures.Select(item => item.Value)];
		_hashCode = GenerateHashCode();
	}
	
	private int GenerateHashCode() => Items.Aggregate(ModId.GetHashCode(), (code, item) => code ^ item.GetHashCode());

	public override string ToString() => $"{ModId}:/{string.Join("/", Items)}";

	public override int GetHashCode() => _hashCode;

	public static RegistrationPath operator +(RegistrationPath path, string item) => new(path.ModId, [..path.Items, item]);
	public static RegistrationPath operator +(RegistrationPath path, string[] items) => new(path.ModId, [..path.Items, ..items]);
}
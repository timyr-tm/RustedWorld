using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace RustedWorld.Api.Registration;

public readonly record struct RegistrationPath:
	IAdditionOperators<RegistrationPath, string, RegistrationPath>,
	IAdditionOperators<RegistrationPath, IReadOnlyCollection<string>, RegistrationPath>
{
	private static readonly Regex PathItemRegex = new(
		@"^[\w\.\-]+$", RegexOptions.Compiled | RegexOptions.Singleline
	);
	
	private static readonly Regex PathRegex = new(
		@"^(?<ModId>[\w\.\-]+):(?:\/(?<Path>[\w\.\-]+))+$",
		RegexOptions.Compiled | RegexOptions.Singleline
	);

	public readonly string ModId;
	public readonly IReadOnlyCollection<string> Items = [];
	
	public RegistrationPath(string modId, params string[] items) {
		ModId = PathItemRegex.IsMatch(modId)
			? modId
			: throw new ArgumentException("Incorrect argument format", nameof(modId));
		Items = items.All(item => PathItemRegex.IsMatch(item))
			? items.ToArray()
			: throw new ArgumentException("Incorrect argument format", nameof(items));
	}

	public RegistrationPath(string path) {
		Match match = PathRegex.Match(path);
		if (!match.Success)
			throw new ArgumentException("Incorrect argument format", nameof(path));
		ModId = match.Groups["ModId"].Value;
		Items = match.Groups["Path"].Captures.Select(item => item.Value).ToList();
	}

	public override string ToString() => $"{ModId}:/{string.Join("/", Items)}";

	public override int GetHashCode() {
		HashCode hashCode = new();
		hashCode.Add(ModId);
		foreach (string item in Items)
			hashCode.Add(item);
		return hashCode.ToHashCode();
	}

	public static RegistrationPath operator +(RegistrationPath path, string item) => new(path.ModId, [..path.Items, item]);
	public static RegistrationPath operator +(RegistrationPath path, IReadOnlyCollection<string> items) => new(path.ModId, [..path.Items, ..items]);
}
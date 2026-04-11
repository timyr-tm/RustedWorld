using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace RustedWorld.Api.Registration;

public partial class RegistrationPath: IEquatable<RegistrationPath> {
	[GeneratedRegex(@"^[\.\-\w-[\s]]+$", RegexOptions.Singleline)]
	private static partial Regex PathItemRegex { get; }
	
	[GeneratedRegex(@"^(?'Namespace'[\.\-\w-[\s]]+):(?:/?(?'Item'[\.\-\w-[\s]]+))+/?$", RegexOptions.Singleline)]
	private static partial Regex FullPathRegex { get; }

	public readonly string Namespace;
	public readonly ImmutableArray<string> Items;
	
	private readonly int _hashCode;
	
	public RegistrationPath(string @namespace, params ICollection<string> items) {
		Namespace = PathItemRegex.IsMatch(@namespace)
			? @namespace
			: throw new ArgumentException("Incorrect argument format", nameof(@namespace));
		Items = items.All(item => PathItemRegex.IsMatch(item))
			? [..items]
			: throw new ArgumentException("Incorrect argument format", nameof(items));
		_hashCode = GenerateHashCode();
	}

	public RegistrationPath(string path) {
		Match match = FullPathRegex.Match(path);
		if (!match.Success)
			throw new ArgumentException("Incorrect argument format", nameof(path));
		Namespace = match.Groups["Namespace"].Value;
		Items = [..match.Groups["Item"].Captures.Select(item => item.Value)];
		_hashCode = GenerateHashCode();
	}
	
	private int GenerateHashCode() => Items
		.Index()
		.Aggregate(Namespace.GetHashCode(), (code, item) => code ^ item.Index ^ item.Item.GetHashCode());

	public override string ToString() => $"{Namespace}:{string.Join('/', Items)}";

	public bool Equals(RegistrationPath? other) => other?.GetHashCode() == GetHashCode();
	public override bool Equals(object? obj) => Equals(obj as RegistrationPath);

	public override int GetHashCode() => _hashCode;

	public static RegistrationPath operator /(RegistrationPath path, string item) => new(path.Namespace, [..path.Items, item]);
	public static RegistrationPath operator /(RegistrationPath path, string[] items) => new(path.Namespace, [..path.Items, ..items]);

	public static implicit operator string(RegistrationPath path) => path.ToString();
	public static implicit operator RegistrationPath(string path) => new(path);
}
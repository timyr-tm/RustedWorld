using System.Collections.Generic;
using Godot;
using Serilog.Core;
using Serilog.Events;

namespace RustedWorld.Game.Logging;

public class GodotConsoleSink: ILogEventSink {
	public void Emit(LogEvent @event) => GD.PrintRich(
		$"[color=green][{@event.Timestamp:G}][/color] ",
		$"[color=blue][{@event.Properties["SourceContext"]}][/color] ",
		$"[color=#{GetLogLevelColor(@event.Level).ToRgba32():X}][{@event.Level}][/color] ",
		@event.MessageTemplate.Render(@event.Properties)
	);

	private static Color GetLogLevelColor(LogEventLevel level) => level switch {
		LogEventLevel.Debug => Colors.Gray,
		LogEventLevel.Information => Colors.White,
		LogEventLevel.Warning => Colors.Yellow,
		LogEventLevel.Error => Colors.Orange,
		LogEventLevel.Fatal => Colors.Red,
		_ => Colors.White
	};
}
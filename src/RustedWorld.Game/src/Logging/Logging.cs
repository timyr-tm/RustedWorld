using System;
using Godot;
using Serilog;
using Serilog.Formatting.Json;

namespace RustedWorld.Game.Logging;

public partial class Logging: Node {
	private readonly string _logPath = ProjectSettings.GlobalizePath($"user://logs/{DateTime.Now.ToBinary():X}.jsonl");
	
	public override void _EnterTree() => Log.Logger = new LoggerConfiguration()
		.MinimumLevel.Debug()
		.Enrich.WithProperty("SourceContext", "Unknown")
		.WriteTo.File(new JsonFormatter(), _logPath)
		.WriteTo.Sink(new GodotConsoleSink())
		.CreateLogger();

	public override void _Ready() {
		ILogger logger = Log.ForContext<Logging>();
		logger.Debug("Log file path: {LogPath}", _logPath);
		logger.Information("Ready");
	}
	
	public override void _ExitTree() => Log.CloseAndFlush();
}
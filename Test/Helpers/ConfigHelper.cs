﻿using Newtonsoft.Json;

namespace SchemaZen.Tests;

public static class ConfigHelper {
	private static readonly IDictionary<string, string> config;

	static ConfigHelper() {
		var settingsString = File.ReadAllText("appsettings.json");
		config = JsonConvert.DeserializeObject<IDictionary<string, string>>(settingsString);
	}

	public static string TestDB => GetSetting("testdb");

	public static string TestSchemaDir => GetSetting("test_schema_dir");

	public static string SqlDbDiffPath => GetSetting("SqlDbDiffPath");

	private static string GetSetting(string key) {
		var val = Environment.GetEnvironmentVariable(key);
		return val ?? (config.TryGetValue(key, out val) ? val : null);
	}
}

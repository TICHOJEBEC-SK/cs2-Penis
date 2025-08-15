using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace Penis.Config;

public class PluginConfig : BasePluginConfig
{
    [JsonPropertyName("CooldownSeconds")] public int CooldownSeconds { get; set; } = 120;
    [JsonPropertyName("MinSizeCm")] public double MinSizeCm { get; set; } = 1.00;
    [JsonPropertyName("MaxSizeCm")] public double MaxSizeCm { get; set; } = 50.99;
    [JsonPropertyName("Language")] public string Language { get; set; } = "sk";
    [JsonPropertyName("ChatPrefix")] public string ChatPrefix { get; set; } = " {lightred}[CICINA]";
    [JsonPropertyName("RandomCommand")] public string RandomCommand { get; set; } = "css_cicina";
    [JsonPropertyName("RealCommand")] public string RealCommand { get; set; } = "css_realcicina";
}
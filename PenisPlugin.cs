using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;
using Penis.Config;
using Penis.Services;

namespace Penis;

public class PenisPlugin : BasePlugin, IPluginConfig<PluginConfig>
{
    public override string ModuleName => "Penis";
    public override string ModuleVersion => "1.2";
    public override string ModuleAuthor => "TICHOJEBEC";

    private readonly Cooldowns _cooldowns = new();
    private Localization _l = null!;
    private readonly SizeGenerator _sizeGen = new();
    private Chat _chat = null!;

    private string? _registeredRandomCmd;
    private string? _registeredRealCmd;

    public PluginConfig Config { get; set; } = new();

    public void OnConfigParsed(PluginConfig config)
    {
        if (config.CooldownSeconds < 0) config.CooldownSeconds = 0;
        if (config.MinSizeCm < 0.01) config.MinSizeCm = 0.01;
        if (config.MaxSizeCm <= config.MinSizeCm) config.MaxSizeCm = config.MinSizeCm + 1.0;
        if (string.IsNullOrWhiteSpace(config.Language)) config.Language = "en";
        if (string.IsNullOrWhiteSpace(config.ChatPrefix)) config.ChatPrefix = "[PENIS]";
        if (string.IsNullOrWhiteSpace(config.RandomCommand)) config.RandomCommand = "css_cicina";
        if (string.IsNullOrWhiteSpace(config.RealCommand)) config.RealCommand = "css_realnacicina";
        if (string.Equals(config.RandomCommand, config.RealCommand, StringComparison.OrdinalIgnoreCase))
            config.RealCommand = config.RandomCommand + "_real";

        Config = config;
    }

    public override void Load(bool hotReload)
    {
        var langDir = Path.Combine(ModuleDirectory, "lang");
        _l = new Localization(langDir, Config.Language);
        _chat = new Chat();

        RegisterCommandOnce(ref _registeredRandomCmd, Config.RandomCommand, "Random penis size", OnCmdRandom);
        RegisterCommandOnce(ref _registeredRealCmd, Config.RealCommand, "Deterministic penis size (by name)",
            OnCmdReal);
    }

    private void RegisterCommandOnce(ref string? tracker, string name, string help,
        CommandInfo.CommandCallback callback)
    {
        if (string.Equals(tracker, name, StringComparison.OrdinalIgnoreCase)) return;
        AddCommand(name, help, callback);
        tracker = name;
    }

    private string Pref(string s) => $"{Config.ChatPrefix} {s}";
    
    private void OnCmdRandom(CCSPlayerController? caller, CommandInfo info)
    {
        if (!_chat.ValidateCaller(caller)) return;
        var player = caller!;
        if (!_cooldowns.TryStart(player, Config.CooldownSeconds, out var remaining))
        {
            _chat.ToPlayer(player, Pref(_l["Cooldown"]), (int)Math.Ceiling(remaining.TotalSeconds));
            return;
        }

        var size = _sizeGen.RandomSize(Config.MinSizeCm, Config.MaxSizeCm);
        _chat.ToAllFmt(Pref(_l["RandomResult"]), _chat.Name(player), size);
    }
    
    private void OnCmdReal(CCSPlayerController? caller, CommandInfo info)
    {
        if (!_chat.ValidateCaller(caller)) return;
        var player = caller!;
        if (!_cooldowns.TryStart(player, Config.CooldownSeconds, out var remaining))
        {
            _chat.ToPlayer(player, Pref(_l["Cooldown"]), (int)Math.Ceiling(remaining.TotalSeconds));
            return;
        }

        var size = _sizeGen.DeterministicSize(_chat.Name(player), Config.MinSizeCm, Config.MaxSizeCm);
        _chat.ToAllFmt(Pref(_l["RealResult"]), _chat.Name(player), size);
    }
    
}
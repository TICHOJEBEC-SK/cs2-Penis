using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;

namespace Penis;

public class Penis : BasePlugin
{
    private readonly Dictionary<CCSPlayerController, DateTime> _playerLastCommandTime = new();
    private static readonly Random Random = new();

    public override string ModuleAuthor => "TICHOJEBEC";
    public override string ModuleName => "Penis";
    public override string ModuleVersion => "v1.1";

    private const int CooldownSeconds = 15;

    private bool IsOnCooldown(CCSPlayerController player, out double remainingSeconds)
    {
        if (_playerLastCommandTime.TryGetValue(player, out var lastTime))
        {
            var elapsed = DateTime.Now - lastTime;
            if (elapsed.TotalSeconds < CooldownSeconds)
            {
                remainingSeconds = CooldownSeconds - elapsed.TotalSeconds;
                return true;
            }
        }

        remainingSeconds = 0;
        return false;
    }

    private void SendCooldownMessage(CCSPlayerController player, double remainingSeconds)
    {
        player.PrintToChat(
            $" {ChatColors.Red}𝗖𝗦𝗞𝗢.𝗡𝗘𝗧 ● {ChatColors.Default}" +
            $"Tento príkaz môžeš použiť iba raz za {ChatColors.Red}{remainingSeconds:F0} {ChatColors.Default}sekúnd."
        );
    }

    private double GeneratePenisSize(string playerName)
    {
        var seed = playerName.GetHashCode();
        var seededRandom = new Random(seed);
        return seededRandom.Next(1, 51) + seededRandom.NextDouble();
    }

    private void AnnouncePenisSize(CCSPlayerController player, double size, bool isReal)
    {
        var formattedSize = size.ToString("0.00");
        var prefix = isReal ? "reálnu " : "";
        Server.PrintToChatAll(
            $" {ChatColors.Red}𝗖𝗦𝗞𝗢.𝗡𝗘𝗧 ● {ChatColors.Default}" +
            $"Hráč {ChatColors.Green}{player.PlayerName}{ChatColors.Default} má {prefix}{ChatColors.Green}{formattedSize} {ChatColors.Default}centimetrovú cicinu."
        );
    }

    [ConsoleCommand("css_cicina", "Odmerá tvoju cicinu")]
    public void OnPenisCommand(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot || player.IsHLTV)
            return;

        if (IsOnCooldown(player, out var remaining))
        {
            SendCooldownMessage(player, remaining);
            return;
        }

        var penisSize = Random.Next(1, 51) + Random.NextDouble();
        AnnouncePenisSize(player, penisSize, false);
        _playerLastCommandTime[player] = DateTime.Now;
    }

    [ConsoleCommand("css_realcicina", "Odmerá tvoju cicinu na základe mena")]
    public void OnRealPenisCommand(CCSPlayerController? player, CommandInfo command)
    {
        if (player == null || !player.IsValid || player.IsBot || player.IsHLTV)
            return;

        if (IsOnCooldown(player, out var remaining))
        {
            SendCooldownMessage(player, remaining);
            return;
        }

        var penisSize = GeneratePenisSize(player.PlayerName);
        AnnouncePenisSize(player, penisSize, true);
        _playerLastCommandTime[player] = DateTime.Now;
    }
}
using System.Collections.Concurrent;
using CounterStrikeSharp.API.Core;

namespace Penis.Services;

public class Cooldowns
{
    private readonly ConcurrentDictionary<ulong, DateTime> _lastUse = new();

    public bool TryStart(CCSPlayerController player, int cooldownSeconds, out TimeSpan remaining)
    {
        remaining = TimeSpan.Zero;
        if (cooldownSeconds <= 0)
        {
            _lastUse[player.SteamID] = DateTime.UtcNow;
            return true;
        }

        var now = DateTime.UtcNow;
        if (_lastUse.TryGetValue(player.SteamID, out var last))
        {
            var next = last.AddSeconds(cooldownSeconds);
            if (now < next)
            {
                remaining = next - now;
                return false;
            }
        }

        _lastUse[player.SteamID] = now;
        return true;
    }
}
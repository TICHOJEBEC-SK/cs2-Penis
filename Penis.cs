using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Utils;

namespace Penis
{
    public partial class Penis : BasePlugin
    {
        private readonly Dictionary<CCSPlayerController, DateTime> playerLastCommandTime = new Dictionary<CCSPlayerController, DateTime>();

        public override string ModuleAuthor => "TICHOJEBEC";
        public override string ModuleName => "Penis";
        public override string ModuleVersion => "v1.0";

        private double GeneratePenisSize(string playerName)
        {
            int seed = playerName.GetHashCode();
            Random random = new Random(seed);
            return (random.Next(1, 51) + random.NextDouble());
        }

        [ConsoleCommand("css_cicina", "Odmerá tvoju cicinu")]
        public void OnPenisCommand(CCSPlayerController? player, CommandInfo command)
        {
            if (player == null || !player.IsValid || player.IsBot || player.IsHLTV)
            {
                return;
            }

            if (playerLastCommandTime.TryGetValue(player, out DateTime lastCommandTime))
            {
                var elapsedTime = (DateTime.Now - lastCommandTime).TotalSeconds;
                if (elapsedTime < 120)
                {
                    var remainingTime = 120 - elapsedTime;
                    player.PrintToChat($" {ChatColors.Red}𝗖𝗦𝗞𝗢.𝗡𝗘𝗧 ● {ChatColors.Default}Tento príkaz môžeš použiť iba raz za {ChatColors.Red}{remainingTime:F0} {ChatColors.Default}sekúnd.");
                    return;
                }
            }

            Random random = new Random();
            double penisSize = random.Next(1, 51) + random.NextDouble();
            string formattedPenisSize = penisSize.ToString("0.00");

            Server.PrintToChatAll($" {ChatColors.Red}𝗖𝗦𝗞𝗢.𝗡𝗘𝗧 ● {ChatColors.Default}Hráč {ChatColors.Green}{player.PlayerName}{ChatColors.Default} má {ChatColors.Green}{formattedPenisSize} {ChatColors.Default}centimetrovú cicinu.");
            playerLastCommandTime[player] = DateTime.Now;
        }

        [ConsoleCommand("css_realcicina", "Odmerá tvoju cicinu na základe mena")]
        public void OnRealPenisCommand(CCSPlayerController? player, CommandInfo command)
        {
            if (player == null || !player.IsValid || player.IsBot || player.IsHLTV)
            {
                return;
            }

            if (playerLastCommandTime.TryGetValue(player, out DateTime lastCommandTime))
            {
                var elapsedTime = (DateTime.Now - lastCommandTime).TotalSeconds;
                if (elapsedTime < 120)
                {
                    var remainingTime = 120 - elapsedTime;
                    player.PrintToChat($" {ChatColors.Red}𝗖𝗦𝗞𝗢.𝗡𝗘𝗧 ● {ChatColors.Default}Tento príkaz môžeš použiť iba raz za {ChatColors.Red}{remainingTime:F0} {ChatColors.Default}sekúnd.");
                    return;
                }
            }

            double penisSize = GeneratePenisSize(player.PlayerName);
            string formattedPenisSize = penisSize.ToString("0.00");

            Server.PrintToChatAll($" {ChatColors.Red}𝗖𝗦𝗞𝗢.𝗡𝗘𝗧 ● {ChatColors.Default}Hráč {ChatColors.Green}{player.PlayerName}{ChatColors.Default} má reálnu {ChatColors.Green}{formattedPenisSize} {ChatColors.Default}centimetrovú cicinu.");
            playerLastCommandTime[player] = DateTime.Now;
        }
    }
}
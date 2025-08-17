<h1 align="center">
  CS2 Penis
</h1>

<p align="center">
<i>Loved the tool? Please consider <a href="https://paypal.com/paypalme/playpointsk">donating</a> 💸 to help it improve!</i>
</p>

<p align="center">
<a href="https://www.paypal.com/paypalme/playpointsk"><img src="https://img.shields.io/badge/support-PayPal-blue?logo=PayPal&style=flat-square&label=Donate"/>
</a>
</p>

---

## 📜 About the Plugin

A **fun Counter-Strike 2 plugin** for **CounterStrikeSharp** that lets players measure their “penis” size in chat.  
It includes two commands — a random measurement and a deterministic “real” one based on the player’s name.  
Inspired by Slovak streamer [2SekundovyMato](https://www.youtube.com/@2SekundovyMato).

The plugin supports:
- **Configurable command names** (change `css_cicina` to anything you want)
- **Configurable cooldown, size range, and prefix**
- **Color codes** in translations and prefix (`{lightred}`, `{default}`, …)
- **Language files** (`en.json`, `sk.json`) for easy localization
- **Shared cooldown system** with optional manual reset

---

## 🔹 Commands

1. **`css_cicina`** – *Random size*
   - Random value between **1.00 cm** and **50.99 cm** (range configurable in config).
   - Cooldown per player (default: 120s, configurable).
   - Broadcasts to all players.

2. **`css_realcicina`** – *Deterministic size*
   - Based on player name → always the same for the same name (per server run).
   - Same cooldown and broadcast rules as random.

---

## 🛠 Installation

**Requirements**
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

**Steps**
1. Build the plugin (`dotnet build -c Release`) or download prebuilt.
2. Copy the DLL and `lang/` folder to:
   ```
   /game/csgo/addons/counterstrikesharp/plugins/Penis/
   ```
3. Start or restart the server.

---

## ⚙️ Configuration

Config is generated on first run:
```
{
  "ChatPrefix": "[PENIS]",
  "CooldownSeconds": 120,
  "MinSizeCm": 1.0,
  "MaxSizeCm": 50.99,
  "Language": "en",
  "RandomCommand": "css_cicina",
  "RealCommand": "css_realcicina"
}
```

- **CooldownSeconds** – time in seconds between uses.
- **MinSizeCm / MaxSizeCm** – measurement range.
- **Language** – `en` or `sk`.
- **RandomCommand / RealCommand** – change the command names.

---

## 🎨 Colors in translations

You can use color tags in `lang/en.json` or `lang/sk.json`:

Example:
```
"{default}{0} has a {lightred}{1}{default} cm penis!"
```
The `{color}` tags will be replaced by `ChatColors` codes automatically.

---

## 📩 Contact
- **Discord:** `tichotm`

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

#### 📜 ABOUT THE PLUGIN

This is a **fun Counter-Strike 2 plugin** that adds two commands for measuring a player’s “penis” size, with results announced in the chat.  
The idea was inspired by the Slovak streamer [2SekundovyMato](https://www.youtube.com/@2SekundovyMato).

The plugin is written in **C#** for **CounterStrikeSharp** and uses a clean, optimized structure with shared cooldown logic and optional `partial` class support for splitting code into multiple files.

---

### 🔹 Commands

1. **`css_cicina`** – *Random size*
   - Generates a **random penis size** between `1.00 cm` and `50.99 cm`.
   - Has a **cooldown of 120 seconds** per player.
   - Shows the result to **all players in chat**.

2. **`css_realcicina`** – *Name-based size*
   - Generates a **consistent size** based on the player's name (`GetHashCode()`).
   - Always gives the **same result for the same name** (per session).
   - Also has a **120-second cooldown** per player.
   - Shows the result to **all players in chat** as the “real” size.

---

### 🛠 Code Features
- **Shared cooldown system** – one method handles cooldown checks for all commands.
- **Random instance reused** – avoids unnecessary object creation.
- **Partial class support** – allows splitting commands, utilities, and config into separate files for easier maintenance.
- **Easy to customize** – change cooldown time, size range, or formatting in one place.

---

## 📩 Contact
If you are interested in this plugin or need custom features, contact me via:

- **Discord:** `tichotm`

---

## 🛠 Installation Steps

**Requirements**
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

**Installation**
1. Download the plugin files.
2. Extract the ZIP.
3. Inside the extracted folder, open `Gameserver`
4. Copy all files into your server directory: `/game/csgo/addons/counterstrikesharp/plugins`

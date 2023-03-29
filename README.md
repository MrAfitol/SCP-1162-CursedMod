# SCP-1162
[![GitHub release](https://flat.badgen.net/github/release/MrAfitol/SCP-1162-CursedMod)](https://github.com/MrAfitol/SCP-1162-CursedMod/releases/)
![GitHub downloads](https://flat.badgen.net/github/assets-dl/MrAfitol/SCP-1162-CursedMod)


A plugin that adds SCP-1162
## How download ?
   - *1. Find the SCP SL server config folder*
   
   *("C:\Users\\(user name)\AppData\Roaming\SCP Secret Laboratory\" for windows, "/home/(user name)/.config/SCP Secret Laboratory/" for linux)*
  
   - *2. Find the "PluginAPI" folder there, it contains the "plugins" folder.*
  
   - *3. Select the folder where CursedMod is downloaded (global or (server port)), and go to the path CursedMod\Plugins, and move the plugin to this folder*
## Config
```yml
# What message will be displayed when using SCP-1162? ({dropitem} - Thrown or dropped item. {giveitem} - Changed item.)
item_drop_message: <b>You dropped a <color=green>{dropitem}</color> through <color=yellow>SCP-1162</color>, and received a <color=red>{giveitem}</color></b>
# From what distance can SCP-1162 be used?
s_c_p1162_distance: 2
# Will the hands be cut off if the item is not in the hands?
cutting_hands: true
# What is the chance that the hands will be cut off if the item is not in the hands
chance_cutting: 35
# If this item is enabled, the hands will not be cut off only when the player threw item
only_throw: false
# List of items that may drop from SCP-1162
dropping_items:
- SCP500
- KeycardContainmentEngineer
- GunCOM15
- GrenadeFlash
- SCP207
- Adrenaline
- GunCOM18
- Medkit
- KeycardGuard
- Ammo9x19
- KeycardZoneManager
- KeycardResearchCoordinator
- KeycardGuard
- Ammo762x39
- Ammo556x45
- GrenadeFlash
- KeycardScientist
- KeycardJanitor
- Coin
- Flashlight
```
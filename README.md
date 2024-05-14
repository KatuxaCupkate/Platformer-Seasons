# Platformer Seasons
Hi! I'm Kate and this is my first project named "Seasons". <br> <br>
This project originally started as an educational one, where I discover base of programming and game development with Unity and free asstes, but it grew into a mini-game. It is planned to release this project on web platforms, including for the purpose of practicing release procedures.

## Description
### This is a simple 2D platformer consisting of 3 levels:

* [Summer Level](#Summer-Level)
* [Autumn Level](#Autumn-Level)
* [Winter Level](#Winter-Level)

#### Each level is equipped with classic platformer traps:
* Pendulums
* Spikes
* Saws
* Maces
### Used assets
#### Main asset packages:

1. [Bayat Games](https://assetstore.unity.com/packages/2d/environments/free-platform-game-assets-85838).
2. [Kenney Game Assets](https://kenney.itch.io/kenney-game-assets).

Some assets were modified or recolored using Adobe Illustrator.

#### Sound assets:

* [whatsoundsnice](https://assetstore.unity.com/publishers/67969);
* [Casual Game BGM #5](https://assetstore.unity.com/packages/audio/music/casual-game-bgm-5-135943);
* [Casual Game Sounds](https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116);

### Controls:

* Movement - WASD
* Jump - SPACE
* Shoot snowballs - "F"

### NPC Interaction:
* Give key to NPC - "C"
* Next dialogue line - "E"
* Switch to the next level - "K"

### Design patterns used:

* ObjectPool;
* Singleton;
* Observer pattern;

# Short levels description

## Summer Level

To proceed to the next level, you need to find the key and [give it to the NPC](#NPC-Interaction).
Collecting coins is optional.
When moving to the next level, the number of collected coins is saved.

## Autumn Level

To progress to the next level, you will need 70 coins and a key.
Coins are required to activate the lift from the NPC to the finish line.

## Winter Level
(Under Development)<br>
To complete the level, you need to defeat enemies. For this, you will need 100 coins to purchase snowballs from the NPC. 
Destroying maces is achieved by [shooting snowballs](#Controls):
- 3 hits for small mace;
- 5 hits for large mace;<br><br>

After that, part of the traps disappears. <br>
You will also need a key. <br> <br>






# PlayerParticles

Si hablas otro idioma por favor visita [README_es.md](https://github.com/itsFrankV22/PlayerParticle-Plugin-/blob/main/README_es.md)

**Current Version:** 1.1.2
**Author:** FrankV22YT  

## Description

**PlayerParticles** is a plugin for Terraria servers that uses **TShock** to generate visual particles via projectiles. These particles can appear when a player joins the server, dies, or performs other configurable actions.

This plugin is under continuous development and will receive updates to add new features and improve functionality.

## Features

- Particle generation when a player **joins** or **dies**.
- Fully customizable settings through a JSON file.
- Compatible with **TShock** and designed to enhance the visual experience on servers.
- Easy configuration reload with the `/reload` command.
- Lightweight and efficient for custom servers.

## Installation

1. Download the plugin file `PlayerParticles.dll` and place it in the `ServerPlugins` folder of your TShock installation.
2. Start the server to automatically generate the configuration file.
3. Edit the configuration file `PlayerParticles.json` located in the `tshock/` folder to customize effects.
4. Reload the plugin using `/reload` to apply the changes.

## Configuration

The configuration file includes the following options:

- **EnableJoinParticles:** `true` or `false` - Enables or disables particles when joining.
- **EnableDeathParticles:** `true` or `false` - Enables or disables particles when dying.
- **JoinParticleIds:** A list of projectile IDs to be used when joining.
- **DeathParticleIds:** A list of projectile IDs to be used when dying.

### Configuration Example

- Find projectile IDs on this [WikiProjectileIDs](https://terraria.fandom.com/wiki/Projectile_IDs).
- Find Items IDs on this [WikiItemsIDs](https://terraria.fandom.com/wiki/Item_IDs)

*Info:
> 1 and 2: Projectle id

> 3: Item id


```json
{
  "Version": "1.1.2",
  "EnableJoinParticles": true,
  "JoinParticleIds": [
    1,
    2
  ],
  "EnableDeathParticles": true,
  "DeathParticleIds": [
    1,
    2
  ],
  "EnableDamageParticles": true,
  "DamageParticleIds": [
    1,
    2
  ],
  "ItemParticleMap": {
    "3": [
      1,
      2
    ],
    "3": [
      1,
      2
    ]
  }
}

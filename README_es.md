# PlayerParticles

If you speak another language please visit [README_en.md](https://github.com/itsFrankV22/PlayerParticle-Plugin-/blob/main/README.md)

**Versión Actual:** 1.1.5
**Autor:** FrankV22YT  

## Descripción

**PlayerParticles** es un plugin para servidores de Terraria que utiliza **TShock** para generar partículas visuales mediante proyectiles. Estas partículas pueden aparecer cuando un jugador se une al servidor, muere, o realiza otras acciones configurables. 

Este plugin está en constante desarrollo y seguirá recibiendo actualizaciones para añadir nuevas funciones y mejorar su funcionamiento.

## Características

- Generación de partículas al **unirse** o **morir** un jugador.
- Configuración completamente personalizable mediante un archivo JSON.
- Compatible con **TShock** y diseñado para mejorar la experiencia visual en servidores.
- Fácil recarga de configuración con el comando `/reload`.
- Ligero y eficiente para servidores personalizados.

## Instalación

1. Descarga el archivo del plugin `PlayerParticles.dll` y colócalo en la carpeta `ServerPlugins` de tu instalación de TShock.
2. Inicia el servidor para generar automáticamente el archivo de configuración.
3. Edita el archivo de configuración `PlayerParticles.json` ubicado en la carpeta `tshock/` para personalizar los efectos.
4. Recarga el plugin con `/reload` para aplicar los cambios.
- Debes tener `"SuppressPermissionFailureNotices": true` en `config.json`

### Ejemplos de configuracion

- Busca id de projectiles en esta [WikiProjectileIDs](https://terraria.fandom.com/wiki/Projectile_IDs).
- Busca id de items en esta [WikiItemsIDs](https://terraria.fandom.com/wiki/Item_IDs)

*Info:
> 1 y 2: Projectle id

> 3: Item id

> 60: Tiempo en Milisegundos
- Si pones mas de lo que la particula admite esta no lo soportara y se eliminara con su propio maximo de tiempo, el resto que pongas si admitira tiempo ecepto que suceda lo antes dicho


```json
{
  "Version": "1.1.4",
  "EnableJoinParticles": true,
  "JoinParticleTimeTicks": 60,
  "JoinParticleIds": [
    1,
    2
  ],
  "EnableDeathParticles": true,
  "DeathParticleTimeTicks": 60,
  "DeathParticleIds": [
    1,
    2
  ],
  "EnableDamageParticles": true,
  "DamageParticleTimeTicks": 60,
  "DamageParticleIds": [
    1,
    2
  ],
  "EnableHealingParticles": true,
  "HealingParticleTimeTicks": 60,
  "HealingParticleIds": [
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
  },
  "ItemParticleTimeTicks": 60
}

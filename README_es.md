# PlayerParticles

If you speak another language please visit [README_en.md]()

**Versión Actual:** 1.0.0  
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

## Configuración

El archivo de configuración incluye las siguientes opciones:

- **EnableJoinParticles:** `true` o `false` - Activa o desactiva partículas al unirse.
- **EnableDeathParticles:** `true` o `false` - Activa o desactiva partículas al morir.
- **JoinParticleIds:** Lista de IDs de proyectiles que se usarán al unirse.
- **DeathParticleIds:** Lista de IDs de proyectiles que se usarán al morir.

### Ejemplo de Configuración 1 y 2 serian id de projectiles osea particulas
- Encuentra los id en esta [Wiki](https://terraria.fandom.com/wiki/Projectile_IDs)

```json
{
  "EnableDeathParticles": true,
  "DeathParticleIds": [
    1,
    2
  ],
  "EnableJoinParticles": true,
  "JoinParticleIds": [
    1,
    2
  ]
}

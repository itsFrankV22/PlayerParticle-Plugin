using Newtonsoft.Json;
using System;
using System.IO;
using TerrariaApi.Server;
using TShockAPI;

namespace PlayerParticles
{
    public class Config
    {
        // Esta propiedad almacenará la versión del plugin
        public string Version { get; set; }

        public bool EnableJoinParticles { get; set; } = true;
        public int[] JoinParticleIds { get; set; } = { 1, 2 }; // IDs de proyectiles para unirse

        public bool EnableDeathParticles { get; set; } = true;
        public int[] DeathParticleIds { get; set; } = { 1, 2 }; // IDs de proyectiles para morir

        private static readonly string ConfigPath = Path.Combine("tshock", "PlayerParticles.json");

        public static Config Instance { get; private set; }

        public static void Load()
        {
            if (File.Exists(ConfigPath))
            {
                try
                {
                    string configContent = File.ReadAllText(ConfigPath);
                    var existingConfig = JsonConvert.DeserializeObject<Config>(configContent);

                    // Compara la versión del archivo con la versión actual del plugin
                    if (existingConfig?.Version != PlayerParticles.Instance.Version.ToString())
                    {
                        // Si la versión no coincide, borrar el archivo y generar una nueva configuración por defecto
                        File.Delete(ConfigPath);
                        Instance = new Config { Version = PlayerParticles.Instance.Version.ToString() };
                        Save();
                        TShock.Log.ConsoleInfo("La configuración estaba desactualizada, se ha generado una nueva configuración.");
                    }
                    else
                    {
                        // Si las versiones coinciden, carga la configuración existente
                        Instance = existingConfig;
                    }
                }
                catch (Exception)
                {
                    // Si hay un error al leer el archivo, crear una nueva configuración
                    Instance = new Config { Version = PlayerParticles.Instance.Version.ToString() };
                    Save();
                }
            }
            else
            {
                // Si no existe el archivo de configuración, crear uno nuevo con la versión actual
                Instance = new Config { Version = PlayerParticles.Instance.Version.ToString() };
                Save();
            }
        }

        public static void Save()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(Instance, Formatting.Indented));
        }
    }
}

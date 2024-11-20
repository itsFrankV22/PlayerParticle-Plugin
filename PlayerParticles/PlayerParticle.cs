using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using System;

namespace PlayerParticles
{
    [ApiVersion(2, 1)]
    public class PlayerParticles : TerrariaPlugin
    {
        public override string Author => "FrankV22YT";
        public override string Description => "Plugin para generar partículas usando proyectiles.";
        public override string Name => "PlayerParticles";
        public override Version Version => new Version(1, 0, 0); // Versión actual del plugin

        public static PlayerParticles Instance { get; private set; }

        private bool[] wasDead;

        public PlayerParticles(Main game) : base(game)
        {
            wasDead = new bool[Main.maxPlayers];
            Instance = this;
        }

        public override void Initialize()
        {
            Config.Load(); // Cargar la configuración
            ServerApi.Hooks.NetGreetPlayer.Register(this, OnPlayerJoin);
            ServerApi.Hooks.GameUpdate.Register(this, OnGameUpdate);
            Commands.ChatCommands.Add(new Command("playerparticles.reload", ReloadConfig, "reload"));
        }

        private void OnPlayerJoin(GreetPlayerEventArgs args)
        {
            var player = TShock.Players[args.Who];
            player.SendInfoMessage($"[ + ][ PlayerParticles ] v{Version} by {Author}.");

            if (Config.Instance.EnableJoinParticles)
            {
                TriggerJoinParticles(player);
            }
        }

        private void OnGameUpdate(EventArgs args)
        {
            for (int i = 0; i < Main.maxPlayers; i++)
            {
                var tPlayer = Main.player[i];
                if (tPlayer.active && tPlayer.dead && !wasDead[i]) // El jugador acaba de morir
                {
                    wasDead[i] = true;
                    TriggerDeathParticles(TShock.Players[i]);
                }
                else if (!tPlayer.dead)
                {
                    wasDead[i] = false;
                }
            }
        }

        private void TriggerJoinParticles(TSPlayer tPlayer)
        {
            foreach (var projId in Config.Instance.JoinParticleIds)
            {
                int projIndex = Projectile.NewProjectile(
                    null,
                    tPlayer.TPlayer.Center, // Generar en el centro del jugador
                    new Microsoft.Xna.Framework.Vector2(0, 0),
                    projId,
                    0,
                    0
                );
                if (projIndex >= 0) // Verificar que el proyectil fue creado exitosamente
                {
                    Main.projectile[projIndex].timeLeft = 350; // Destruir el proyectil después de 2 segundos (120 ticks)
                }
            }
        }

        private void TriggerDeathParticles(TSPlayer tPlayer)
        {
            if (!Config.Instance.EnableDeathParticles) return;

            foreach (var projId in Config.Instance.DeathParticleIds)
            {
                int projIndex = Projectile.NewProjectile(
                    null,
                    tPlayer.TPlayer.Center, // Generar en el centro del jugador
                    new Microsoft.Xna.Framework.Vector2(0, 0),
                    projId,
                    0,
                    0
                );
                if (projIndex >= 0) // Verificar que el proyectil fue creado exitosamente
                {
                    Main.projectile[projIndex].timeLeft = 120; // Destruir el proyectil después de 2 segundos (120 ticks)
                }
            }
        }

        private void ReloadConfig(CommandArgs args)
        {
            try
            {
                Config.Load();
                args.Player.SendSuccessMessage("Configuración de PlayerParticles recargando.");
                TShock.Log.ConsoleInfo("- Configuración de PlayerParticles recargada correctamente.");
            }
            catch (Exception ex)
            {
                args.Player.SendErrorMessage("Error al recargar la configuración de PlayerParticles.");
                TShock.Log.ConsoleError($"Error al recargar la configuración: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.NetGreetPlayer.Deregister(this, OnPlayerJoin);
                ServerApi.Hooks.GameUpdate.Deregister(this, OnGameUpdate);
            }
            base.Dispose(disposing);
        }
    }
}

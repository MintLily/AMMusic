using MelonLoader;
using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using System.Diagnostics;
using ActionMenuApi.Pedals;
using ActionMenuApi;
using ActionMenuApi.Api;

namespace AMMusic
{
    public static class BuildInfo
    {
        public const string Name = "AMMusic";
        public const string Author = "Lily";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = "https://github.com/MintLily/AMMusic";
        public const string Description = "Adds music controls to your ActionMenu.";
    }

    public class Main : MelonMod
    {
        internal PedalSubMenu subMenu;
        private readonly string[] AmApiOutdatedVersions = { "0.1.0", "0.1.2", "0.2.0", "0.2.1", "0.2.2", "0.2.3" };
        public static bool isDebug;

        public override void OnApplicationStart()
        {
            if (MelonDebug.IsEnabled() || Environment.CommandLine.Contains("--ammusic.debug")) {
                isDebug = true;
                MelonLogger.Msg(ConsoleColor.Green, "Debug mode is active");
            }

            MelonLogger.Msg("Initializing . . .");
            MelonCoroutines.Start(Resources.ResourceManager.LoadResources()); // AssetBundle Loading

            if (MelonHandler.Mods.Any(m => m.Info.Name.Equals("ActionMenuApi"))) {
                if (MelonHandler.Mods.Single(m => m.Info.Name.Equals("ActionMenuApi")).Info.Version.Equals(AmApiOutdatedVersions)) {
                    MelonLogger.Warning("ActionMenuApi Outdated. older versions are not supported, please update the other mod.");
                } else BuildActionMenu(); // Build ActionMenu Buttons
            }
        }

        void BuildActionMenu()
        {
            string e = string.Empty;
            subMenu = VRCActionMenuPage.AddSubMenu(ActionMenuPage.Options, "Music Contol", () =>
            {
                CustomSubMenu.AddButton(e, () => Music.NextTrack(), Resources.ResourceManager.Next);
                CustomSubMenu.AddButton(e, () => Music.PlayPause(), Resources.ResourceManager.Play);
                CustomSubMenu.AddButton(e, () => Music.PrevTrack(), Resources.ResourceManager.Back);
                CustomSubMenu.AddButton(e, () => Music.VolumeUp(), Resources.ResourceManager.VolUp);
                CustomSubMenu.AddButton(e, () => Music.VolumeDown(), Resources.ResourceManager.VolDown);
                CustomSubMenu.AddButton(e, () => Music.VolumeMute(), Resources.ResourceManager.VolMute);
            }, Resources.ResourceManager.Menu);
            if (Main.isDebug) MelonLogger.Msg(ConsoleColor.Green, "Finihsed creating ActionMenu Buttons");
        }
    }
}
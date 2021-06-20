using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using MelonLoader;
using System.Collections;
using System.IO;
using System.Reflection;

namespace AMMusic.Resources
{
    class ResourceManager
    {
        static AssetBundle Bundle;
        public static Texture2D Menu, Play, Next, Back, VolUp, VolDown, VolMute;

        static Texture2D LoadTexture(string Texture)
        {
            Texture2D Texture2 = Bundle.LoadAsset_Internal(Texture, Il2CppType.Of<Texture2D>()).Cast<Texture2D>();
            Texture2.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            Texture2.hideFlags = HideFlags.HideAndDontSave;
            return Texture2;
        }

        public static IEnumerator LoadResources()
        {
            // Came from UIExpansionKit (https://github.com/knah/VRCMods/blob/master/UIExpansionKit)
            MelonLogger.Msg("Loading AssetBundle...");
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AMMusic.Resources.ammusic.lily")) {
                using (var memoryStream = new MemoryStream((int)stream.Length)) {
                    stream.CopyTo(memoryStream);
                    Bundle = AssetBundle.LoadFromMemory_Internal(memoryStream.ToArray(), 0);
                    try { Menu = LoadTexture("Menu.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: Menu"); }
                    try { Play = LoadTexture("Play.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: Play"); }
                    try { Next = LoadTexture("Foward.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: Foward"); }
                    try { Back = LoadTexture("Back.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: Back"); }
                    try { VolUp = LoadTexture("VolUp.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: VolUp"); }
                    try { VolDown = LoadTexture("VolDown.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: VolDown"); }
                    try { VolMute = LoadTexture("VolMute.png"); } catch { MelonLogger.Error("Failed to load image from asset bundle: VolMute"); }
                    // - End -
                }
            }

            if (Main.isDebug) MelonLogger.Msg(ConsoleColor.Green, "Finihsed with Asset Bundle Resource Managment");
            yield break;
        }
    }
}

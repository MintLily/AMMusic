using System;
using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(AMMusic.BuildInfo.Name)]
[assembly: AssemblyDescription(AMMusic.BuildInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AMMusic.BuildInfo.Company)]
[assembly: AssemblyProduct(AMMusic.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + AMMusic.BuildInfo.Author)]
[assembly: AssemblyTrademark(AMMusic.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(AMMusic.BuildInfo.Version)]
[assembly: AssemblyFileVersion(AMMusic.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(AMMusic.Main),
    AMMusic.BuildInfo.Name,
    AMMusic.BuildInfo.Version,
    AMMusic.BuildInfo.Author,
    AMMusic.BuildInfo.DownloadLink)]
[assembly: MelonColor(ConsoleColor.Yellow)]

//[assembly: MelonOptionalDependencies("", "", "", "")]
// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("VRChat", "VRChat")]
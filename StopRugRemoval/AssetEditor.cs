﻿using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;

namespace StopRugRemoval;

/// <summary>
/// Handles editing assets.
/// </summary>
internal static class AssetEditor
{
#pragma warning disable SA1310 // Field names should not contain underscore. Reviewed.
    private static readonly string SALOON_EVENTS = PathUtilities.NormalizeAssetName("Data/Events/Saloon");
    private static readonly string BET_ICONS = PathUtilities.NormalizeAssetName("Mods/atravita_StopRugRemoval_BetIcons");
#pragma warning restore SA1310 // Field names should not contain underscore

    private static Lazy<Texture2D> betIconLazy = new(() => Game1.content.Load<Texture2D>(BET_ICONS));

    /// <summary>
    /// Gets the bet button textures.
    /// </summary>
    internal static Texture2D BetIcon => betIconLazy.Value;

#pragma warning disable SA1201 // Elements should appear in the correct order. Keeping field near property.
    private static IAssetName? betIconsAsset;

    private static IAssetName BET_ICONS_ASSET => betIconsAsset ??= ModEntry.GameContentHelper.ParseAssetName(BET_ICONS);
#pragma warning restore SA1201 // Elements should appear in the correct order

    /// <summary>
    /// Refreshes lazies.
    /// </summary>
    /// <param name="assets">IReadOnlySet of assets to refresh.</param>
    internal static void Refresh(IReadOnlySet<IAssetName>? assets = null)
    {
        if (betIconLazy.IsValueCreated && (assets is null || assets.Contains(BET_ICONS_ASSET)))
        {
            betIconLazy = new(() => Game1.content.Load<Texture2D>(BET_ICONS));
        }
    }

    /// <summary>
    /// Applies edits.
    /// </summary>
    /// <param name="e">Event args.</param>
    /// <param name="registry">The mod registry.</param>
    /// <param name="directoryPath">The absolute path to the mod.</param>
    internal static void Edit(AssetRequestedEventArgs e, IModRegistry registry, string directoryPath)
    {
        if (e.NameWithoutLocale.IsEquivalentTo(BET_ICONS))
        { // The BET1k/10k icons have to be localized, so they're in the i18n folder.
            string filename = "BetIcons.png";

            if (Game1.content.GetCurrentLanguage() is not LocalizedContentManager.LanguageCode.en)
            {
                LocalizedContentManager.LanguageCode locale = Game1.content.GetCurrentLanguage();
                string localeFilename = $"BetIcons.{Game1.content.LanguageCodeString(locale)}.png";
                if (File.Exists(Path.Combine(directoryPath, "i18n", localeFilename)))
                {
                    filename = localeFilename;
                }
            }
            e.LoadFromModFile<Texture2D>(Path.Combine("i18n", filename), AssetLoadPriority.Low);
        }
        else if (e.NameWithoutLocale.IsEquivalentTo(SALOON_EVENTS) && !registry.IsLoaded("violetlizabet.CP.NoAlcohol") && ModEntry.Config.Enabled)
        {
            e.Edit(EditSaloon, AssetEditPriority.Late);
        }
    }

    private static void EditSaloon(IAssetData asset)
    {
        IAssetDataForDictionary<string, string>? editor = asset.AsDictionary<string, string>();

        if (editor.Data.ContainsKey("atravita_elliott_nodrink"))
        {// event has been edited already?
            return;
        }
        foreach ((string key, string value) in editor.Data)
        {
            if (key.StartsWith("40", StringComparison.OrdinalIgnoreCase))
            {
                int index = value.IndexOf("speak Elliott");
                int second = value.IndexOf("speak Elliott", index + 1);
                int nextslash = value.IndexOf('/', second);
                if (nextslash > -1)
                {
                    string initial = value[..nextslash] + $"/question fork1 \"#{I18n.Drink()}#{I18n.Nondrink()}/fork atravita_elliott_nodrink/";
                    string remainder = value[(nextslash + 1)..];

                    editor.Data["atravita_elliott_nodrink"] = remainder.Replace("346", "350");
                    editor.Data[key] = initial + remainder;
                }
                return;
            }
        }
    }
}
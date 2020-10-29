using UnityEngine;
using Verse;

namespace GunNutChapterOne
{
	internal class GNC1Mod : Mod
	{
		/// <summary>
		/// A reference to our settings.
		/// </summary>
		public static GNC1Settings settings;

		/// <summary>
		/// A mandatory constructor which resolves the reference to our settings.
		/// </summary>
		/// /// <param name="content"></param>
		public GNC1Mod(ModContentPack content) : base(content)
		{
			GNC1Mod.settings = base.GetSettings<GNC1Settings>();
		}

		/// <summary>
		/// The (optional) GUI part to set your settings.
		/// </summary>
		/// <param name="settingsCanvas">A Unity Rect with the size of the settings window.</param>
		public override void DoSettingsWindowContents(Rect settingsCanvas)
		{
			base.DoSettingsWindowContents(settingsCanvas);
			GNC1Mod.settings.DoSettingsWindowContents(settingsCanvas);
		}

		/// <summary>
		/// Override SettingsCategory to show up in the list of settings.
		/// Using .Translate() is optional, but does allow for localisation.
		/// </summary>
		/// <returns>The (translated) mod name.</returns>
		public override string SettingsCategory()
		{
			return "GUN NUT-Chapter #1";
		}

		public override void WriteSettings()
		{
			base.WriteSettings();
			GNC1DefDisabler.DefDisablerList();
			GNC1NickNames.EnableNickNames();
		}
	}
}
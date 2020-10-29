using UnityEngine;
using Verse;

namespace GunNutChapterOne
{
	internal class GNC1Settings : ModSettings
	{
		/// <summary>
		/// The settings our mod has.
		/// </summary>
		public bool enable_GN_AK103 = true;
		public bool enable_GN_AK105 = true;
		public bool enable_GN_SA58 = true;
		public bool enable_GN_BullpupPKP = true;
		public bool enable_GN_Glock17 = true;
		public bool enable_GN_M4A1 = true;
		public bool enable_GN_M1A = true;
		public bool enable_GN_MP7A1 = true;
		public bool enable_GN_R700 = true;
		public bool enable_GN_Saiga12K = true;
		public bool enable_GN_RedRebel = true;

		public bool enable_GN_nicknames = true;

		public void ResetSavedDefs()
		{
			this.enable_GN_AK103 = true;
			this.enable_GN_AK105 = true;
			this.enable_GN_BullpupPKP = true;
			this.enable_GN_Glock17 = true;
			this.enable_GN_M1A = true;
			this.enable_GN_M4A1 = true;
			this.enable_GN_MP7A1 = true;
			this.enable_GN_R700 = true;
			this.enable_GN_RedRebel = true;
			this.enable_GN_SA58 = true;
			this.enable_GN_Saiga12K = true;

			this.enable_GN_nicknames = true;
		}

		/// <summary>
		/// The part that writes our settings to file. Note that saving is by ref.
		/// </summary>
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<bool>(ref this.enable_GN_AK103, "enable_GN_AK103", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_AK105, "enable_GN_AK105", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_BullpupPKP, "enable_GN_BullpupPKP", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_Glock17, "enable_GN_Glock17", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_M1A, "enable_GN_M1A", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_M4A1, "enable_GN_M4A1", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_MP7A1, "enable_GN_MP7A1", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_R700, "enable_GN_R700", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_RedRebel, "enable_GN_RedRebel", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_SA58, "enable_GN_SA58", true, false);
			Scribe_Values.Look<bool>(ref this.enable_GN_Saiga12K, "enable_GN_Saiga12K", true, false);

			Scribe_Values.Look<bool>(ref this.enable_GN_nicknames, "enable_GN_nicknames", true, false);
		}

		public void DoSettingsWindowContents(Rect settingsCanvas)
		{
			Listing_Standard list = new Listing_Standard
			{
				ColumnWidth = (settingsCanvas.width - 17) / 2
			};

			list.Begin(settingsCanvas);

			Text.Font = GameFont.Medium;
			list.Label("settings_GN_EnableHeader".Translate());
			list.GapLine();

			Text.Font = GameFont.Small;
			list.Label("settings_GN_EnableDescription".Translate());
			list.Gap();

			list.CheckboxLabeled("enable_GN_AK103".Translate(), ref this.enable_GN_AK103, null);
			list.CheckboxLabeled("enable_GN_AK105".Translate(), ref this.enable_GN_AK105, null);
			list.CheckboxLabeled("enable_GN_BullpupPKP".Translate(), ref this.enable_GN_BullpupPKP, null);
			list.CheckboxLabeled("enable_GN_Glock17".Translate(), ref this.enable_GN_Glock17, null);
			list.CheckboxLabeled("enable_GN_M1A".Translate(), ref this.enable_GN_M1A, null);
			list.CheckboxLabeled("enable_GN_M4A1".Translate(), ref this.enable_GN_M4A1, null);
			list.CheckboxLabeled("enable_GN_MP7A1".Translate(), ref this.enable_GN_MP7A1, null);
			list.CheckboxLabeled("enable_GN_R700".Translate(), ref this.enable_GN_R700, null);
			list.CheckboxLabeled("enable_GN_SA58".Translate(), ref this.enable_GN_SA58, null);
			list.CheckboxLabeled("enable_GN_Saiga12K".Translate(), ref this.enable_GN_Saiga12K, null);
			list.Gap();
			list.CheckboxLabeled("enable_GN_RedRebel".Translate(), ref this.enable_GN_RedRebel, null);
			list.Gap();
			list.Gap();
			list.Gap();
			list.Gap();
			list.Gap();

			list.Label("settings_GN_EndDescription".Translate());

			list.NewColumn();

			Text.Font = GameFont.Medium;
			list.Label("settings_GN_EnableNickNameHeader".Translate());
			list.GapLine();

			Text.Font = GameFont.Small;
			list.Label("settings_GN_EnableNickNameDescription".Translate());
			list.Gap();

			list.CheckboxLabeled("enable_GN_nicknames".Translate(), ref this.enable_GN_nicknames, null);

			list.End();
		}
	}
}
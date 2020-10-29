using Verse;

namespace GunNutChapterOne
{
	[StaticConstructorOnStartup]
	public static class GNC1NickNames
	{
		static GNC1NickNames() => GNC1NickNames.EnableNickNames();

		public static void ChangeLabel(ThingDef def, string newLabel) => def.label = newLabel.Translate();

		public static void EnableNickNames()
		{
			bool value1 = GNC1Mod.settings.enable_GN_nicknames;
			if (value1)
			{
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_AKOneOFive"), "Label_GN_AKOneOFive_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_AKOneOThree"), "Label_GN_AKOneOThree_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_BullpupPKP"), "Label_GN_BullpupPKP_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_GlockSeventeen"), "Label_GN_GlockSeventeen_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_MFourAOne"), "Label_GN_MFourAOne_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_MOneA"), "Label_GN_MOneA_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_MPSevenAOne"), "Label_GN_MPSevenAOne_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_RedRebel"), "Label_GN_RedRebel_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_RSevenHundred"), "Label_GN_RSevenHundred_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_SAFiftyEight"), "Label_GN_SAFiftyEight_NN");
				GNC1NickNames.ChangeLabel(ThingDef.Named("GN_SaigaTwelveK"), "Label_GN_SaigaTwelveK_NN");
			}
		}
	}
}
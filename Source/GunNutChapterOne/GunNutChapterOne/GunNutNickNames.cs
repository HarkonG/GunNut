using Verse;

namespace GunNutChapterOne
{
	[StaticConstructorOnStartup]
	public static class GunNutNickNames
	{
		static GunNutNickNames() => GunNutNickNames.EnableNickNames();

		public static void ChangeLabel(ThingDef def, string newLabel) => def.label = newLabel.Translate();

		public static void EnableNickNames()
		{
			bool value1 = GunNutChapterOneMod.settings.enable_GN_nicknames;
			if (value1)
			{
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_AKOneOFive"), "Label_GN_AKOneOFive_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_AKOneOThree"), "Label_GN_AKOneOThree_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_BullpupPKP"), "Label_GN_BullpupPKP_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_GlockSeventeen"), "Label_GN_GlockSeventeen_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_MFourAOne"), "Label_GN_MFourAOne_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_MOneA"), "Label_GN_MOneA_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_MPSevenAOne"), "Label_GN_MPSevenAOne_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_RedRebel"), "Label_GN_RedRebel_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_RSevenHundred"), "Label_GN_RSevenHundred_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_SAFiftyEight"), "Label_GN_SAFiftyEight_NN");
				GunNutNickNames.ChangeLabel(ThingDef.Named("GN_SaigaTwelveK"), "Label_GN_SaigaTwelveK_NN");
			}
		}
	}
}
using RimWorld;
using System.Collections.Generic;
using Verse;

namespace GunNutChapterOne
{
	[StaticConstructorOnStartup]
	public static class GNC1DefDisabler
	{
		static GNC1DefDisabler() => GNC1DefDisabler.DefDisablerList();

		public static void DefDisablerList()
		{
			bool value1 = !GNC1Mod.settings.enable_GN_AK103;
			if (value1)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_AKOneOThree"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_AKOneOThree"));
			}

			bool value2 = !GNC1Mod.settings.enable_GN_AK105;
			if (value2)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_AKOneOFive"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_AKOneOFive"));
			}

			bool value3 = !GNC1Mod.settings.enable_GN_BullpupPKP;
			if (value3)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_BullpupPKP"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_BullpupPKP"));
			}

			bool value4 = !GNC1Mod.settings.enable_GN_Glock17;
			if (value4)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_GlockSeventeen"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_GlockSeventeen"));
			}

			bool value5 = !GNC1Mod.settings.enable_GN_M1A;
			if (value5)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_MOneA"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_MOneA"));
			}

			bool value6 = !GNC1Mod.settings.enable_GN_M4A1;
			if (value6)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_MFourAOne"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_MFourAOne"));
			}

			bool value7 = !GNC1Mod.settings.enable_GN_MP7A1;
			if (value7)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_MPSevenAOne"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_MPSevenAOne"));
			}

			bool value8 = !GNC1Mod.settings.enable_GN_R700;
			if (value8)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_RSevenHundred"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_RSevenHundred"));
			}

			bool value9 = !GNC1Mod.settings.enable_GN_RedRebel;
			if (value9)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_RedRebel"));
			}

			bool value10 = !GNC1Mod.settings.enable_GN_SA58;
			if (value10)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_SAFiftyEight"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_SAFiftyEight"));
			}

			bool value11 = !GNC1Mod.settings.enable_GN_Saiga12K;
			if (value11)
			{
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_SaigaTwelveK"));
				GNC1DefDisabler.DisableDef(ThingDef.Named("GN_Bullet_SaigaTwelveK"));
			}
		}

		public static void DisableDef(ThingDef def)
		{
			List<ResearchProjectDef> researchPrerequisites = def.researchPrerequisites;

			if (researchPrerequisites != null)
			{
				researchPrerequisites.Clear();
			}

			List<string> weaponTags = def.weaponTags;

			if (weaponTags != null)
			{
				weaponTags.Clear();
			}

			def.deepCommonality = 0f;

			def.generateCommonality = 0f;

			def.tradeability = Tradeability.None;

			List<ThingCategoryDef> thingCategories = def.thingCategories;

			if (thingCategories != null)
			{
				thingCategories.Clear();
			}

			List<ThingCategoryDef> thingCategories2 = def.thingCategories;

			if (thingCategories2 != null)
			{
				thingCategories2.Add(ThingCategoryDefOf.Chunks);
			}

			foreach (RecipeDef recipeDef in DefDatabase<RecipeDef>.AllDefsListForReading)
			{
				bool value1 = recipeDef.ProducedThingDef == def;
				if (value1)
				{
					List<ThingDef> recipeUsers = recipeDef.recipeUsers;
					if (recipeUsers != null)
					{
						recipeUsers.Clear();
					}
					List<ResearchProjectDef> researchPrerequisites2 = recipeDef.researchPrerequisites;
					if (researchPrerequisites2 != null)
					{
						researchPrerequisites2.Clear();
					}
					recipeDef.researchPrerequisite = null;
				}
			}

			bool value2 = DefDatabase<ThingDef>.AllDefsListForReading.Contains(def);

			if (value2)
			{
				DefDatabase<ThingDef>.AllDefsListForReading.Remove(def);
			}
		}
	}
}
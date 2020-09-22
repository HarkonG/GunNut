using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace GunNutChapterOne
{
    internal class GunNutChapterOneMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        public static GunNutChapterOneSettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// /// <param name="content"></param>
        public GunNutChapterOneMod(ModContentPack content) : base(content)
        {
            GunNutChapterOneMod.settings = base.GetSettings<GunNutChapterOneSettings>();
        }

        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            GunNutChapterOneMod.settings.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "Gun Nut - Chapter #1";
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            DefsRemover.DoDefsRemoval();
        }
    }

    internal class GunNutChapterOneSettings : ModSettings
    {
        /// <summary>
        /// The settings our mod has.
        /// </summary>
        public bool enableGN_AK103 = true;
        public bool enableGN_AK105 = true;
        public bool enableGN_SA58 = true;
        public bool enableGN_BullpupPKP = true;
        public bool enableGN_Glock17 = true;
        public bool enableGN_M4A1 = true;
        public bool enableGN_M1A = true;
        public bool enableGN_MP7A1 = true;
        public bool enableGN_R700 = true;
        public bool enableGN_Saiga12K = true;
        public bool enableGN_RedRebel = true;

        public bool enableGN_nicknames = true;

        /*public void ResetSavedDefs()
        {
            this.enableGN_AK103 = true;
            this.enableGN_AK105 = true;
            this.enableGN_BullpupPKP = true;
            this.enableGN_Glock17 = true;
            this.enableGN_M1A = true;
            this.enableGN_M4A1 = true;
            this.enableGN_MP7A1 = true;
            this.enableGN_R700 = true;
            this.enableGN_RedRebel = true;
            this.enableGN_SA58 = true;
            this.enableGN_Saiga12K = true;
        }*/

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref this.enableGN_AK103, "enableGN_AK103", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_AK105, "enableGN_AK105", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_BullpupPKP, "enableGN_BullpupPKP", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_Glock17, "enableGN_Glock17", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_M1A, "enableGN_M1A", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_M4A1, "enableGN_M4A1", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_MP7A1, "enableGN_MP7A1", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_R700, "enableGN_R700", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_RedRebel, "enableGN_RedRebel", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_SA58, "enableGN_SA58", true, false);
            Scribe_Values.Look<bool>(ref this.enableGN_Saiga12K, "enableGN_Saiga12K", true, false);
        }

        public void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.CheckboxLabeled("enableGN_AK103".Translate(), ref this.enableGN_AK103, null);
            listing_Standard.CheckboxLabeled("enableGN_AK105".Translate(), ref this.enableGN_AK105, null);
            listing_Standard.CheckboxLabeled("enableGN_BullpupPKP".Translate(), ref this.enableGN_BullpupPKP, null);
            listing_Standard.CheckboxLabeled("enableGN_Glock17".Translate(), ref this.enableGN_Glock17, null);
            listing_Standard.CheckboxLabeled("enableGN_M1A".Translate(), ref this.enableGN_M1A, null);
            listing_Standard.CheckboxLabeled("enableGN_M4A1".Translate(), ref this.enableGN_M4A1, null);
            listing_Standard.CheckboxLabeled("enableGN_MP7A1".Translate(), ref this.enableGN_MP7A1, null);
            listing_Standard.CheckboxLabeled("enableGN_R700".Translate(), ref this.enableGN_R700, null);
            listing_Standard.CheckboxLabeled("enableGN_RedRebel".Translate(), ref this.enableGN_RedRebel, null);
            listing_Standard.CheckboxLabeled("enableGN_SA58".Translate(), ref this.enableGN_SA58, null);
            listing_Standard.CheckboxLabeled("enableGN_Saiga12K".Translate(), ref this.enableGN_Saiga12K, null);
            listing_Standard.End();

        }
    }

    [StaticConstructorOnStartup]
    public static class DefsRemover
    {
        static DefsRemover()
        {
            DefsRemover.DoDefsRemoval();
        }


        public static void RemoveDef(ThingDef def)
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

        public static void DoDefsRemoval()
        {
            bool value1 = !GunNutChapterOneMod.settings.enableGN_AK103;
            if (value1)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_AKOneOThree"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_AKOneOThree"));
            }

            bool value2 = !GunNutChapterOneMod.settings.enableGN_AK105;
            if (value2)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_AKOneOFive"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_AKOneOFive"));
            }

            bool value3 = !GunNutChapterOneMod.settings.enableGN_BullpupPKP;
            if (value3)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_BullpupPKP"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_BullpupPKP"));
            }

            bool value4 = !GunNutChapterOneMod.settings.enableGN_Glock17;
            if (value4)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_GlockSeventeen"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_GlockSeventeen"));
            }

            bool value5 = !GunNutChapterOneMod.settings.enableGN_M1A;
            if (value5)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_MOneA"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_MOneA"));
            }

            bool value6 = !GunNutChapterOneMod.settings.enableGN_M4A1;
            if (value6)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_MFourAOne"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_MFourAOne"));
            }

            bool value7 = !GunNutChapterOneMod.settings.enableGN_MP7A1;
            if (value7)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_MPSevenAOne"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_MPSevenAOne"));
            }

            bool value8 = !GunNutChapterOneMod.settings.enableGN_R700;
            if (value8)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_RSevenHundred"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_RSevenHundred"));
            }

            bool value9 = !GunNutChapterOneMod.settings.enableGN_RedRebel;
            if (value9)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_RedRebel"));
            }

            bool value10 = !GunNutChapterOneMod.settings.enableGN_SA58;
            if (value10)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_SAFiftyEight"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_SAFiftyEight"));
            }

            bool value11 = !GunNutChapterOneMod.settings.enableGN_Saiga12K;
            if (value11)
            {
                DefsRemover.RemoveDef(ThingDef.Named("GN_SaigaTwelveK"));
                DefsRemover.RemoveDef(ThingDef.Named("GN_Bullet_SaigaTwelveK"));
            }
        }
    }
}

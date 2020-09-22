using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="settingsCanvas">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect settingsCanvas)
        {
            base.DoSettingsWindowContents(settingsCanvas);
            GunNutChapterOneMod.settings.DoSettingsWindowContents(settingsCanvas);
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
            GunNutDefsRemover.DoDefsRemoval();
            GunNutLabelRename.DoLabelRename();
        }
    }
}

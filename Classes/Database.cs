using System.Collections.Generic;

namespace vrchat_launcher.Classes
{
    internal class Database
    {
        internal List<Profile> Profiles { get; set; } = new List<Profile>();
        internal List<Software> Softwares { get; set; } = new List<Software>();
        internal bool LastSelectedDesktopMode { get; set; } = false;
        internal string LastSelectedProfile { get; set; } = string.Empty;
    }
}

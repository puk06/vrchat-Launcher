using System.Collections.Generic;

namespace vrchat_launcher.Classes
{
    public class Database
    {
        public List<Profile> Profiles { get; set; } = new List<Profile>();
        public List<Software> Softwares { get; set; } = new List<Software>();
        public bool LastSelectedDesktopMode { get; set; } = false;
        public string LastSelectedProfile { get; set; } = string.Empty;
    }
}
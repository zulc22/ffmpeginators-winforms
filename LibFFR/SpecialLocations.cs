using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace LibFFR
{
    public static class SpecialLocations
    {
        public static string UserProfile() => System.Environment.GetEnvironmentVariable("USERPROFILE");
        public static string Roaming() => System.Environment.GetEnvironmentVariable("APPDATA");
        public static string ExeDir() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string SendTo() => Roaming() + @"\Microsoft\Windows\SendTo";
    }
}

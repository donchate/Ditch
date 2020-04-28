﻿
namespace Ditch.Hive.Helpers
{
    public static class VersionHelper
    {
        public static int ToInteger(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
                return -1;

            var mhr = version.Split('.');

            if (mhr.Length != 3 || !int.TryParse(mhr[0], out var major) || !int.TryParse(mhr[1], out var hardfork) || !int.TryParse(mhr[2], out var release))
                return -1;

            var ver = (0 | major) << 16;
            ver = (ver | hardfork) << 8;
            ver |= release;
            return ver;
        }

        public static int GetMajor(int version)
        {
            return (version >> 24) & 0x000000FF;
        }

        public static int GetHardfork(int version)
        {
            return (version >> 16) & 0x000000FF;
        }

        public static int GetRelease(int version)
        {
            return version & 0x0000FFFF;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using emulatorLauncher.Tools;

namespace emulatorLauncher
{
    class SystemDefaults
    {
        class YmlSystem : IYmlItem
        {
            public string system { get; set; }

            public string emulator { get; set; }
            public string core { get; set; }
        }

        public static string GetDefaultEmulator(string system)
        {
            EnsureCache();
            return _ymlSystemsCache.Where(i => i.system == system).Select(i => i.emulator).FirstOrDefault();
        }

        public static string GetDefaultCore(string system)
        {
            EnsureCache();
            return _ymlSystemsCache.Where(i => i.system == system).Select(i => i.core).FirstOrDefault();
        }

        private static void EnsureCache()
        {
            if (_ymlSystemsCache == null)
                if (Environment.Is64BitOperatingSystem) {
                    _ymlSystemsCache = new SimpleYml<YmlSystem>(Encoding.UTF8.GetString(Properties.Resources.configgen_defaults));
                } else
                {
                    _ymlSystemsCache = new SimpleYml<YmlSystem>(Encoding.UTF8.GetString(Properties.Resources.configgen_defaults_32));
                }
               
        }

        private static SimpleYml<YmlSystem> _ymlSystemsCache;
    }



}

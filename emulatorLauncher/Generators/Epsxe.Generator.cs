
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace emulatorLauncher
{
    class EpsxeGenerator : Generator
    {
        public override System.Diagnostics.ProcessStartInfo Generate(string system, string emulator, string core, string rom, string playersControllers, ScreenResolution resolution)
        {
            string path = AppConfig.GetFullPath("epsxe");

            string exe = Path.Combine(path, "epsxe.exe");
            if (!File.Exists(exe))
                return null;

            return new ProcessStartInfo()
            {
                FileName = exe,
                WorkingDirectory = path,
                Arguments = biosFile(core) + " -nogui -loadbin \"" + rom + "\"",
            };
        }

        private string biosFile(string core)
        {
            string biosPath = Path.Combine(Program.AppConfig.GetFullPath("home"), "bios");
            string bin = Path.Combine(biosPath, core + ".BIN");
            if (File.Exists(bin))
            {
                return "-bios " + bin;
            }
            return "";
        }
    }
}
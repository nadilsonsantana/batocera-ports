using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace emulatorLauncher
{
    class MednafenGenerator : Generator
    {
        public override System.Diagnostics.ProcessStartInfo Generate(string system, string emulator, string core, string rom, string playersControllers, ScreenResolution resolution)
        {
            string path = AppConfig.GetFullPath("mednafen");

            string exe = Path.Combine(path, "mednafen.exe");
            if (!File.Exists(exe))
                return null;

            List<string> commandArray = new List<string>();

            commandArray.Add("-fps.scale 0");
            commandArray.Add("-sound.volume 120");
            commandArray.Add("-video.deinterlacer bob");
            commandArray.Add("-video.fs 1");

            if (core == "megadrive" || core == "md")
            {
                commandArray.Add("-md.shader.goat.fprog 1");
                commandArray.Add("-md.special none");
                commandArray.Add("-md.stretch aspect_mult2");
                commandArray.Add("-md.videoip 1");
                commandArray.Add("-md.shader none");
                commandArray.Add("-md.shader.goat.slen 1");
                commandArray.Add("-md.shader.goat.tp 0.25");
                commandArray.Add("-md.shader.goat.hdiv 1");
                commandArray.Add("-md.shader.goat.vdiv 1");
                commandArray.Add("-md.scanlines 50");
                commandArray.Add("-md.xscale 4.000000");
                commandArray.Add("-md.yscale 4.000000");
                commandArray.Add("-md.xscalefs 4.000000");
                commandArray.Add("-md.yscalefs 4.000000");
            }
            else if (core == "nes")
            {
                commandArray.Add("-nes.shader.goat.fprog 1");
                commandArray.Add("-nes.special none");
                commandArray.Add("-nes.stretch aspect_mult2");
                commandArray.Add("-nes.videoip 1 -nes.shader none");
                commandArray.Add("-nes.shader.goat.slen 1");
                commandArray.Add("-nes.shader.goat.tp 0.25");
                commandArray.Add("-nes.shader.goat.hdiv 1");
                commandArray.Add("-nes.shader.goat.vdiv 1");
                commandArray.Add("-nes.scanlines 50");
                commandArray.Add("-nes.xscale 4.000000");
                commandArray.Add("-nes.yscale 4.000000");
                commandArray.Add("-nes.xscalefs 4.000000");
                commandArray.Add("-nes.yscalefs 4.000000");
            }
            else if (core == "snes")
            {
                commandArray.Add("-snes.shader.goat.fprog 1");
                commandArray.Add("-snes.special none");
                commandArray.Add("-snes.stretch aspect_mult2");
                commandArray.Add("-snes.videoip 1");
                commandArray.Add("-snes.shader none");
                commandArray.Add("-snes.shader.goat.slen 1");
                commandArray.Add("-snes.shader.goat.tp 0.25");
                commandArray.Add("-snes.shader.goat.hdiv 1");
                commandArray.Add("-snes.shader.goat.vdiv 1");
                commandArray.Add("-snes.scanlines 50");
                commandArray.Add("-snes.xscale 4.000000");
                commandArray.Add("-snes.yscale 4.000000");
                commandArray.Add("-snes.xscalefs 4.000000");
                commandArray.Add("-snes.yscalefs 4.000000");

            }
            else if (core == "pcengine" || core == "pcenginecd" || core == "supergrafx" || core == "pce")
            {
                if (AppConfig.isOptSet("bios"))
                    commandArray.Add("-pce.cdbios \"" + Path.Combine(AppConfig.GetFullPath("bios"), "syscard3.pce") + "\"");

                commandArray.Add("-pce.shader.goat.fprog 1");
                commandArray.Add("-pce.special none");
                commandArray.Add("-pce.stretch aspect_mult2");
                commandArray.Add("-pce.videoip 1");
                commandArray.Add("-pce.shader none");
                commandArray.Add("-pce.shader.goat.slen 1");
                commandArray.Add("-pce.shader.goat.tp 0.25");
                commandArray.Add("-pce.shader.goat.hdiv 1");
                commandArray.Add("-pce.shader.goat.vdiv 1");
                commandArray.Add("-pce.scanlines 50");
                commandArray.Add("-pce.xscale 4.000000");
                commandArray.Add("-pce.yscale 4.000000");
                commandArray.Add("-pce.xscalefs 4.000000");
                commandArray.Add("-pce.yscalefs 4.000000");
            }

            commandArray.Add("\"" + rom + "\"");

            string args = string.Join(" ", commandArray);
            return new ProcessStartInfo()
            {
                FileName = exe,
                WorkingDirectory = path,
                Arguments = args,
            };
        }
    }
}

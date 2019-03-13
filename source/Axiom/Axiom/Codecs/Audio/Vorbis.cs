﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2019 Matt McManis
http://github.com/MattMcManis/Axiom
http://axiomui.github.io
mattmcmanis@outlook.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see <http://www.gnu.org/licenses/>. 
---------------------------------------------------------------------- */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axiom
{
    public class Vorbis
    {
        // -------------------------
        // Codec
        // -------------------------
        public static string codec = "-c:a libvorbis";

        // -------------------------
        // Quality
        // -------------------------
        public static List<ViewModel.AudioQuality> quality = new List<ViewModel.AudioQuality>()
        {
             new ViewModel.AudioQuality() { Name = "Auto",   CBR_BitMode = "-b:a", CBR = "",    VBR_BitMode = "-q:a", VBR = "",     NA = "192" },
             new ViewModel.AudioQuality() { Name = "500",    CBR_BitMode = "-b:a", CBR = "500", VBR_BitMode = "-q:a", VBR = "10" },
             new ViewModel.AudioQuality() { Name = "320",    CBR_BitMode = "-b:a", CBR = "320", VBR_BitMode = "-q:a", VBR = "9"  },
             new ViewModel.AudioQuality() { Name = "256",    CBR_BitMode = "-b:a", CBR = "256", VBR_BitMode = "-q:a", VBR = "8"  },
             new ViewModel.AudioQuality() { Name = "224",    CBR_BitMode = "-b:a", CBR = "224", VBR_BitMode = "-q:a", VBR = "7"  },
             new ViewModel.AudioQuality() { Name = "192",    CBR_BitMode = "-b:a", CBR = "192", VBR_BitMode = "-q:a", VBR = "6"  },
             new ViewModel.AudioQuality() { Name = "160",    CBR_BitMode = "-b:a", CBR = "160", VBR_BitMode = "-q:a", VBR = "5"  },
             new ViewModel.AudioQuality() { Name = "128",    CBR_BitMode = "-b:a", CBR = "128", VBR_BitMode = "-q:a", VBR = "4"  },
             new ViewModel.AudioQuality() { Name = "96",     CBR_BitMode = "-b:a", CBR = "96",  VBR_BitMode = "-q:a", VBR = "2"  },
             new ViewModel.AudioQuality() { Name = "Custom", CBR_BitMode = "-b:a", CBR = "",    VBR_BitMode = "-q:a", VBR = ""   },
             new ViewModel.AudioQuality() { Name = "Mute",   CBR_BitMode = "",     CBR = "",    VBR_BitMode = "",     VBR = ""   }
        };

        // -------------------------
        // Stream
        // -------------------------
        public static string stream = "all";

        // -------------------------
        // Channel
        // -------------------------
        public static List<string> channel = new List<string>()
        {
            "Source",
            "Stereo",
            "Mono",
            "5.1"
        };

        // -------------------------
        // Sample Rate
        // -------------------------
        public static List<ViewModel.AudioSampleRate> sampleRate = new List<ViewModel.AudioSampleRate>()
        {
             new ViewModel.AudioSampleRate() { Name = "auto",     Frequency = "" },
             new ViewModel.AudioSampleRate() { Name = "8k",       Frequency = "8000" },
             new ViewModel.AudioSampleRate() { Name = "11.025k",  Frequency = "11025" },
             new ViewModel.AudioSampleRate() { Name = "12k",      Frequency = "12000" },
             new ViewModel.AudioSampleRate() { Name = "16k",      Frequency = "16000" },
             new ViewModel.AudioSampleRate() { Name = "22.05k",   Frequency = "22050" },
             new ViewModel.AudioSampleRate() { Name = "24k",      Frequency = "24000" },
             new ViewModel.AudioSampleRate() { Name = "32k",      Frequency = "32000" },
             new ViewModel.AudioSampleRate() { Name = "44.1k",    Frequency = "44100" },
             new ViewModel.AudioSampleRate() { Name = "48k",      Frequency = "48000" }
        };
        //public static List<string> sampleRate = new List<string>()
        //{
        //    "auto",
        //    "8k",
        //    "11.025k",
        //    "12k",
        //    "16k",
        //    "22.05k",
        //    "24k",
        //    "32k",
        //    "44.1k",
        //    "48k"
        //};

        // -------------------------
        // Bit Depth
        // -------------------------
        public static List<ViewModel.AudioBitDepth> bitDepth = new List<ViewModel.AudioBitDepth>()
        {
             new ViewModel.AudioBitDepth() { Name = "auto", Depth = "" }
        };
        //public static List<string> bitDepth = new List<string>()
        //{
        //    "auto"
        //};

        // -------------------------
        // Checked
        // -------------------------
        public static void controlsChecked(ViewModel vm)
        {
            // Bitrate Mode
            vm.AudioVBR_IsChecked = true;
        }

        // -------------------------
        // Enabled
        // -------------------------
        public static void controlsEnable(ViewModel vm)
        {
            // Codec
            vm.AudioCodec_IsEnabled = true;

            // Stream
            vm.AudioStream_IsEnabled = true;

            // Channel
            vm.AudioChannel_IsEnabled = true;

            // Audio Quality
            vm.AudioQuality_IsEnabled = true;

            // Audio VBR
            vm.AudioVBR_IsEnabled = true;

            // SampleRate
            vm.AudioSampleRate_IsEnabled = true;

            // Volume
            vm.Volume_IsEnabled = true;
        }

        // -------------------------
        // Disabled
        // -------------------------
        public static void controlsDisable(ViewModel vm)
        {
            // Bit Depth
            vm.AudioBitDepth_IsEnabled = false;
        }

    }
}
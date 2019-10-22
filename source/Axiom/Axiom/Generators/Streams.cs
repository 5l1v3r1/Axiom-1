﻿/* ----------------------------------------------------------------------
Axiom UI
Copyright (C) 2017-2019 Matt McManis
https://github.com/MattMcManis/Axiom
https://axiomui.github.io
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
using System.Data;
using System.Linq;
using System.Windows.Documents;
// Disable XML Comment warnings
#pragma warning disable 1591
#pragma warning disable 1587
#pragma warning disable 1570

namespace Axiom
{
    public class Streams
    {
        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Variables
        /// <summary>
        // --------------------------------------------------------------------------------------------------------
        public static string vMap { get; set; } // video streams
        public static string cMap { get; set; } // video chapters
        public static string sMap { get; set; } // video subtitles
        public static string aMap { get; set; } // audio streams
        public static string mMap { get; set; } // file metadata
        //public static string map; // combines all maps


        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Process Methods
        /// </summary>
        // --------------------------------------------------------------------------------------------------------
        // --------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Video Stream Maps
        /// </summary>
        public static String VideoStreamMaps()
        {
            // WARNING: If a map is enabled, all other map types must be specified or they will be removed !!!
            // Question Mark ? = ignore warnings

            // --------------------------------------------------------------------
            // Video Map
            // --------------------------------------------------------------------
            // -------------------------
            // Video Formats
            // -------------------------
            if (VM.FormatView.Format_Container_SelectedItem == "webm")
            {
                vMap = "-map 0:v:0?"; // only video track 1
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "mp4")
            {
                vMap = "-map 0:v:0?"; // only video track 1
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "mkv")
            {
                vMap = "-map 0:v?"; // all video tracks
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "m2v")
            {
                vMap = "-map 0:v?"; // all video tracks
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "mpg")
            {
                vMap = "-map 0:v?"; // all video tracks
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "avi")
            {
                vMap = "-map 0:v:0?"; // only video track 1
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "ogv")
            {
                vMap = "-map 0:v?"; // all video tracks
            }
            // -------------------------
            // Non-Video Formats
            // -------------------------
            else
            {
                vMap = string.Empty; // do not copy video map
            }

            // -------------------------
            // Video Codecs
            // -------------------------
            if (VM.VideoView.Video_Codec_SelectedItem == "None")
            {
                vMap = "-vn"; // only video track 1
            }

            // -------------------------
            // Remove Video Map if Input File is Audio Format
            // -------------------------
            if (Format.AudioFormats.Any(s => s.Equals(MainWindow.inputExt, StringComparison.OrdinalIgnoreCase))
                //|| Format.AudioFormats.Any(s => s.Equals(MainWindow.batchExt, StringComparison.OrdinalIgnoreCase))
                )
            {
                vMap = string.Empty;
            }


            // Log Console Message /////////
            Log.WriteAction = () =>
            {
                Log.logParagraph.Inlines.Add(new LineBreak());
                Log.logParagraph.Inlines.Add(new Bold(new Run("Video Stream: ")) { Foreground = Log.ConsoleDefault });
                Log.logParagraph.Inlines.Add(new Run("all") { Foreground = Log.ConsoleDefault });
            };
            Log.LogActions.Add(Log.WriteAction);



            // --------------------------------------------------------------------
            // Chapters Map
            // --------------------------------------------------------------------
            // -------------------------
            // Video Formats
            // -------------------------
            if (VM.FormatView.Format_Container_SelectedItem == "webm")
            {
                cMap = "-map_chapters -1"; // remove chapters
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "mp4")
            {
                cMap = "-map_chapters 0"; // all chapters
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "mkv")
            {
                cMap = "-map_chapters 0"; // all chapters
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "m2v")
            {
                cMap = "-map_chapters -1"; // remove chapters
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "mpg")
            {
                cMap = "-map_chapters 0"; // all chapters
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "avi")
            {
                cMap = "-map_chapters 0"; // all chapters
            }
            else if (VM.FormatView.Format_Container_SelectedItem == "ogv")
            {
                cMap = "-map_chapters 0"; // all chapters
            }
            // -------------------------
            // All Other Formats
            // -------------------------
            else
            {
                cMap = string.Empty; // do not copy chapters
            }

            // -------------------------
            // Remove Chapters Map if Input File is Audio Format
            // -------------------------
            if (Format.AudioFormats.Any(s => s.Equals(MainWindow.inputExt, StringComparison.OrdinalIgnoreCase))
                //|| Format.AudioFormats.Any(s => s.Equals(MainWindow.batchExt, StringComparison.OrdinalIgnoreCase))
                )
            {
                cMap = string.Empty;
            }


            // Log Console Message /////////
            Log.WriteAction = () =>
            {
                Log.logParagraph.Inlines.Add(new LineBreak());
                Log.logParagraph.Inlines.Add(new Bold(new Run("Chapters: ")) { Foreground = Log.ConsoleDefault });
                Log.logParagraph.Inlines.Add(new Run(Streams.cMap) { Foreground = Log.ConsoleDefault });
            };
            Log.LogActions.Add(Log.WriteAction);


            // --------------------------------------------------------------------
            // Combine Maps
            // --------------------------------------------------------------------
            // Make List
            List<string> mapList = new List<string>() { vMap, cMap };
            // Join List with Spaces, Remove Empty Strings
            string map = string.Join(" ", mapList.Where(s => !string.IsNullOrEmpty(s)));


            // Return Value
            return map;
        }


        /// <summary>
        /// Subtitle Maps
        /// </summary>
        public static String SubtitleMaps()
        {
            // --------------------------------------------------------------------
            // Subtitle Map
            // --------------------------------------------------------------------

            if (VM.SubtitleView.Subtitle_Codec_SelectedItem != "Burn") // Ignore if Burn
            {
                // -------------------------
                // None
                // -------------------------
                if (VM.SubtitleView.Subtitle_Stream_SelectedItem == "none")
                {
                    sMap = "-sn";
                }
                // -------------------------
                // External
                // -------------------------
                else if (VM.SubtitleView.Subtitle_Stream_SelectedItem == "external")
                {
                    // -------------------------
                    // Map
                    // -------------------------
                    List<string> subtitleMapsList = new List<string>();

                    if (Subtitle.subtitleFilePathsList.Count > 0)
                    {
                        // Give each Subtitle File it's own map
                        for (var i = 0; i < Subtitle.subtitleFilePathsList.Count; i++)
                        {
                            subtitleMapsList.Add("-map " + (i + 1).ToString() + ":s?");
                        }
                    }

                    // Join multiple maps: -map 1:s? -map 2:s? -map 3:s?
                    sMap = string.Join(" ", subtitleMapsList.Where(s => !string.IsNullOrEmpty(s)));


                    // -------------------------
                    // Default Subtitle
                    // -------------------------
                    string checkedItem = string.Empty;
                    for (var i = 0; i < VM.SubtitleView.Subtitle_ListView_Items.Count; i++)
                    {
                        // If list contains a checked item
                        if (VM.SubtitleView.Subtitle_ListView_SelectedItems.Contains(VM.SubtitleView.Subtitle_ListView_Items[i]))
                        {
                            // Get Index Position
                            checkedItem = i.ToString();
                        }
                    }
                    //for (var i = 0; i < mainwindow.lstvSubtitles.Items.Count; i++)
                    //{
                    //    // If list contains a checked item
                    //    if (mainwindow.lstvSubtitles.SelectedItems.Contains(mainwindow.lstvSubtitles.Items[i]))
                    //    {
                    //        // Get Index Position
                    //        checkedItem = i.ToString();
                    //    }
                    //}

                    // Create Default Subtitle
                    string disposition = string.Empty;
                    if (!string.IsNullOrEmpty(checkedItem))
                    {
                        disposition = " \r\n-disposition:s:" + checkedItem + " default";
                    }

                    // Combine Map + Default
                    sMap = sMap + disposition;
                }

                // -------------------------
                // All
                // -------------------------
                else if (VM.SubtitleView.Subtitle_Stream_SelectedItem == "all")
                {
                    // Formats
                    //
                    if (VM.FormatView.Format_Container_SelectedItem == "webm")
                    {
                        sMap = "-sn"; // no subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "mp4")
                    {
                        sMap = "-map 0:s?"; // all subtitles (:? at the end ignores error if subtitle is not available)
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "mkv")
                    {
                        sMap = "-map 0:s?"; // all subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "m2v")
                    {
                        sMap = "-sn"; //  no subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "mpg")
                    {
                        sMap = "-map 0:s?"; // all subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "avi")
                    {
                        sMap = "-map 0:s?"; // all subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "ogv")
                    {
                        sMap = "-map 0:s?"; // all subtitles, OGV has problem using Subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "jpg")
                    {
                        sMap = "-sn"; // disable subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "png")
                    {
                        sMap = "-sn"; // disable subtitles
                    }
                    else if (VM.FormatView.Format_Container_SelectedItem == "webp")
                    {
                        sMap = "-sn"; // disable subtitles
                    }
                    // Non-Video/Image Formats
                    //
                    else
                    {
                        sMap = "-sn"; // disable subtitles
                    }
                }
                // -------------------------
                // Number
                // -------------------------
                else
                {
                    // Subtract 1, Map starts at 0
                    int sMapNumber = Int32.Parse(VM.SubtitleView.Subtitle_Stream_SelectedItem) - 1;

                    sMap = "-map 1:s:" + sMapNumber + "?";

                    // Image
                    if (VM.FormatView.Format_Container_SelectedItem == "jpg" ||
                        VM.FormatView.Format_Container_SelectedItem == "png" ||
                        VM.FormatView.Format_Container_SelectedItem == "webp")
                    {
                        sMap = "-sn";
                    }
                }

                // -------------------------
                // Remove Subtitle Map if Input File is Audio Format
                // -------------------------
                if (Format.AudioFormats.Any(s => s.Equals(MainWindow.inputExt, StringComparison.OrdinalIgnoreCase))
                    //|| Format.AudioFormats.Any(s => s.Equals(MainWindow.batchExt, StringComparison.OrdinalIgnoreCase))
                    )
                {
                    sMap = string.Empty;
                }
            }

            // Log Console Message /////////
            Log.WriteAction = () =>
            {
                Log.logParagraph.Inlines.Add(new LineBreak());
                Log.logParagraph.Inlines.Add(new Bold(new Run("Subtitle Stream: ")) { Foreground = Log.ConsoleDefault });
                Log.logParagraph.Inlines.Add(new Run(VM.SubtitleView.Subtitle_Stream_SelectedItem) { Foreground = Log.ConsoleDefault });
            };
            Log.LogActions.Add(Log.WriteAction);

            // --------------------------------------------------------------------
            // Combine Maps
            // --------------------------------------------------------------------
            // Make List
            List<string> mapList = new List<string>() { sMap };
            // Join List with Spaces, Remove Empty Strings
            string map = string.Join(" ", mapList.Where(s => !string.IsNullOrEmpty(s)));

            // Return Value
            return map;
        }




        /// <summary>
        /// Audio Stream Maps
        /// </summary>
        public static String AudioStreamMaps()
        {
            // --------------------------------------------------------------------
            // Audio Map
            // --------------------------------------------------------------------
            // Offset by 1. VLC starts with #1, FFprobe starts with #a:0.
            // WARNING: IF Audio Map Enabled, Video Map must also be enabled or no video !!!!!!!!!!

            // -------------------------
            // None
            // -------------------------
            if (VM.AudioView.Audio_Stream_SelectedItem == "none")
            {
                aMap = "-an";
            }
            // -------------------------
            // All
            // -------------------------
            else if (VM.AudioView.Audio_Stream_SelectedItem == "all")
            {
                // Video/Image Format
                //
                if (VM.FormatView.Format_Container_SelectedItem == "webm")
                {
                    aMap = "-map 0:a:0?"; // only audio track 1
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "mp4")
                {
                    aMap = "-map 0:a?"; // all audio tracks 
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "mkv")
                {
                    aMap = "-map 0:a?"; // all audio tracks 
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "m2v")
                {
                    aMap = "-an"; // disable audio
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "mpg")
                {
                    aMap = "-map 0:a?"; // all audio tracks 
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "avi")
                {
                    aMap = "-map 0:a?"; // all audio tracks 
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "ogv")
                {
                    aMap = "-map 0:a?"; // all audio tracks 
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "jpg")
                {
                    aMap = "-an"; // disable audio
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "png")
                {
                    aMap = "-an"; // disable audio
                }
                else if (VM.FormatView.Format_Container_SelectedItem == "webp")
                {
                    aMap = "-an"; // disable audio
                }

                // Audio Media Type
                //
                else if (VM.FormatView.Format_MediaType_SelectedItem == "Audio")
                {
                    aMap = "-map 0:a:0?"; // only audio track 1
                }
            }
            // -------------------------
            // Number
            // -------------------------
            else
            {
                // Subtract 1, Map starts at 0
                int aMapNumber = Int32.Parse(VM.AudioView.Audio_Stream_SelectedItem) - 1;

                aMap = "-map 0:a:" + aMapNumber + "?";
            }

            // -------------------------
            // Remove Audio Map if Input File is Audio Format
            // -------------------------
            if (Format.AudioFormats.Any(s => s.Equals(MainWindow.inputExt, StringComparison.OrdinalIgnoreCase))
                //|| Format.AudioFormats.Any(s => s.Equals(MainWindow.batchExt, StringComparison.OrdinalIgnoreCase))
                )
            {
                aMap = string.Empty;
            }

            // -------------------------
            // Mute
            // -------------------------
            if (VM.AudioView.Audio_Quality_SelectedItem == "Mute")
            {
                aMap = "-an";
            }


            // --------------------------------------------------------------------
            // Combine Maps
            // --------------------------------------------------------------------
            // Make List
            List<string> mapList = new List<string>() { aMap };
            // Join List with Spaces, Remove Empty Strings
            string map = string.Join(" ", mapList.Where(s => !string.IsNullOrEmpty(s)));


            // Log Console Message /////////
            Log.WriteAction = () =>
            {
                Log.logParagraph.Inlines.Add(new LineBreak());
                Log.logParagraph.Inlines.Add(new Bold(new Run("Audio Stream: ")) { Foreground = Log.ConsoleDefault });
                Log.logParagraph.Inlines.Add(new Run(VM.AudioView.Audio_Stream_SelectedItem) { Foreground = Log.ConsoleDefault });
            };
            Log.LogActions.Add(Log.WriteAction);


            // Return Value
            return map;
        }



        /// <summary>
        /// Format Maps
        /// </summary>
        public static String FormatMaps()
        {
            // --------------------------------------------------------------------
            // Metadata Map
            // --------------------------------------------------------------------
            // Go by Format Container

            // -------------------------
            // mp3
            // -------------------------
            if (VM.FormatView.Format_Container_SelectedItem == "mp3")
            {
                mMap = "-map_metadata 0 -id3v2_version 3";
            }
            // -------------------------
            // jpg
            // -------------------------
            else if (VM.FormatView.Format_Container_SelectedItem == "jpg")
            {
                mMap = string.Empty; // do not copy metadata
            }
            // -------------------------
            // png
            // -------------------------
            else if (VM.FormatView.Format_Container_SelectedItem == "png")
            {
                mMap = string.Empty; // do not copy metadata
            }
            // -------------------------
            // webp
            // -------------------------
            else if (VM.FormatView.Format_Container_SelectedItem == "webp")
            {
                mMap = string.Empty; // do not copy metadata
            }
            // -------------------------
            // All Other Formats
            // -------------------------
            else
            {
                mMap = "-map_metadata 0"; // copy all metadata
            }


            // --------------------------------------------------------------------
            // Combine Maps
            // --------------------------------------------------------------------
            // Make List
            List<string> mapList = new List<string>() { mMap };
            // Join List with Spaces, Remove Empty Strings
            string map = string.Join(" ", mapList.Where(s => !string.IsNullOrEmpty(s)));


            // Return Value
            return map;
        }

    }
}

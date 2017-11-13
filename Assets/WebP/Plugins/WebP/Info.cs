
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace WebP
{
    public class Info
    {
        public static string GetDecoderVersion()
        {
            uint v = 0;
            v = (uint)WebP.Extern.NativeBindings.WebPGetDecoderVersion();

            var revision = v % 256;
            var minor = (v >> 8) % 256;
            var major = (v >> 16) % 256;
            return major + "." + minor + "." + revision;
        }

        public static string GetEncoderVersion()
        {
            uint v = 0;
            v = (uint)WebP.Extern.NativeBindings.WebPGetEncoderVersion();

            var revision = v % 256;
            var minor = (v >> 8) % 256;
            var major = (v >> 16) % 256;
            return major + "." + minor + "." + revision;
        }
    }
}

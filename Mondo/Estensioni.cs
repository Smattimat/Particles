using System;
using Raylib_cs;

namespace Mondo {
    public static class Extensioni {
        public static Color toRaylibColor(this System.Drawing.Color c) {
            return new Color() { a = c.A, r = c.R, g = c.G, b = c.B };
        }
    }
}

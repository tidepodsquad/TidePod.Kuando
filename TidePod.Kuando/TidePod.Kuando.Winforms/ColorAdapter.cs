using System;
using System.Diagnostics;
using System.Drawing;
using Busylight;

namespace TidePod.Kuando.Winforms
{
    [DebuggerDisplay("({SystemColor.R}, {SystemColor.G}, {SystemColor.B}) ({Name,nq})")]
    public readonly struct ColorAdapter
    {
        public ColorAdapter(
            byte red,
            byte green,
            byte blue,
            string? name = null)
        {
            this.SystemColor = Color.FromArgb(red, green, blue);
            this.Name = name;
        }

        public static ColorAdapter Red { get; } = new ColorAdapter(255, 0, 0, nameof(Red));

        public static ColorAdapter Orange { get; } = new ColorAdapter(255, 128, 0, nameof(Orange));

        public static ColorAdapter Yellow { get; } = new ColorAdapter(255, 255, 0, nameof(Yellow));

        public static ColorAdapter Citron { get; } = new ColorAdapter(150, 255, 0, nameof(Citron));

        public static ColorAdapter Green { get; } = new ColorAdapter(0, 255, 0, nameof(Green));

        public static ColorAdapter Blue { get; } = new ColorAdapter(0, 0, 255, nameof(Blue));

        public static ColorAdapter Violet { get; } = new ColorAdapter(64, 0, 255, nameof(Violet));

        public static ColorAdapter Magenta { get; } = new ColorAdapter(255, 0, 255, nameof(Magenta));

        public static ColorAdapter White { get; } = new ColorAdapter(255, 255, 255, nameof(White));

        public static ColorAdapter Off { get; } = new ColorAdapter(0, 0, 0, nameof(Off));

        public Color SystemColor { get; }

        public string? Name { get; }

        public static implicit operator BusylightColor(ColorAdapter adapter)
        {
            return new BusylightColor()
            {
                RedRgbValue = ColorAdapter.Adjust(adapter.SystemColor, Channel.R),
                GreenRgbValue = ColorAdapter.Adjust(adapter.SystemColor, Channel.G),
                BlueRgbValue = ColorAdapter.Adjust(adapter.SystemColor, Channel.B)
            };
        }

        public static implicit operator Color(ColorAdapter adapter)
        {
            return adapter.SystemColor;
        }

        private enum Channel
        {
            R,
            G,
            B
        }

        private static byte Adjust(Color color, Channel channel)
        {
            byte Correct(byte input)
            {
                double val = 1D / (1.29591807111009E-01D + (-2.17309284733586E-02D * Math.Log(input))) - 10D;
                if (input == 0)
                {
                    return 0;
                }
                else if (input == 255 || val > 255)
                {
                    return 255;
                }
                else if (val < 1)
                {
                    if (input > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return (byte)val;
                }
            }

            int luminance = color.R + color.G + color.B;
            byte currentChannelValue =
                channel switch
                {
                    Channel.R => color.R,
                    Channel.G => color.G,
                    Channel.B => color.B,
                    _ => throw new InvalidOperationException()
                };

            byte val = Correct(currentChannelValue);
            return val;
        }
    }
}

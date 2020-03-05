namespace TidePod.Kuando.Shared
{
    public sealed class ColorMessage
    {
        public ColorMessage(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public byte Red { get; }

        public byte Green { get; }

        public byte Blue { get; }
    }
}

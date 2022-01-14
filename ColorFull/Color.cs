﻿using System.Drawing;

namespace ToolBX.ColorFull;

/// <summary>
/// Represents an RGBA color.
/// </summary>
public readonly record struct Color
{
    public byte Red { get; init; }
    public byte Green { get; init; }
    public byte Blue { get; init; }
    public byte Alpha { get; init; } = byte.MaxValue;

    public Color(byte red, byte green, byte blue) : this(red, green, blue, byte.MaxValue)
    {

    }

    public Color(int red, int green, int blue) : this((byte)red, (byte)green, (byte)blue)
    {

    }

    public Color(float red, float green, float blue) : this((byte)red, (byte)green, (byte)blue)
    {

    }

    public Color(double red, double green, double blue) : this((byte)red, (byte)green, (byte)blue)
    {

    }

    public Color(byte red, byte green, byte blue, byte alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public Color(int red, int green, int blue, int alpha) : this((byte)red, (byte)green, (byte)blue, (byte)alpha)
    {

    }

    public Color(float red, float green, float blue, float alpha) : this((byte)red, (byte)green, (byte)blue, (byte)alpha)
    {

    }

    public Color(double red, double green, double blue, double alpha) : this((byte)red, (byte)green, (byte)blue, (byte)alpha)
    {

    }

    /// <summary>
    /// Converts a hexadecimal color code to an RGBA color.
    /// </summary>
    public static Color FromHtml(string hex)
    {
        if (string.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException(nameof(hex));
        if (!hex.StartsWith('#')) hex = $"#{hex}";
        var unhexed = ColorTranslator.FromHtml(hex);
        return new Color(unhexed.R, unhexed.G, unhexed.B, unhexed.A);
    }

    /// <summary>
    /// Converts RGBA color to an hexadecimal color code.
    /// </summary>
    public string ToHtml() => ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(Alpha, Red, Green, Blue));

    public override string ToString() => $"{{R: {Red} G: {Green} B: {Blue} A: {Alpha}}}";

    public static implicit operator Color(System.Drawing.Color value) => new(value.R, value.G, value.B, value.A);

    public static implicit operator System.Drawing.Color(Color value) => System.Drawing.Color.FromArgb(value.Alpha, value.Red, value.Green, value.Blue);
}
![ColorFull](https://github.com/Moreault/ColorFull/blob/master/colorfull.png)
# ColorFull
A lightweight re-implementation of the color struct.

## Why?
I don't really like the base offering for `Color` so I decided to make my own.

It's still compatible with the one from `System.Drawing`, including implicit conversion.

## Getting started

You can use it the same way as `System.Drawing.Color`.

```c#
var color = new Color(255, 255, 255, 255);

//Or using the initializer
var color = new Color 
{
  Red = 255,
  Green = 255,
  Blue = 255,
  Alpha = 255
};
```

## Conversions

- ToHtml : Converts your `Color` to an hexadecimal color code for use in HTML. Ex : `color.ToHtml();`
- FromHtml : Takes an hexadecimal and converts it to an RGBA `Color` struct. Ex : `Color.FromHtml("#FF5733");`
- Also contains an explicit convertor for `ConsoleColor`. Ex : `var newColor = (ConsoleColor)color;`

![ColorFull](https://github.com/Moreault/ColorFull/blob/master/colorfull.png)

# ColorFull
A lightweight re-implementation of the color struct.

The color struct from .NET's System.Drawing is rather heavy when you really just want a container for red, green, blue and alpha values. 

This library aims to change that by providing easier to use methods and clearer names.

Game engines often re-implement this struct in their own way and this small package is meant to unify these implementations under a simpler type.

## Getting started

```c#
public void SomeShadyMethod()
{
	//Returns a color with red, green and blue values. Alpha is implicitly maxed out (255)
	var color1 = new Color(255, 255, 125);

	//Alpha is specified in this case 
	var color2 = new Color(68, 125, 200, 45);

	//You can also just use the initializer if you're one of those people who hate constructors. Omitting alpha also initializes it to 255
	var color3 = new Color
    {
        Red = 250,
        Green = 128,
        Blue = 114
    };

    //Or you can also just specify it as well
	var color4 = new Color
    {
        Red = 250,
        Green = 128,
        Blue = 114,
        Alpha = 150
    };

    //Or if you really just want a red color with nothing else
    var color5 = new Color { Red = 255 };

    //If you liked color3 but wanted to adjust its blue value
    var color6 = color3 with { Blue = 189 };
}
```

## Compatibility with System.Drawing

Yes, you can actually use it instead of System.Drawing since it has an implicit conversion operator.

What that means is that whenever you use ColorFull.Color in a method that asks for System.Drawing.Color, .NET will automatically convert that ColorFull.Color to a System.Drawing.Color under the hood.

I wouldn't abuse it but it's there if you need it.

## Did you seriously create a whole package just for a measly little struct?!

Yeah, I did. It might grow beyond that and include more eventually. Or not.
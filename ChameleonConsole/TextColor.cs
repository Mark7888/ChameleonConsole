using System;
using System.Collections.Generic;
using System.Linq;

namespace ChameleonConsole
{
    /// <summary>
    /// Represents a utility class for handling text colors in the console.
    /// </summary>
    /// <remarks>
    /// This class provides functionality to create and configure TextColor objects for customized console output.
    /// </remarks>
    public class TextColor
    {
        /// <summary>
        /// Gets or sets a value indicating whether automatic resetting of color configurations is enabled.
        /// </summary>
        /// <remarks>
        /// When set to true, color configurations will automatically reset after each use.
        /// </remarks>
        public static bool AutoReset = true;

        /// <summary>
        /// Gets the default foreground color for the console.
        /// </summary>
        /// <value>The default foreground color.</value>
        /// <remarks>
        /// This color is used when no specific foreground color is provided.
        /// </remarks>
        public static ConsoleColor DefaultFore => ConsoleColor.White;

        /// <summary>
        /// Gets the default background color for the console.
        /// </summary>
        /// <value>The default background color.</value>
        /// <remarks>
        /// This color is used when no specific background color is provided.
        /// </remarks>
        public static ConsoleColor DefaultBack => ConsoleColor.Black;

        /// <summary>
        /// Gets a TextColor object representing the default foreground and background colors.
        /// </summary>
        /// <value>A TextColor object with the default foreground and background colors.</value>
        public static TextColor ResetAll => new TextColor(DefaultFore, DefaultBack);

        private bool IsWrapper = false;
        private string BaseText = "";

        /// <summary>
        /// Gets or sets the foreground color of the TextColor.
        /// </summary>
        /// <value>The foreground color of the TextColor, or null if not set.</value>
        public ConsoleColor? ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the TextColor.
        /// </summary>
        /// <value>The background color of the TextColor, or null if not set.</value>
        public ConsoleColor? BackColor { get; set; }
        private bool ForeColorSet => ForeColor.HasValue;
        private bool BackColorSet => BackColor.HasValue;

        private List<TextColor> ColoredTexts = new List<TextColor>();


        /// <summary>
        /// Initializes a new instance of the TextColor class with default values.
        /// </summary>
        /// <remarks>
        /// The TextColor instance is created with default values for text, foreground color, and background color.
        /// </remarks>
        public TextColor() { }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified base text.
        /// </summary>
        /// <param name="text">The base text for the TextColor.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified base text and default values for foreground and background colors.
        /// </remarks>
        public TextColor(string text)
        {
            BaseText = text;
        }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified foreground color.
        /// </summary>
        /// <param name="foreColor">The foreground color for the TextColor.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified foreground color and default values for base text and background color.
        /// </remarks>
        public TextColor(ConsoleColor foreColor)
        {
            ForeColor = foreColor;
        }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified background color.
        /// </summary>
        /// <param name="backColor">The background color for the TextColor.</param>
        /// <param name="isBackground">A boolean flag (placeholder) indicating the intended usage of the color. This flag does not affect the actual behavior of the TextColor instance.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified background color and default values for base text and foreground color.
        /// </remarks>
        public TextColor(ConsoleColor backColor, bool isBackground)
        {
            BackColor = backColor;
        }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified base text and foreground color.
        /// </summary>
        /// <param name="text">The base text for the TextColor.</param>
        /// <param name="foreColor">The foreground color for the TextColor.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified base text and foreground color, and default values for background color.
        /// </remarks>
        public TextColor(string text, ConsoleColor foreColor)
        {
            BaseText = text;
            ForeColor = foreColor;
        }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified base text and background color.
        /// </summary>
        /// <param name="text">The base text for the TextColor.</param>
        /// <param name="backColor">The background color for the TextColor.</param>
        /// <param name="isBackground">A boolean flag (placeholder) indicating the intended usage of the color. This flag does not affect the actual behavior of the TextColor instance.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified base text and background color, and default values for foreground color.
        /// </remarks>
        public TextColor(string text, ConsoleColor backColor, bool isBackground)
        {
            BaseText = text;
            BackColor = backColor;
        }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified foreground and background colors.
        /// </summary>
        /// <param name="foreColor">The foreground color for the TextColor.</param>
        /// <param name="backColor">The background color for the TextColor.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified foreground and background colors.
        /// </remarks>
        public TextColor(ConsoleColor foreColor, ConsoleColor backColor)
        {
            ForeColor = foreColor;
            BackColor = backColor;
        }
        /// <summary>
        /// Initializes a new instance of the TextColor class with the specified base text, foreground, and background colors.
        /// </summary>
        /// <param name="text">The base text for the TextColor.</param>
        /// <param name="foreColor">The foreground color for the TextColor.</param>
        /// <param name="backColor">The background color for the TextColor.</param>
        /// <remarks>
        /// The TextColor instance is created with the specified base text, foreground, and background colors.
        /// </remarks>
        public TextColor(string text, ConsoleColor foreColor, ConsoleColor backColor)
        {
            BaseText = text;
            ForeColor = foreColor;
            BackColor = backColor;
        }


        /// <summary>
        /// Applies the configured text and background colors to the console.
        /// </summary>
        /// <remarks>
        /// This function sets the console colors based on the properties of the TextColor class.
        /// If either the foreground or background color is not set in the TextColor instance,
        /// the corresponding console color remains unchanged.
        /// </remarks>
        public void ApplyColors()
        {
            ApplyColors(this);
        }
        /// <summary>
        /// Applies the configured text and background colors to the console.
        /// </summary>
        /// <remarks>
        /// This function sets the console colors based on the properties of the TextColor class.
        /// If either the foreground or background color is not set in the TextColor instance,
        /// the corresponding console color remains unchanged.
        /// </remarks>
        public static void ApplyColors(TextColor obj)
        {
            if (obj.ForeColorSet) Console.ForegroundColor = (ConsoleColor)obj.ForeColor;
            if (obj.BackColorSet) Console.BackgroundColor = (ConsoleColor)obj.BackColor;
        }


        /// <summary>
        /// Recursively visualizes the hierarchy of a TextColor object and its children by printing their content to the console.
        /// </summary>
        /// <remarks>
        /// This function prints information about the provided TextColor object and its children, including base text,
        /// foreground and background colors, and the content of each child TextColor object.
        /// The output is indented based on the specified indentation level.
        /// </remarks>
        public void Visualize()
        {
            Visualize(this);
        }
        /// <summary>
        /// Recursively visualizes the hierarchy of a TextColor object and its children by printing their content to the console.
        /// </summary>
        /// <param name="obj">The TextColor object to visualize.</param>
        /// <param name="indent">The number of spaces to indent the output for hierarchical representation. Default is 0.</param>
        /// <remarks>
        /// This function prints information about the provided TextColor object and its children, including base text,
        /// foreground and background colors, and the content of each child TextColor object.
        /// The output is indented based on the specified indentation level.
        /// </remarks>
        public static void Visualize(TextColor obj, int indent = 0)
        {
            string indentedSpaces = new string(' ', indent);
            Console.WriteLine($"{indentedSpaces}- BaseText: '{obj.BaseText}'");
            Console.WriteLine($"{indentedSpaces}  ForeColor({obj.ForeColorSet}): {obj.ForeColor.ToString()}");
            Console.WriteLine($"{indentedSpaces}  BackColor({obj.BackColorSet}): {obj.BackColor.ToString()}");

            if (obj.ColoredTexts.Count == 0) return;

            Console.WriteLine($"{indentedSpaces}  Children:");
            foreach (TextColor child in obj.ColoredTexts)
            {
                Visualize(child, indent + 2);
            }
        }


        public static TextColor operator +(TextColor obj, string str)
        {
            if (obj.IsWrapper) obj.ColoredTexts.Last().BaseText += str;
            else obj.BaseText += str;

            return obj;
        }

        public static TextColor operator +(string str, TextColor obj)
        {
            if (obj.IsWrapper)
            {
                obj.ColoredTexts.Insert(0, str);
                return obj;
            }

            TextColor newObj = new TextColor();
            newObj.IsWrapper = true;

            newObj.ColoredTexts.Add(str);
            newObj.ColoredTexts.Add(obj);

            return newObj;
        }

        public static TextColor operator +(TextColor obj1, TextColor obj2)
        {
            TextColor newObj = new TextColor();
            newObj.IsWrapper = true;

            if (obj1.IsWrapper) newObj.ColoredTexts.AddRange(obj1.ColoredTexts);
            else newObj.ColoredTexts.Add(obj1);

            if (obj2.IsWrapper) newObj.ColoredTexts.AddRange(obj2.ColoredTexts);
            else newObj.ColoredTexts.Add(obj2);

            return newObj;
        }


        public static implicit operator TextColor(string str)
        {
            return new TextColor(str);
        }

        public static implicit operator string(TextColor obj)
        {
            return obj.ToString();
        }

        public override string ToString()
        {
            if (ColoredTexts.Count == 0) return BaseText;

            string text = "";
            foreach (TextColor tc in ColoredTexts)
            {
                text += tc.ToString();
            }
            return text;
        }


        /// <summary>
        /// Writes the colored output to the console without appending a new-line character.
        /// </summary>
        /// <remarks>
        /// This function writes the specified content to the console using the provided TextColor configuration.
        /// The output does not include a new-line character, allowing for custom formatting.
        /// </remarks>
        public void Write()
        {
            Write(this);
        }
        /// <summary>
        /// Writes the colored output to the console without appending a new-line character.
        /// </summary>
        /// <param name="obj">The TextColor object to write.</param>
        /// <remarks>
        /// This function writes the specified content to the console using the provided TextColor configuration.
        /// The output does not include a new-line character, allowing for custom formatting.
        /// </remarks>
        public static void Write(TextColor obj)
        {
            if (obj.IsWrapper)
            {
                foreach (TextColor tc in obj.ColoredTexts)
                {
                    tc.ApplyColors();
                    Console.Write(tc.BaseText);
                }
            }
            else
            {
                obj.ApplyColors();
                Console.Write(obj.BaseText);
            }
            if (AutoReset) Console.ResetColor();
        }


        /// <summary>
        /// Writes the colored output to the console and appends a new-line character.
        /// </summary>
        /// <remarks>
        /// This function writes the specified content to the console using the provided TextColor configuration.
        /// A new-line character is appended at the end of the output for line separation.
        /// </remarks>
        public void WriteLine()
        {
            WriteLine(this);
        }
        /// <summary>
        /// Writes the colored output to the console and appends a new-line character.
        /// </summary>
        /// <param name="obj">The TextColor object to write.</param>
        /// <remarks>
        /// This function writes the specified content to the console using the provided TextColor configuration.
        /// A new-line character is appended at the end of the output for line separation.
        /// </remarks>
        public static void WriteLine(TextColor obj)
        {
            Write(obj);
            Console.WriteLine();
        }
    }


    /// <summary>
    /// Provides preset instances of foreground colors for console text.
    /// </summary>
    /// <remarks>
    /// Use the properties of this class, such as Fore.Red or Fore.Reset, to easily set foreground colors for console text.
    /// </remarks>
    public static class Fore
    {
        /// <summary>
        /// Gets a preset instance representing a black foreground.
        /// </summary>
        public static TextColor Black => new TextColor(ConsoleColor.Black);
        /// <summary>
        /// Gets a preset instance representing a dark blue foreground.
        /// </summary>
        public static TextColor DarkBlue => new TextColor(ConsoleColor.DarkBlue);
        /// <summary>
        /// Gets a preset instance representing a dark green foreground.
        /// </summary>
        public static TextColor DarkGreen => new TextColor(ConsoleColor.DarkGreen);
        /// <summary>
        /// Gets a preset instance representing a dark cyan foreground.
        /// </summary>
        public static TextColor DarkCyan => new TextColor(ConsoleColor.DarkCyan);
        /// <summary>
        /// Gets a preset instance representing a dark red foreground.
        /// </summary>
        public static TextColor DarkRed => new TextColor(ConsoleColor.DarkRed);
        /// <summary>
        /// Gets a preset instance representing a dark magenta foreground.
        /// </summary>
        public static TextColor DarkMagenta => new TextColor(ConsoleColor.DarkMagenta);
        /// <summary>
        /// Gets a preset instance representing a dark yellow foreground.
        /// </summary>
        public static TextColor DarkYellow => new TextColor(ConsoleColor.DarkYellow);
        /// <summary>
        /// Gets a preset instance representing a gray foreground.
        /// </summary>
        public static TextColor Gray => new TextColor(ConsoleColor.Gray);
        /// <summary>
        /// Gets a preset instance representing a dark gray foreground.
        /// </summary>
        public static TextColor DarkGray => new TextColor(ConsoleColor.DarkGray);
        /// <summary>
        /// Gets a preset instance representing a blue foreground.
        /// </summary>
        public static TextColor Blue => new TextColor(ConsoleColor.Blue);
        /// <summary>
        /// Gets a preset instance representing a green foreground.
        /// </summary>
        public static TextColor Green => new TextColor(ConsoleColor.Green);
        /// <summary>
        /// Gets a preset instance representing a cyan foreground.
        /// </summary>
        public static TextColor Cyan => new TextColor(ConsoleColor.Cyan);
        /// <summary>
        /// Gets a preset instance representing a red foreground.
        /// </summary>
        public static TextColor Red => new TextColor(ConsoleColor.Red);
        /// <summary>
        /// Gets a preset instance representing a magenta foreground.
        /// </summary>
        public static TextColor Magenta => new TextColor(ConsoleColor.Magenta);
        /// <summary>
        /// Gets a preset instance representing a yellow foreground.
        /// </summary>
        public static TextColor Yellow => new TextColor(ConsoleColor.Yellow);
        /// <summary>
        /// Gets a preset instance representing a white foreground.
        /// </summary>
        public static TextColor White => new TextColor(ConsoleColor.White);

        /// <summary>
        /// Gets a preset instance representing the default foreground color.
        /// </summary>
        public static TextColor Reset => new TextColor(TextColor.DefaultFore);
    }


    /// <summary>
    /// Provides preset instances of background colors for console text.
    /// </summary>
    /// <remarks>
    /// Use the properties of this class, such as Back.Red or Back.Reset, to easily set background colors for console text.
    /// </remarks>
    public static class Back
    {
        /// <summary>
        /// Gets a preset instance representing black background color.
        /// </summary>
        public static TextColor Black => new TextColor(ConsoleColor.Black, true);
        /// <summary>
        /// Gets a preset instance representing dark blue background color.
        /// </summary>
        public static TextColor DarkBlue => new TextColor(ConsoleColor.DarkBlue, true);
        /// <summary>
        /// Gets a preset instance representing dark green background color.
        /// </summary>
        public static TextColor DarkGreen => new TextColor(ConsoleColor.DarkGreen, true);
        /// <summary>
        /// Gets a preset instance representing dark cyan background color.
        /// </summary>
        public static TextColor DarkCyan => new TextColor(ConsoleColor.DarkCyan, true);
        /// <summary>
        /// Gets a preset instance representing dark red background color.
        /// </summary>
        public static TextColor DarkRed => new TextColor(ConsoleColor.DarkRed, true);
        /// <summary>
        /// Gets a preset instance representing dark magenta background color.
        /// </summary>
        public static TextColor DarkMagenta => new TextColor(ConsoleColor.DarkMagenta, true);
        /// <summary>
        /// Gets a preset instance representing dark yellow background color.
        /// </summary>
        public static TextColor DarkYellow => new TextColor(ConsoleColor.DarkYellow, true);
        /// <summary>
        /// Gets a preset instance representing gray background color.
        /// </summary>
        public static TextColor Gray => new TextColor(ConsoleColor.Gray, true);
        /// <summary>
        /// Gets a preset instance representing dark gray background color.
        /// </summary>
        public static TextColor DarkGray => new TextColor(ConsoleColor.DarkGray, true);
        /// <summary>
        /// Gets a preset instance representing blue background color.
        /// </summary>
        public static TextColor Blue => new TextColor(ConsoleColor.Blue, true);
        /// <summary>
        /// Gets a preset instance representing green background color.
        /// </summary>
        public static TextColor Green => new TextColor(ConsoleColor.Green, true);
        /// <summary>
        /// Gets a preset instance representing cyan background color.
        /// </summary>
        public static TextColor Cyan => new TextColor(ConsoleColor.Cyan, true);
        /// <summary>
        /// Gets a preset instance representing red background color.
        /// </summary>
        public static TextColor Red => new TextColor(ConsoleColor.Red, true);
        /// <summary>
        /// Gets a preset instance representing magenta background color.
        /// </summary>
        public static TextColor Magenta => new TextColor(ConsoleColor.Magenta, true);
        /// <summary>
        /// Gets a preset instance representing yellow background color.
        /// </summary>
        public static TextColor Yellow => new TextColor(ConsoleColor.Yellow, true);
        /// <summary>
        /// Gets a preset instance representing white background color.
        /// </summary>
        public static TextColor White => new TextColor(ConsoleColor.White, true);

        /// <summary>
        /// Gets a preset instance representing the default background color.
        /// </summary>
        public static TextColor Reset => new TextColor(TextColor.DefaultBack, true);
    }
}

[![publish](https://github.com/Mark7888/ChameleonConsole/actions/workflows/publish.yml/badge.svg)](https://github.com/Mark7888/ChameleonConsole/actions/workflows/publish.yml)
# ChameleonConsole - Dynamic Console Text Styling for C#

ChameleonConsole is a versatile C# library that empowers developers to add dynamic and expressive text styling to console applications. Whether you're building a command-line tool, a terminal application, or simply want to enhance the visual appeal of your console output, ChameleonConsole provides a convenient and intuitive way to play with colors.
ChameleonConsole draws inspiration from the renowned [Colorama](https://pypi.org/project/colorama/) Python library, bringing the joy of easy and vibrant text coloring to the C# world.
Explore the endless possibilities of dynamic console styling with **ChameleonConsole**!

## Key Features

1. **Expressive Text Styling:** Create eye-catching console output by easily applying dynamic text and background colors to your strings.

2. **Simplified API:** With a straightforward API, ChameleonConsole offers a range of predefined colors for foreground and background, making it effortless to stylize your text.

3. **Nested Styling:** Go beyond simple colors and create complex text layouts by nesting different styles within a single line, allowing for rich and visually appealing console displays.

4. **Testing Made Easy:** ChameleonConsole supports testing scenarios by providing a way to capture and validate styled console output in unit tests.

## Examples

```csharp
TextColor styledText = "Hello" + Fore.Green + "Chameleon" + Back.Yellow + "Console" + Fore.Reset + Back.Reset + "!";
styledText.Write();  // Display styled text to the console

// Nested styling for more complex layouts
TextColor nestedExample = "Start" + Fore.Blue + "Nested" + Back.Red + "Text" + Fore.Reset + Back.Reset + "End";
nestedExample.Write();
```

## Getting Started

1. **Install the Package:**
   ChameleonConsole is available as a NuGet package. You can install it using the following command:
   ```bash
   dotnet add package ChameleonConsole
   ```
   Visit the [ChameleonConsole NuGet Package](https://www.nuget.org/packages/ChameleonConsole/) page for more details and version history.

2. **Usage:**
   ```csharp
   using ChameleonConsole;

   // Create and style text
   TextColor styledText = "Hello" + Fore.Green + "Chameleon" + Back.Yellow + "Console" + Fore.Reset + Back.Reset + "!";
   styledText.Write();
   ```

## Compatibility

ChameleonConsole is compatible with .NET Standard 2.0, making it a versatile choice for a wide range of console applications.

Enhance your command-line experience with ChameleonConsole's dynamic styling capabilities. Bring life to your text and make your console output stand out effortlessly.

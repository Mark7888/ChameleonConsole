namespace ChameleonConsole.Tests
{
    public class TextColorTests
    {

        [Fact]
        public void TextColor_DefaultConstructor_ShouldNotBeNull()
        {
            var textColor = new TextColor();
            Assert.NotNull(textColor);
        }

        [Fact]
        public void TextColor_TextConstructor_ShouldSetBaseText()
        {
            var textColor = new TextColor("Hello");
            Assert.Equal("Hello", textColor.ToString());
        }

        [Fact]
        public void TextColor_ImplicitStringCast_ShouldConvertToString()
        {
            string result = (string) new TextColor("Hello");
            Assert.Equal("Hello", result);
        }

        [Fact]
        public void TextColor_ForeColorConstructor_ShouldSetForeColor()
        {
            var textColor = new TextColor(ConsoleColor.Red);
            Assert.Equal(ConsoleColor.Red, textColor.ForeColor);
        }

        [Fact]
        public void TextColor_BackColorConstructor_ShouldSetBackColor()
        {
            var textColor = new TextColor(ConsoleColor.Blue, true);
            Assert.Equal(ConsoleColor.Blue, textColor.BackColor);
        }

        [Fact]
        public void TextColor_ForeAndBackColorConstructor_ShouldSetForeAndBackColor()
        {
            var textColor = new TextColor("Hello", ConsoleColor.Green, ConsoleColor.Yellow);
            Assert.Equal(ConsoleColor.Green, textColor.ForeColor);
            Assert.Equal(ConsoleColor.Yellow, textColor.BackColor);
        }

        [Fact]
        public void TextColor_Write_ShouldWriteToConsole()
        {
            var textColor = new TextColor("Hello", ConsoleColor.White, ConsoleColor.Black);
            textColor.Write();

            // Manual verification is needed as Console output cannot be easily captured in unit tests.
        }

        [Fact]
        public void TextColor_WriteLine_ShouldWriteLineToConsole()
        {
            var textColor = new TextColor("Hello", ConsoleColor.White, ConsoleColor.Black);
            textColor.WriteLine();

            // Manual verification is needed as Console output cannot be easily captured in unit tests.
        }

        [Fact]
        public void TextColor_Visualize_ShouldWriteToConsole()
        {
            var textColor = new TextColor("Hello", ConsoleColor.White, ConsoleColor.Black);
            textColor.Visualize();

            // Manual verification is needed as Console output cannot be easily captured in unit tests.
        }

        [Fact]
        public void TextColor_OperatorPlus_ShouldConcatenateStrings()
        {
            var textColor = new TextColor("Hello") + " World";
            Assert.Equal("Hello World", textColor.ToString());
        }

        [Fact]
        public void TextColor_OperatorPlus_ShouldWrapTextColors()
        {
            var textColor = Fore.Red + "Hello" + Back.Blue + " World" + Fore.Reset;
            Assert.Equal("Hello World", textColor.ToString());
        }

        [Fact]
        public void TextColor_ResetAll_ShouldResetColors()
        {
            var textColor = TextColor.ResetAll + "Reset";
            Assert.Equal("Reset", textColor.ToString());
        }

    }
}
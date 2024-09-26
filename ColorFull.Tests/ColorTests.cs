namespace ColorFull.Tests;

[TestClass]
public class ColorTests : Tester
{
    [TestMethod]
    [DataRow("")]
    [DataRow(" ")]
    [DataRow(null)]
    public void FromHtml_WhenHexIsEmpty_Throw(string hex)
    {
        //Arrange

        //Act
        var action = () => Color.FromHtml(hex);

        //Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [TestMethod]
    public void FromHtml_WhenHexIsValidHtmlColorCode_ReturnAsRgba()
    {
        //Arrange
        var hex = "#FA8072";

        //Act
        var result = Color.FromHtml(hex);

        //Assert
        result.Should().Be(new Color(250, 128, 114));
    }

    [TestMethod]
    public void FromHtml_WhenHexIsValidHtmlColorCodeButDoesNotStartWithHashTag_ReturnAsRgbaRegardless()
    {
        //Arrange
        var hex = "FA8072";

        //Act
        var result = Color.FromHtml(hex);

        //Assert
        result.Should().Be(new Color(250, 128, 114));
    }

    [TestMethod]
    public void FromHtml_WhenHexIsInvalidText_Throw()
    {
        //Arrange
        var hex = Dummy.Create<string>();

        //Act
        var action = () => Color.FromHtml(hex);

        //Assert
        action.Should().Throw<ArgumentException>();
    }

    [TestMethod]
    public void ToHtml_Always_ConvertToHex()
    {
        //Arrange
        var instance = new Color(250, 128, 114);

        //Act
        var result = instance.ToHtml();

        //Assert
        result.Should().Be("#FA8072");
    }

    [TestMethod]
    public void ExplicitOperatorToConsoleColor_WhenIsWhite_ReturnWhite()
    {
        //Arrange
        var instance = new Color(255, 255, 255);

        //Act
        var result = (ConsoleColor)instance;

        //Assert
        result.Should().Be(ConsoleColor.White);
    }

    [TestMethod]
    public void ExplicitOperatorToConsoleColor_WhenIsDarkBlue_ReturnDarkBlue()
    {
        //Arrange
        var instance = new Color(0, 22, 85);

        //Act
        var result = (ConsoleColor)instance;

        //Assert
        result.Should().Be(ConsoleColor.DarkBlue);
    }

    [TestMethod]
    public void ExplicitOperatorToConsoleColor_WhenIsDarkGreen_ReturnDarkGreen()
    {
        //Arrange
        var instance = new Color(0, 75, 12);

        //Act
        var result = (ConsoleColor)instance;

        //Assert
        result.Should().Be(ConsoleColor.DarkGreen);
    }

    [TestMethod]
    public void Ensure_ValueEquality() => Ensure.ValueEquality<Color>(Dummy);

    [TestMethod]
    public void Ensure_ValueHashCode() => Ensure.ValueHashCode<Color>(Dummy, JsonSerializerOptions);

    [TestMethod]
    public void Ensure_IsJsonSerializable() => Ensure.IsJsonSerializable<Color>(Dummy);

}
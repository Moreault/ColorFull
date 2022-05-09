using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ToolBX.ColorFull;
using ToolBX.Eloquentest;

namespace ColorFull.Tests;

[TestClass]
public class ColorTester
{
    [TestClass]
    public class FromHtml : Tester
    {
        [TestMethod]
        [DataRow("")]
        [DataRow(" ")]
        [DataRow(null)]
        public void WhenHexIsEmpty_Throw(string hex)
        {
            //Arrange

            //Act
            var action = () => Color.FromHtml(hex);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WhenHexIsValidHtmlColorCode_ReturnAsRgba()
        {
            //Arrange
            var hex = "#FA8072";

            //Act
            var result = Color.FromHtml(hex);

            //Assert
            result.Should().Be(new Color(250, 128, 114));
        }

        [TestMethod]
        public void WhenHexIsValidHtmlColorCodeButDoesNotStartWithHashTag_ReturnAsRgbaRegardless()
        {
            //Arrange
            var hex = "FA8072";

            //Act
            var result = Color.FromHtml(hex);

            //Assert
            result.Should().Be(new Color(250, 128, 114));
        }

        [TestMethod]
        public void WhenHexIsInvalidText_Throw()
        {
            //Arrange
            var hex = Fixture.Create<string>();

            //Act
            var action = () => Color.FromHtml(hex);

            //Assert
            action.Should().Throw<ArgumentException>();
        }
    }

    [TestClass]
    public class ToHtml : Tester
    {
        [TestMethod]
        public void Always_ConvertToHex()
        {
            //Arrange
            var instance = new Color(250, 128, 114);

            //Act
            var result = instance.ToHtml();

            //Assert
            result.Should().Be("#FA8072");
        }
    }

    [TestClass]
    public class ExplicitOperator_ToConsoleColor : Tester
    {
        [TestMethod]
        public void WhenIsWhite_ReturnWhite()
        {
            //Arrange
            var instance = new Color(255, 255, 255);

            //Act
            var result = (ConsoleColor)instance;

            //Assert
            result.Should().Be(ConsoleColor.White);
        }

        [TestMethod]
        public void WhenIsDarkBlue_ReturnDarkBlue()
        {
            //Arrange
            var instance = new Color(0, 22, 85);

            //Act
            var result = (ConsoleColor)instance;

            //Assert
            result.Should().Be(ConsoleColor.DarkBlue);
        }

        [TestMethod]
        public void WhenIsDarkGreen_ReturnDarkGreen()
        {
            //Arrange
            var instance = new Color(0, 75, 12);

            //Act
            var result = (ConsoleColor)instance;

            //Assert
            result.Should().Be(ConsoleColor.DarkGreen);
        }
    }
}
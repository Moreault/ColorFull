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
            var hex = instance.ToHtml();

            //Assert
            hex.Should().Be("#FA8072");
        }
    }
}
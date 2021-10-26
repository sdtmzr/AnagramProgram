using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnagramLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnagramLibraryTests
{
    [TestClass()]
    public class AnagramTest
    {
        IAnagram anagram = new Anagram();
        [TestMethod()]
        public void TaskExample1()
        {
            // Arrange
            string input = "abcd efgh";
            string expected = "dcba hgfe";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TaskExample2()
        {
            // Arrange
            string input = "Test";
            string expected = "tseT";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TaskExample3()
        {
            // Arrange
            string input = "a1bcd efg!h";
            string expected = "d1cba hgf!e";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TaskExample4()
        {
            // Arrange
            string input = "  a1bcd    efg!h";
            string expected = "  d1cba    hgf!e";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void OnlyAlphabethicSymbols()
        {
            // Arrange
            string input = "ОндатраOndatra";
            string expected = "artadnOартаднО";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void OnlyNonAlphabethicSymbols()
        {
            // Arrange
            string input = "880№;05:?*55:!3535";
            string expected = "880№;05:?*55:!3535";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AlphabethicSymbolsWithWhitespases()
        {
            // Arrange
            string input = " Онд атра \t JhoNa th\n  an";
            string expected = " днО арта \t aNohJ ht\n  na";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void NonAlphabethicSymbolsWithWhitespases()
        {
            // Arrange
            string input = "327№; ; %:\n   (: !\t\t  &'^";
            string expected = "327№; ; %:\n   (: !\t\t  &'^";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AllSymbolsMixed()
        {
            // Arrange
            string input = "ОнDa^ 7th$#\n ragdG^&h \t  42  689";
            string expected = "aDнО^ 7ht$#\n hGdga^&r \t  42  689";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void Sentence()
        {
            // Arrange
            string input = "This is test sentence number 1.";
            string expected = "sihT si tset ecnetnes rebmun 1.";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod()]
        [DataRow(" ", " ")]
        [DataRow("\t\t\t", "\t\t\t")]
        [DataRow("\n\t", "\n\t")]
        [DataRow(null, "")]
        public void EmptyOrNull(string input, string expected)
        {
            // Arrange
            // Act
            string result = anagram.CreateAnagram(input);
            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod()]
        public void OneLetterInWord()
        {
            // Arrange
            string input = "123a1234 a12345 1231323b";
            string expected = "123a1234 a12345 1231323b";
            // Act
            string result = anagram.CreateAnagram(input);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
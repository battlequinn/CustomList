using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomList;

namespace TestCustomList
{
    [TestClass]
    public class TestCustomList
    {
        [TestMethod]
        public void Test_Add_Length()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            //Act
            list.Add(1);
            int result = list.items.Length;
            //Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Test_Add_PositiveIntegerValue()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            int input = 5;
            //Act
            list.Add(input);
            int result = list.items[0];
            //Assert
            Assert.AreEqual(input, result);
        }
        [TestMethod]
        public void Test_Add_MultipleStringsLength()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>();
            string inputOne = "blue";
            string inputTwo = "red";
            string inputThree = "yellow";
            //Act
            list.Add(inputOne);
            list.Add(inputTwo);
            list.Add(inputThree);
            int result = list.size;
            //Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Test_Add_MultipleStringsValue()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>();
            string inputOne = "blue";
            string inputTwo = "red";
            string inputThree = "yellow";
            //Act
            list.Add(inputOne);
            list.Add(inputTwo);
            list.Add(inputThree);
            string result = list.items[1];
            //Assert
            Assert.AreEqual(inputTwo, result);
        }
        [TestMethod]
        public void Test_Add_NegativeIntagerToFilledList()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>(3) { 5, -4, 3 };
            int input = -7;
            //Act
            list.Add(input);
            int result = list.items[3];
            //Assert
            Assert.AreEqual(input, result);
        }
        [TestMethod]
        public void Test_Remove_IntOfListSizeThree_Length()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>() { 5, 7, -3};
            //Act
            list.Remove(5);
            //Assert
            Assert.AreEqual(list.items.Length, 2);
        }
        [TestMethod]
        public void Test_Remove_stringOfListSizeFour_Value()
        {
            //Arrange
            string inputOne = "blue";
            string inputTwo = "red";
            string inputThree = "yellow";
            string inputFour = "green";
            CustomList<string> list = new CustomList<string>() {inputOne, inputTwo, inputThree, inputFour};
            //Act
            list.Remove(inputTwo);
            //Assert
            Assert.AreEqual(list.items[1], inputThree);
        }
        [TestMethod]
        public void Test_MakeIterable()
        {
            //Arrange
            CustomList<string> paper = new CustomList<string>() { "black", "white" };
            string paperColors = "";
            string expected = "black white ";
            //Act
            foreach(string color in paper)
            {
                paperColors += (color + " ");
            }
            //Assert
            Assert.AreEqual(paperColors, expected);
        }
        [TestMethod]
        public void Test_ToString_Int()
        {
            //Arrange
            CustomList<int> number = new CustomList<int>() {1, 2, 3 };
            string result;
            //Act
            result = number.ToString();
            //Assert
            Assert.AreEqual("1, 2, 3", result);
        }
        [TestMethod]
        public void Test_ToString_String()
        {
            //Arrange
            CustomList<string> number = new CustomList<string>() { "beep", "boop", "bop" };
            string result;
            //Act
            result = number.ToString();
            //Assert
            Assert.AreEqual("beep, boop, bop", result);
        }
        [TestMethod]
        public void Test_ToString_Boolean()
        {
            //Arrange
            CustomList<bool> number = new CustomList<bool>() { true, false };
            string result;
            //Act
            result = number.ToString();
            //Assert
            Assert.AreEqual("True, False", result);
        }
    }
}
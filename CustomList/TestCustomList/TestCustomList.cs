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
            int result = list[0];
            //Assert
            Assert.AreEqual(input, result);
        }
        [TestMethod]
        public void Test_Add_MultipleStringsLength()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>();
            //Act
            list.Add("blue");
            list.Add("red");
            list.Add("yellow");
            int result = list.Count;
            //Assert
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void Test_Add_MultipleStringsValue()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>();
            //Act
            list.Add("blue");
            list.Add("red");
            list.Add("yellow");
            string result = list.items[1];
            //Assert
            Assert.AreEqual("red", result);
        }
        [TestMethod]
        public void Test_Add_NegativeIntagerToFilledList()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>(3) { 5, -4, 3 };
            //Act
            list.Add(-7);
            int result = list.items[3];
            //Assert
            Assert.AreEqual(-7, result);
        }
        [TestMethod]
        public void Test_Remove_IntOfListSizeThree_Length()
        {
            //Arrange
            CustomList<int> list = new CustomList<int>(3) { 5, 7, -3 };
            //Act
            list.Remove(5);
            //Assert
            Assert.AreEqual(list.items.Length, 2);
        }
        [TestMethod]
        public void Test_Remove_StringOfListSizeFour_Value()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>(4) { "blue", "red", "yellow", "green" };
            //Act
            list.Remove("red");
            //Assert
            Assert.AreEqual(list[1], "yellow");
        }
        [TestMethod]
        public void Test_Remove_StringNoExist()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>(4) { "blue", "red", "yellow", "green" };
            //Act
            list.Remove("black");
            //Assert
            Assert.AreEqual(list[3], "green");
        }
        [TestMethod]
        public void Test_MakeIterable()
        {
            //Arrange
            CustomList<string> paper = new CustomList<string>(2) { "black", "white" };
            string paperColors = "";
            string expected = "black white ";
            //Act
            foreach (string color in paper)
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
            CustomList<int> number = new CustomList<int>(3) { 1, 2, 3 };
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
            CustomList<string> number = new CustomList<string>(3) { "beep", "boop", "bop" };
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
            CustomList<bool> number = new CustomList<bool>(2) { true, false };
            string result;
            //Act
            result = number.ToString();
            //Assert
            Assert.AreEqual("True, False", result);
        }
        [TestMethod]
        public void Test_PlusOperator_Int()
        {
            //Arrange
            CustomList<int> listOne = new CustomList<int>(2) { 1, 2 };
            CustomList<int> listTwo = new CustomList<int>(2) { 3, 4 };
            string expected = "1, 2, 3, 4";
            //Act
            CustomList<int> actualList = listOne + listTwo;
            string actual = actualList.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_PlusOperator_String()
        {
            //Arrange
            CustomList<string> listOne = new CustomList<string>(2) { "hi", "hello" };
            CustomList<string> listTwo = new CustomList<string>(2) { "bye", "goodbye" };
            string expected = "hi, hello, bye, goodbye";
            //Act
            CustomList<string> actualList = listOne + listTwo;
            string actual = actualList.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_SubtractOperator_Int()
        {
            //Arrange
            CustomList<int> listOne = new CustomList<int>(4) { 1, 2, 3, 4 };
            CustomList<int> listTwo = new CustomList<int>(2) { 3, 4 };
            string expected = "1, 2";
            //Act
            CustomList<int> actualList = listOne - listTwo;
            string actual = actualList.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_SubtractOperator_IntListTwoMinusLIstOne()
        {
            //Arrange
            CustomList<int> listOne = new CustomList<int>(4) { 1, 2, 3, 4 };
            CustomList<int> listTwo = new CustomList<int>(2) { 3, 4 };
            string expected = "";
            //Act
            CustomList<int> actualList = listTwo - listOne;
            string actual = actualList.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_SubtractOperator_String()
        {
            //Arrange
            CustomList<string> listOne = new CustomList<string>(4) { "hi", "hello", "bye", "goodbye" };
            CustomList<string> listTwo = new CustomList<string>(2) { "hi", "hello" };
            string expected = "bye, goodbye";
            //Act
            CustomList<string> actualList = listOne - listTwo;
            string actual = actualList.ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Count()
        {
            //Arrange
            CustomList<string> list = new CustomList<string>(4) { "hi", "hello", "bye", "goodbye" };
            //Act
            //Assert
            Assert.AreEqual(4, list.Count);
        }
        [TestMethod]
        public void Test_Zip_IntoNewList()
        {
            //Arrange
            CustomList<string> numbers = new CustomList<string>(3) { "1", "2", "3" };
            CustomList<string> words = new CustomList<string>(4) { "one", "two", "three", "four" };
            string expected = "1, one, 2, two, 3, three";
            //Act
            CustomList<string> numbersAndWords = numbers.Zip(words);
            string result = numbersAndWords.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Test_Zip_OverwriteOldList()
        {
            //Arrange
            CustomList<string> numbers = new CustomList<string>(3) { "1", "2", "3" };
            CustomList<string> words = new CustomList<string>(4) { "one", "two", "three", "four" };
            string expected = "1, one, 2, two, 3, three";
            //Act
            numbers = numbers.Zip(words);
            string result = numbers.ToString();
            //Assert
            Assert.AreEqual(expected, result);
        }
        //[TestMethod]
        //public void Test_Sort()
        //{
        //    //Arrange
        //    CustomList<int> numbers = new CustomList<int>(5) { 3, 1, 2, 4, 0 };
        //    string expected = "0, 1, 2, 3, 4";
        //    //Act
        //    string result = numbers.Sort().ToString();
        //    //Assert
        //    Assert.AreEqual(expected, result);
        //}
    }
}
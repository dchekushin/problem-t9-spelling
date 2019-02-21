using NUnit.Framework;

namespace ProblemT9Spelling.Tests
{
    [TestFixture]
    public class MessageToKeyTranslatorTests
    {
        [Test]
        [TestCase("hi", "44 444")]
        [TestCase("yes", "999337777")]
        [TestCase("foo  bar", "333666 6660 022 2777")]
        [TestCase("hello world", "4433555 555666096667775553")]
        [TestCase("no", "66 666")]
        [TestCase("aaaaaaaaa", "2 2 2 2 2 2 2 2 2")]
        public void Test_Translate(string input, string output)
        {
            // arrange
            
            // act
            var result = MessageToKeyTranslator.Translate(input);
            
            // assert
            Assert.AreEqual(output, result);
        }
        
        private static object[] DataSet()
        {
            return new object[]
            {
                new object[] { SmallDataSet.In, SmallDataSet.Out }, 
                new object[] { LargeDataSet.In, LargeDataSet.Out }
            };
        }
        
        [Test]
        [TestCaseSource(nameof(DataSet))]
        public void Test_TranslateDataSet(string input, string output)
        {
            // arrange
            
            // act
            var result = MessageToKeyTranslator.TranslateDateSet(input);
            
            // assert
            Assert.AreEqual(output, result);
        }
    }
}
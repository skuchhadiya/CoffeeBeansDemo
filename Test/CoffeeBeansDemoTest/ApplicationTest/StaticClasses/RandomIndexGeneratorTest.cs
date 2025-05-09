using CoffeeBeansDemo.Application.StaticClasses;
using Moq;

namespace CoffeeBeansDemoTest.ApplicationTest.StaticClasses
{
    [TestClass]
    public sealed class RandomIndexGeneratorTest
    {
        [TestMethod]
        public void Should_set_random_number_and_return_true()
        {
            int minIndex = 0;
            int maxIndex = 10 + 1;
            int currentIndex = 3;
            int []values = [ 0, 1, 2, 4, 5, 6, 7, 8, 9, 10 ];
            Random random = new();
            var result = RandomIndexGenerator.TryGetRandomIndex(random, minIndex, maxIndex,currentIndex,values, out int? randomNumber);
            Assert.IsTrue(result);
            Assert.IsNotNull(randomNumber);
            Assert.IsFalse(currentIndex == randomNumber);
        }

        //This is usefull test when someone delete records from table and indexes got out off sync
        [TestMethod]
        public void Should_set_random_number_to_null_and_return_false()
        {
            Mock<Random> random = new Mock<Random>();
            random.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(7);

            int minIndex = 0;
            int maxIndex = 10+1;
            int currentIndex = 3;
            int[] values = [0, 1, 2, 4, 5, 6, 8, 9, 10];
            var result = RandomIndexGenerator.TryGetRandomIndex(random.Object, minIndex, maxIndex, currentIndex, values, out int? randomNumber);
            Assert.IsFalse(result);
            Assert.IsNull(randomNumber);
            Assert.IsFalse(currentIndex == randomNumber);
        }

        [TestMethod]
        public void Should_set_random_number_when_random_next_return_currantIndex_return_true_Scenario1()
        {
            Mock<Random> random = new Mock<Random>();
            random.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(0);

            int minIndex = 0;
            int maxIndex = 10 + 1;
            int currentIndex = 0;
            int[] values = [1,2,3,4, 5, 6,7,8, 9, 10];
            var result = RandomIndexGenerator.TryGetRandomIndex(random.Object, minIndex, maxIndex, currentIndex, values, out int? randomNumber);
            Assert.IsTrue(result);
            Assert.IsNotNull(randomNumber);
            Assert.IsTrue(1 == randomNumber);
        }

        [TestMethod]
        public void Should_set_random_number_when_random_next_return_currantIndex_return_true_Scenario2()
        {
            Mock<Random> random = new Mock<Random>();
            random.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(10);

            int minIndex = 0;
            int maxIndex = 10 + 1;
            int currentIndex = 10;
            int[] values = [0, 1,2,3, 4, 5, 6, 7, 8, 9];
            var result = RandomIndexGenerator.TryGetRandomIndex(random.Object, minIndex, maxIndex, currentIndex, values, out int? randomNumber);
            Assert.IsTrue(result);
            Assert.IsNotNull(randomNumber);
            Assert.IsTrue(9 == randomNumber);
        }

        [TestMethod]
        public void Should_set_random_number_when_random_next_return_currantIndex_return_true_Scenario3()
        {
            Mock<Random> random = new Mock<Random>();
            random.Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(3);

            int minIndex = 0;
            int maxIndex = 10 + 1;
            int currentIndex = 3;
            int[] values = [0, 1, 2, 4, 5, 6, 7, 8, 9, 10];
            var result = RandomIndexGenerator.TryGetRandomIndex(random.Object, minIndex, maxIndex, currentIndex, values, out int? randomNumber);
            Assert.IsTrue(result);
            Assert.IsNotNull(randomNumber);
            Assert.IsTrue(4 == randomNumber);
        }
    }
}

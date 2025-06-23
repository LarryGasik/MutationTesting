using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MutationTesting.Tests
{
    [TestClass]
    public class SomeBusinessClassTests
    {
        private SomeBusinessClass _sut;
        private Mock<ISomeInterface> _someInterfaceMock;

        [TestInitialize]
        public void Initialize()
        {
            _someInterfaceMock = new Mock<ISomeInterface>();
            _someInterfaceMock.Setup(x => x.SomeCallAsync(It.IsAny<string>()))
                .Returns(Task.CompletedTask);
            _someInterfaceMock.Setup(x => x.SomeCallAsync("error")).Throws<InvalidDataException>();
            _sut = new SomeBusinessClass(_someInterfaceMock.Object);
        }

        [TestMethod]
        public void SomeMethod_DumbUnitTest()
        {
            Assert.AreNotEqual(0, _sut.SomeMethod(2, 3));
        }

        [TestMethod]
        public async Task SomeOtherMethod_TransformsToUpperAndCallsInterface()
        {
            string input = "test";
            string result = await _sut.SomeOtherMethod(input);
            Assert.AreEqual("TEST", result);
        }
    }
}

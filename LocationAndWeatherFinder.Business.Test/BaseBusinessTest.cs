using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;

namespace LocationAndWeatherFinder.Business.Tests
{
    public class BaseBusinessTest
    {
        public IFixture Fixture;
        public MockRepository Repository;

        [SetUp]
        public void SetupResources()
        {
            Fixture = new Fixture().Customize(new AutoMoqCustomization());
            Repository = new MockRepository(MockBehavior.Strict);
        }
    }
}

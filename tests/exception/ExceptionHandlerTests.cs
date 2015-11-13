using Moq;
using System;
using Classes;
using Interfaces;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Xunit;

public class ExceptionHandlerTests
{
    private IFixture Fixture;

    public ExceptionHandlerTests()
    {
        Fixture = new Fixture().Customize(new AutoMoqCustomization());
    }

    [Fact]
    public void WhenAnExceptionOccurs_TheLogErrorMethodIsCalled()
    {
        // Arrange
        var mockILog = Fixture.Freeze<Mock<ILog>>();
        var sut = Fixture.Create<ExceptionHandler>();
        var app = new TestApp();

        // Act
        sut.SetupExceptionHandling();
        Assert.Throws<NotImplementedException>(() => app.Run());

        // Assert
        mockILog.Verify(x => x.Error(It.IsAny<string>()), Times.AtLeastOnce);
    }

    class TestApp : IApp
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}

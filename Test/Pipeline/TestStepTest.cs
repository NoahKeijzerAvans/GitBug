using DomainServices.Context.PipelineContext;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using Moq;

public sealed class TestStepTest
{
    private Mock<Pipeline> _pipeline;
    private Mock<TestStep> _testStep;
    public TestStepTest()
    {
        _pipeline = new Mock<Pipeline>();
        _testStep = new Mock<TestStep>();
    }
    [Fact]
    public void Should_Excecute_Step_When_Update_Is_Called_When_Subscribed()
    {
        _pipeline.Object.Subscribe(_testStep.Object);
        _pipeline.Object.Update(null);
        Assert.True(_testStep.Object.IsSucceeded);
    }
    [Fact]
    public void Should_Not_Excecute_Step_When_Update_Is_Called_If_Not_Subscribed()
    {
        _pipeline.Object.Update(null);
        Assert.False(_testStep.Object.IsSucceeded);
    }
}
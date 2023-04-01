using DomainServices.Context.PipelineContext;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using Moq;

public sealed class ReleaseStepTest
{
    private Mock<Pipeline> _pipeline;
    private Mock<DeployStep> _deployStep;
    public ReleaseStepTest()
    {
        _pipeline = new Mock<Pipeline>();
        _deployStep = new Mock<DeployStep>();
    }
    [Fact]
    public void Should_Excecute_Step_When_Update_Is_Called_When_Subscribed()
    {
        _pipeline.Object.Subscribe(_deployStep.Object);
        _pipeline.Object.Update(null);
        Assert.True(_deployStep.Object.IsSucceeded);
    }
    [Fact]
    public void Should_Not_Excecute_Step_When_Update_Is_Called_If_Not_Subscribed()
    {
        _pipeline.Object.Update(null);
        Assert.False(_deployStep.Object.IsSucceeded);
    }
}
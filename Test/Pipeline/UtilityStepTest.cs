using DomainServices.Context.PipelineContext;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using Moq;

public sealed class UtilityStepTest
{
    private Mock<Pipeline> _pipeline;
    private Mock<UtilityStep> _utilityStep;
    public UtilityStepTest()
    {
        _pipeline = new Mock<Pipeline>();
        _utilityStep = new Mock<UtilityStep>();
    }
    [Fact]
    public void Should_Excecute_Step_When_Update_Is_Called_When_Subscribed()
    {
        _pipeline.Object.Subscribe(_utilityStep.Object);
        _pipeline.Object.Update(null);
        Assert.True(_utilityStep.Object.IsSucceeded);
    }
    [Fact]
    public void Should_Not_Excecute_Step_When_Update_Is_Called_If_Not_Subscribed()
    {
        _pipeline.Object.Update(null);
        Assert.False(_utilityStep.Object.IsSucceeded);
    }
}
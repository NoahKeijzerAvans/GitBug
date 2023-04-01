using DomainServices.Context.PipelineContext;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using Moq;

public sealed class AnalyseStepTest
{
    private Mock<Pipeline> _pipeline;
    private Mock<AnalyseStep> _analyseStep;
    public AnalyseStepTest()
    {
        _pipeline = new Mock<Pipeline>();
        _analyseStep = new Mock<AnalyseStep>();
    }
    [Fact]
    public void Should_Excecute_Step_When_Update_Is_Called_When_Subscribed()
    {
        _pipeline.Object.Subscribe(_analyseStep.Object);
        _pipeline.Object.Update(null);
        Assert.True(_analyseStep.Object.IsSucceeded);
    }
    [Fact]
    public void Should_Not_Excecute_Step_When_Update_Is_Called_If_Not_Subscribed()
    {
        _pipeline.Object.Update(null);
        Assert.False(_analyseStep.Object.IsSucceeded);
    }
}
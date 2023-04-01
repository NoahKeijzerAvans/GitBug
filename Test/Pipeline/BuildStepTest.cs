using DomainServices.Context.PipelineContext;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using Moq;

public sealed class BuildStepTest
{
    private Mock<Pipeline> _pipeline;
    private Mock<BuildStep> _buildStep;
    public BuildStepTest()
    {
        _pipeline = new Mock<Pipeline>();
        _buildStep = new Mock<BuildStep>();
    }
    [Fact]
    public void Should_Excecute_Step_When_Update_Is_Called_When_Subscribed()
    {
        _pipeline.Object.Subscribe(_buildStep.Object);
        _pipeline.Object.Update(null);
        Assert.True(_buildStep.Object.IsSucceeded);
    }
    [Fact]
    public void Should_Not_Excecute_Step_When_Update_Is_Called_If_Not_Subscribed()
    {
        _pipeline.Object.Update(null);
        Assert.False(_buildStep.Object.IsSucceeded);
    }
}
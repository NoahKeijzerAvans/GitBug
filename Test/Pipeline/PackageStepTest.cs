using DomainServices.Context.PipelineContext;
using DomainServices.Pipeline;
using DomainServices.Pipeline.Steps;
using Moq;

public sealed class PackageStepTest
{
    private Mock<Pipeline> _pipeline;
    private Mock<PackageStep> _packageStep;
    public PackageStepTest()
    {
        _pipeline = new Mock<Pipeline>();
        _packageStep = new Mock<PackageStep>();
    }
    [Fact]
    public void Should_Excecute_Step_When_Update_Is_Called_When_Subscribed()
    {
        _pipeline.Object.Subscribe(_packageStep.Object);
        _pipeline.Object.Update(null);
        Assert.True(_packageStep.Object.IsSucceeded);
    }
    [Fact]
    public void Should_Not_Excecute_Step_When_Update_Is_Called_If_Not_Subscribed()
    {
        _pipeline.Object.Update(null);
        Assert.False(_packageStep.Object.IsSucceeded);
    }
}
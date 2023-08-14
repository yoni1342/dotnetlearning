namespace AddisBlog.Architecture.Tests;
using AddisBlog.Domain;
using Xunit;

public class ArchitectureTests
{
    private const string DomainNameSpace = "Domain";
    private const string ApplicationNameSpace = "Application";
    private const string InfrastructureNameSpace = "Infrastructure";
    private const string PersistenceNameSpace = "Persistence";
    private const string WebNameSpace = "Web";

    [Fact]
    public void Domain_Should_Not_HaveDependenctOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(AddisBlog.Domain).Assembly;
    }
}
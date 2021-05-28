using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "HrModule",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "HrModule",
    Category = "Content Management",
    Dependencies = new[] { "OrchardCore.ContentFields" }
)]

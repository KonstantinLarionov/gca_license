using LicenseServiceGCA.Infrastructure.Database.Contexts;
using shortid;
using shortid.Configuration;

var token = ShortId.Generate(new GenerationOptions(length: 20));
Console.ReadKey();
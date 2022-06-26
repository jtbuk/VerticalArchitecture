using NJsonSchema.Generation;

namespace Jtbuk.VerticalArchitecture.Common.Swagger;

public static class SwaggerSetup
{
    private class NSwagNameGenerator : DefaultSchemaNameGenerator, ISchemaNameGenerator
    {
        public override string Generate(Type type)
        {
            return type!.FullName!.Replace("Dto", "");
        }
    }

    public static void AddSwagger(this WebApplicationBuilder builder)
    {

        builder.Services.AddOpenApiDocument(o =>
        {
            o.Title = "Vertical Architecture";
            o.Version = "v1";
            o.GenerateExamples = true;
            o.SchemaNameGenerator = new NSwagNameGenerator();
        });
    }


    public static void UseSwagger(this WebApplication app)
    {        

        app.UseOpenApi();

        app.UseSwaggerUi3(o =>
        {
            o.DocExpansion = "list";
            o.ValidateSpecification = true;
            o.CustomStylesheetPath = "/swagger/swagger.css";
        });
    }
}

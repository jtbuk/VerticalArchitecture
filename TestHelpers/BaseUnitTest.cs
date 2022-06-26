namespace Jtbuk.VerticalArchitecture.TestHelpers;

[Trait("Category", "Unit")]
public class BaseUnitTest
{
    public static string Random()
    {
        return Guid.NewGuid().ToString();
    }

    public static string Email()
    {
        return $"{Random().Replace("-", "")}@jtbuk.com";
    }
}

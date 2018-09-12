public class HashCodeGenerator
{
    public static Guid GetGuid(string value)
    {
        var random = new Random(value.GetHashCode());
        var hex = "";
		
        while (hex.Length < 32)
        {
            hex += random.Next().ToString("x");
        }
		
        return new Guid(hex.Substring(0, 32).Insert(20, "-").Insert(16, "-").Insert(12, "-").Insert(8, "-"));
    }	
}

[TestClass]
public class DeepObjectComparerTests
{
    [TestMethod]
    public void AreIdentical_ObjectsWithSameValues_ReturnsTrue()
    {
        var a = new A
        {
            Number = 123,
            Value = "test",
            Regex = new Regex(@"\d{3}"),
            Prices = new[] { 1.5, 6.88 },
            List = new List<string>
            {
                "one",
                "two",
                null,
            },
            Regexes = new[] { new Regex(@"\D"), new Regex(@"\w") },
        };
        
        var b = new A
        {
            Number = 123,
            Value = "test",
            Regex = new Regex(@"\d{3}"),
            Prices = new[] { 1.5, 6.88 },
            List = new List<string> 
            { 
                "one", 
                "two", 
                null,
            },
            Regexes = new[] { new Regex(@"\D"), new Regex(@"\w") },
        };
        
        var comparer = new DeepObjectComparer();
        
        var identical = comparer.AreIdentical(a, b);
        
        Assert.IsTrue(identical);
    }
    
    class A
    {
        public int Number { get; set; }
        public string Value { get; set; }
        public Regex Regex { get; set; }
        public double[] Prices { get; set; }
        public List<string> List { get; set; }
        public Regex[] Regexes { get; set; }
    }
}

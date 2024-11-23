public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    public Random _random = new Random();

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son..."),
            new Scripture(new Reference("Proverbs", 3, 5), "Trust in the Lord with all thine heart; and lean not unto thine own understanding."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want."),
            new Scripture(new Reference("Mosiah", 2, 17), "When ye are in the service of your fellow beings ye are only in the service of your God."),
            new Scripture(new Reference("Ether", 12, 27), "And if men come unto me I will show unto them their weakness."),
        };
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
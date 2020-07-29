namespace DirectSupply.Anonymize.Service.Constants
{
    public class ClassifierPatterns
    {
        public const string NamePattern = @"<PERSON>(.*)</PERSON>";
        public const string NameTagPattern = @"</?PERSON>";
    }
}

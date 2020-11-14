namespace Domain.Aggregates.User.ValueObjects
{
    public class Photo
    {
        public Photo(string url, bool isMain)
        {
            Url = url;
            IsMain = isMain;
        }

        public string Url { get; private set; }

        public bool IsMain { get; private set; }
    }
}

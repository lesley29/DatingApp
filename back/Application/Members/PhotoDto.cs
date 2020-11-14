namespace Application.Members
{
    public class PhotoDto
    {
        public PhotoDto(string url, bool isMain)
        {
            Url = url;
            IsMain = isMain;
        }

        public string Url { get; private set; }

        public bool IsMain { get; private set; }
    }
}

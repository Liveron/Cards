namespace MAUI.CardsClient.Utils.Extensions
{
    public static class FileStreamExtensions
    {
        const int STREAM_START_POSITION = 0; 
        public static void Normalize(this FileStream fileStream)
        {
            fileStream.Flush();
            fileStream.Position = STREAM_START_POSITION;
        }

        public static async Task NormalizeAsync(this FileStream fileStream)
        {
            await fileStream.FlushAsync();
            fileStream.Position = STREAM_START_POSITION;
        }
    }
}

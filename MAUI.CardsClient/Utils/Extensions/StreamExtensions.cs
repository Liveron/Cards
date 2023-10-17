namespace MAUI.CardsClient.Utils.Extensions
{
    public static class StreamExtensions
    {
        const int STREAM_START_POSITION = 0;
        public static void Normalize(this Stream stream)
        {
            stream.Flush();
            stream.Position = STREAM_START_POSITION;
        }

        public static async Task NormalizeAsync(this Stream stream)
        {
            await stream.FlushAsync();
            stream.Position = STREAM_START_POSITION;
        }
    }
}

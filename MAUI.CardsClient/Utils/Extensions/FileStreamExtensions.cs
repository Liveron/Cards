namespace MAUI.CardsClient.Utils.Extensions
{
    public static class FileStreamExtensions
    {
        public static void Normalize(this FileStream fileStream)
        {
            fileStream.Flush();
            fileStream.Position = 0;
        }

        public static async Task NormalizeAsync(this FileStream fileStream)
        {
            await fileStream.FlushAsync();
            fileStream.Position = 0;
        }
    }
}

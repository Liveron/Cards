using System.Text.Json;

namespace MAUI.CardsClient.Utils
{
    public static class JsonSerializerHelper
    {
        public static T? TryDeserialize<T>
            (Stream stream)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(stream);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static async Task<T?> TryDeserializeAsync<T>
            (Stream stream)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<T>(stream);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static bool TrySerialize<T>
            (Stream stream, T entity)
        {
            try
            {
                JsonSerializer.Serialize(stream, entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<bool> TrySerializeAsync<T>
            (Stream stream, T entity)
        {
            try
            {
                await JsonSerializer.SerializeAsync(stream, entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

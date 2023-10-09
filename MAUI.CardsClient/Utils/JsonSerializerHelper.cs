using MAUI.CardsClient.Utils.Extensions;
using System.Text.Json;

namespace MAUI.CardsClient.Utils
{
    public static class JsonSerializerHelper
    {
        public static T TryDeserialize<T>
            (Stream stream)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(stream);
            }
            catch (Exception ex)
            {
                return default;
            }
            finally
            {
                if (stream is FileStream fileStream)
                    fileStream.Normalize();
            }
        }

        public static async Task<T> TryDeserializeAsync<T>
            (Stream stream)
        {
            try
            {
                return await JsonSerializer.DeserializeAsync<T>(stream);
            }
            catch (Exception ex)
            {
                return default;
            }
            finally
            {
                if (stream is FileStream fileStream)
                    await fileStream.NormalizeAsync();
            }
        }

        public static void TrySerialize<T>
            (Stream stream, T entity)
        {
            try
            {
                JsonSerializer.Serialize(stream, entity);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (stream is FileStream fileStream)
                    fileStream.Normalize();
            }
        }

        public static async Task TrySerializeAsync<T>
            (Stream stream, T entity)
        {
            try
            {
                await JsonSerializer.SerializeAsync(stream, entity);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (stream is FileStream fileStream)
                    await fileStream.NormalizeAsync();
            }
        }
    }
}

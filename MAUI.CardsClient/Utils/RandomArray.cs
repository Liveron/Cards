namespace MAUI.CardsClient.Utils
{
    public class RandomArray<T>
    {
        const int MINIMAL_ARRAY_LENGTH = 2;

        T[] _array = Array.Empty<T>();

        int _lastTakenElementIndex = 0;

        Random _random = new();

        public RandomArray(T[] array)
        {
            _array = array;
        }

        public T? GetRandomElement()
        {
            if (_array != Array.Empty<T>() ||
                _array.Length < MINIMAL_ARRAY_LENGTH)
            {
                int randomElementIndex = _random.Next(_array.Length);

                T[] arrayWithoutLastTakenEl = 
                    _array.Where(el => !el.Equals(_array[_lastTakenElementIndex])).ToArray<T>();

                _lastTakenElementIndex = randomElementIndex;

                return arrayWithoutLastTakenEl[randomElementIndex];
            }

            return default;
        }
    }
}

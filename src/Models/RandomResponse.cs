using System;
namespace Thinktecture.MiniAPI.Models
{
    public class RandomResponse<T>
    {
        public RandomResponse(T result)
        {
            Result = result;
        }

        public T Result { get; }
    }
}

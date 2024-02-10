

namespace shopping.Infrastructure.Exceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(string message) : base(message)
        {
            GuardarLog(message);
        }
        void GuardarLog(string message) 
        {
            // X logica para almacenar el error //
        }
    }
}

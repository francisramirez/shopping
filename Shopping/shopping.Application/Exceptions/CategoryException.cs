

namespace shopping.Application.Exceptions
{
    public class CategoryServiceException : Exception
    {
        public CategoryServiceException(string message) : base(message)
        {
            //Grabar y enviar el mensaje de error.
        }
    }
}

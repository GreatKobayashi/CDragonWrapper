namespace CDragonWrapper.Exceptions
{
    public class CDragonException : Exception
    {
        internal CDragonException(string errorCause) : base(errorCause)
        {
        }

        internal CDragonException(string errorCause, Exception innerException) : base(errorCause, innerException)
        {
        }

        internal CDragonException() { }
    }
}

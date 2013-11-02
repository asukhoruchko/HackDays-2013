using System;

namespace Umbrella.BL.Exceptions
{
    public sealed class InvalidUserException : Exception
    {
        public InvalidUserException() 
            : base("Некорректное имя пользователя или пароль")
        {
        }
    }
}

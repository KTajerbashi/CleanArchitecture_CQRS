﻿namespace BaseSource.Core.Domain.Common.Exceptions;

public abstract class BaseException : Exception
{
    public string[] Parameters { get; set; }

    protected BaseException(string message) : base(message) { }
    protected BaseException(string message, Exception exception) : base(message, exception) { }
    protected BaseException(Exception exception) : base(exception.Message, exception) { }
    protected BaseException(string message, params string[] parameters) : base(message)
    {
        Parameters = parameters;
    }

    public override string ToString()
    {

        if (Parameters is null) return Message;
        if (Parameters?.Length < 1)
            return Message;


        string result = Message;

        for (int i = 0; i < Parameters.Length; i++)
        {
            string placeHolder = $"{{{i}}}";
            result = result.Replace(placeHolder, Parameters[i]);
        }

        return result;
    }
}

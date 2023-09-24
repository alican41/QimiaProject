using System;
using System.Runtime.Serialization;

namespace QimiaProject.DataAccess.Exceptions;
[Serializable]
public class EntityNotFoundException<T> : Exception
{
    private readonly int id;
    private readonly long parameterlong;

    public EntityNotFoundException()
    {
    }

    public EntityNotFoundException(int id)
    {
        this.id = id;
    }
    public EntityNotFoundException(long parameterlong)
    {
        this.parameterlong = parameterlong;
    }

    public EntityNotFoundException(string? message) : base(message)
    {
    }

    public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public int Id => id;
    public long ParameterLong => parameterlong;
}
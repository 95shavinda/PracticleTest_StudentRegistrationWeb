namespace SharedKernel;

public class Envelope<T>
{
    public T Result { get; }
    public IEnumerable<string>? Errors { get; }
    public DateTime TimeGenerated { get; }
    public bool Success { get; }

    protected internal Envelope(T result, IEnumerable<string>? errors, bool success = false)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.UtcNow;
        Success = success;
    }
}

public class Envelope : Envelope<string>
{
    protected Envelope(IEnumerable<string>? errorMessages, bool success = false) : base(default!, errorMessages, success) { }

    public static Envelope<T> Ok<T>(T result) => new(result, [], success: true);

    public static Envelope Ok() => new(null, success: true);

    public static Envelope Error(string errorMessage) => new([errorMessage]);
    public static Envelope Error(IEnumerable<string>? errorMessages) => new(errorMessages);
    public static Envelope<T?> Error<T>(string errorMessage) => new(default, [errorMessage]);
}

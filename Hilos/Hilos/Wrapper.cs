namespace Hilos;

public class RefWrapper<T> where T : struct
{
    private T _value;

    public RefWrapper(T initialValue)
    {
        _value = initialValue;
    }

    public T Value
    {
        get { return _value; }
        set { _value = value; }
    }

    // Operadores implícitos para facilitar el uso
    public static implicit operator T(RefWrapper<T> wrapper)
    {
        return wrapper._value;
    }

    public static implicit operator RefWrapper<T>(T value)
    {
        return new RefWrapper<T>(value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}

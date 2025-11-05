namespace ColegioApp.Utilities;
public static class Guard
{
    public static void AgainstNull(object? obj, string name)
    {
        if (obj is null) throw new ArgumentNullException(name);
    }
}

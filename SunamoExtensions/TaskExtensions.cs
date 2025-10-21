// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoExtensions;

public static class TaskExtensions
{
    #region For easy copy from TaskExtensionsSunamo.cs

    public static ConfiguredTaskAwaitable Conf(this Task t)
    {
        return t.ConfigureAwait(true);
    }

    public static ConfiguredTaskAwaitable<T> Conf<T>(this Task<T> t)
    {
        return t.ConfigureAwait(true);
    }

    public static void LogExceptions(this Task task)
    {
        task.ContinueWith(t =>
            {
                var aggException = t.Exception.Flatten();
                throw new Exception(Exceptions.TextOfExceptions(aggException));
            },
            TaskContinuationOptions.OnlyOnFaulted);
    }

    #endregion
}
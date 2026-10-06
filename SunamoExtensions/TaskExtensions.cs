namespace SunamoExtensions;

public static class TaskExtensions
{
    #region For easy copy from TaskExtensionsSunamo.cs

    public static ConfiguredTaskAwaitable Conf(this Task task)
    {
        return task.ConfigureAwait(true);
    }

    public static ConfiguredTaskAwaitable<T> Conf<T>(this Task<T> task)
    {
        return task.ConfigureAwait(true);
    }

    public static void LogExceptions(this Task task)
    {
        task.ContinueWith(completedTask =>
            {
                var aggregateException = completedTask.Exception!.Flatten();
                throw new Exception(Exceptions.TextOfExceptions(aggregateException));
            },
            TaskContinuationOptions.OnlyOnFaulted);
    }

    #endregion
}

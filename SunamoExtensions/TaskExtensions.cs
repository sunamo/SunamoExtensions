namespace SunamoExtensions;

/// <summary>
/// Represents the task extensions type.
/// </summary>
public static class TaskExtensions
{
    #region For easy copy from TaskExtensionsSunamo.cs

    /// <summary>
    /// Conf.
    /// </summary>
    /// <param name="task">The task.</param>
    /// <returns>The conf result.</returns>
    public static ConfiguredTaskAwaitable Conf(this Task task)
    {
        return task.ConfigureAwait(true);
    }

    /// <summary>
    /// Conf t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="task">The task.</param>
    /// <returns>The conf t result.</returns>
    public static ConfiguredTaskAwaitable<T> Conf<T>(this Task<T> task)
    {
        return task.ConfigureAwait(true);
    }

    /// <summary>
    /// Log exceptions.
    /// </summary>
    /// <param name="task">The task.</param>
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

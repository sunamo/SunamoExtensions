namespace SunamoExtensions;

/// <summary>
/// Extension methods for Task type
/// </summary>
public static class TaskExtensions
{
    #region For easy copy from TaskExtensionsSunamo.cs

    /// <summary>
    /// Configures an awaiter for this task with continueOnCapturedContext set to true
    /// </summary>
    /// <param name="task">Task to configure</param>
    /// <returns>Configured task awaitable</returns>
    public static ConfiguredTaskAwaitable Conf(this Task task)
    {
        return task.ConfigureAwait(true);
    }

    /// <summary>
    /// Configures an awaiter for this task with continueOnCapturedContext set to true
    /// </summary>
    /// <typeparam name="T">Type of the task result</typeparam>
    /// <param name="task">Task to configure</param>
    /// <returns>Configured task awaitable</returns>
    public static ConfiguredTaskAwaitable<T> Conf<T>(this Task<T> task)
    {
        return task.ConfigureAwait(true);
    }

    /// <summary>
    /// Logs exceptions that occur during task execution
    /// </summary>
    /// <param name="task">Task to monitor for exceptions</param>
    public static void LogExceptions(this Task task)
    {
        task.ContinueWith(completedTask =>
            {
                var aggException = completedTask.Exception!.Flatten();
                throw new Exception(Exceptions.TextOfExceptions(aggException));
            },
            TaskContinuationOptions.OnlyOnFaulted);
    }

    #endregion
}

namespace eTasks.Shared.Extensions
{
    public static class TaskExtensions
    {
        public static async Task<T> TimeoutAfter<T>(this Task<T> task, TimeSpan timeout)
        {
            using var cts = new CancellationTokenSource();
            var delayTask = Task.Delay(timeout, cts.Token);
            var completedTask = await Task.WhenAny(task, delayTask);
            if (completedTask == delayTask) throw new TimeoutException();
            cts.Cancel();
            return await task;
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Phone.Maps.Services;

namespace MvvmCross.HotTuna.Plugins.Geocoder.WindowsPhone
{
    public static class AsyncQueryExtension
    {
        // Props to http://compiledexperience.com/blog/posts/async-geocode-query/ for the generic version
        public static Task<T> ExecuteAsync<T>(this Query<T> query)
        {
            var taskSource = new TaskCompletionSource<T>();

            EventHandler<QueryCompletedEventArgs<T>> handler = null;

            handler = (s, e) =>
            {
                query.QueryCompleted -= handler;

                if (e.Cancelled)
                {
                    taskSource.SetCanceled();
                }
                else if (e.Error != null)
                {
                    taskSource.SetException(e.Error);
                }
                else
                {
                    taskSource.SetResult(e.Result);
                }
            };

            query.QueryCompleted += handler;
            query.QueryAsync();

            return taskSource.Task;
        }
    }
}

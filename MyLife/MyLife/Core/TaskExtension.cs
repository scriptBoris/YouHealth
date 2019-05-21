using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLife.Core
{
    public class TaskHelper
    {
        public static Task<TResult> FromResult<TResult>(TResult result)
        {
            var completionSource = new TaskCompletionSource<TResult>();
            completionSource.SetResult(result);
            return completionSource.Task;
        }
    }
}

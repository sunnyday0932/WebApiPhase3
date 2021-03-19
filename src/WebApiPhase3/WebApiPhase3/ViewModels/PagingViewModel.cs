using System.Collections.Generic;

namespace WebApiPhase3.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingViewModel<T>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        public IEnumerable<T> Result { get; set; }

        /// <summary>
        /// Gets or sets the paging.
        /// </summary>
        public PageViewModel Paging { get; set; }
    }
}

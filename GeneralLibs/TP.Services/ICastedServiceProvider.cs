using System;

namespace TP.Services
{
    /// <summary>
    /// This supports the IServiceProvider in order to be more flexible
    /// is MSFT Dependency Injection support.
    /// Typically, applications will only get the gains from GetService<T>()
    /// </summary>
    public interface ICastedServiceProvider : IServiceProvider
    {
        /// <summary>
        /// Benefit is to have the returned service already casted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetService<T>() where T : ICastedService;
    }
}

using System;

using TP.Editor.CmdArg;
using TP.Services;

namespace TP.Editor.Application
{
    public abstract class BaseApplication : ICastedServiceProvider
    {
        #region Properties
        private string _applicationName;
        public string ApplicationName
        {
            get
            {
                if (string.IsNullOrEmpty(_applicationName))
                {
                    _applicationName = GetApplicationName();
                }
                return _applicationName;
            }
        }
        #endregion

        #region Fields
        private CmdArgService _argumentService;
        #endregion

        /// <summary>
        /// Intended to be invoked once the individual applications have been started up.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual EExitCode ApplicationMain(string[] args, CmdArgOption[] supportedCmdArgs)
        {
            _argumentService = new CmdArgService(args, supportedCmdArgs);
            return RunProgram();
        }


        public virtual T GetService<T>() where T : ICastedService
        {
            object result = GetService(typeof(T));
            if (result == null)
            {
                return default(T);
            }
            else if (result is CmdArgService)
            {
                return (T)result;
            }
            return default(T);
        }

        public virtual object GetService(Type serviceType)
        {
            if (serviceType == typeof(CmdArgService))
            {
                return _argumentService;
            }
            return null;
        }

        /// <summary>
        /// This is intended to be implemented by the .exe code in order to allow the framework to handle the setup.
        /// This should be treated as Main() for applications.
        /// </summary>
        /// <returns></returns>
        protected abstract EExitCode RunProgram();
        protected abstract string GetApplicationName();
    }
}

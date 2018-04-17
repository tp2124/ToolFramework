

namespace TP.Base.Application
{
    using Microsoft.Extensions.CommandLineUtils;
    using System;
    using TP.Services;
    /// <summary>
    /// TODO: Have this be able to accept and properly maintain command arguments
    /// for both UI and cmd applications.
    /// </summary>
    public abstract class BaseApplication 
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
        #endregion

        /// <summary>
        /// Intended to be invoked once the individual applications have been started up.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected virtual EExitCode ApplicationMain(string[] args)
        {
            //CommandLineApplication commandLineApplication =
            //       new CommandLineApplication(throwOnUnexpectedArg: false);
            //CommandArgument names = null;
            //commandLineApplication.Command("name",
            //  (target) =>
            //    names = target.Argument(
            //      "fullname",
            //      "Enter the full name of the person to be greeted.",
            //      multipleValues: true));
            //CommandOption greeting = commandLineApplication.Option(
            //  "-$|-g |--greeting <greeting>",
            //  "The greeting to display. The greeting supports"
            //  + " a format string where {fullname} will be "
            //  + "substituted with the full name.",
            //  CommandOptionType.SingleValue);
            //CommandOption uppercase = commandLineApplication.Option(
            //  "-u | --uppercase", "Display the greeting in uppercase.",
            //  CommandOptionType.NoValue);
            //commandLineApplication.HelpOption("-? | -h | --help");
            //if (commandLineApplication.OptionHelp.HasValue())
            //{

            //}

            return RunProgram();
        }

        protected virtual string GetHelpString()
        {
            return "The user has asked for helpful instructions.";
        }


        public virtual T GetService<T>() where T : ICastedService
        {
            object result = GetService(typeof(T));
            if (result == null)
            {
                return default(T);
            }
            return default(T);
        }

        /// <summary>
        /// Implementation for Dependency Injection support
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public virtual object GetService(Type serviceType)
        {
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

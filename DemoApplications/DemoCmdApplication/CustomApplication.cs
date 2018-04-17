using System;
using TP.Base.Application;
using TP.Services.Format;

namespace DemoCmdApplication
{
    class CustomApplication : ConsoleApplication
    {
        #region Properties
        private RazorTextFormatter _formatTextService;
        public RazorTextFormatter FormatTextService
        {
            get
            {
                if (_formatTextService == null)
                {
                    _formatTextService = new RazorTextFormatter();
                }
                return _formatTextService;
            }
        }
        #endregion

        static int Main(string[] args)
        {
            CustomApplication appInstance = new CustomApplication();
            return (int)appInstance.ApplicationMain(args);
        }

        protected override void Execute()
        {
            RazorTextFormatter formatter = GetService<RazorTextFormatter>();
            string compiledOutput = formatter.Demo();
            System.Console.WriteLine($"Writing some sweet Execute() code.\n{compiledOutput}");
        }

        protected override string GetApplicationName()
        {
            return "CustomApplication";
        }

        public override T GetService<T>()
        {
            object result = GetService(typeof(T));
            if (result == null)
            {
                return default(T);
            }
            else if (result is RazorTextFormatter)
            {
                return (T)result;
            }
            return base.GetService<T>();
        }

        public override object GetService(Type serviceType)
        {
            if (serviceType == typeof(RazorTextFormatter))
            {
                return FormatTextService;
            }
            return base.GetService(serviceType);
        }
    }
}

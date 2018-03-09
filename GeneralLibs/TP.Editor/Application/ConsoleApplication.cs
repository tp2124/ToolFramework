using System;

namespace TP.Editor.Application
{
    /// <summary>
    /// [TODO] Consider moving the Application Init/Execute/Shutdown commands to Base. 
    /// I'm not sure how it will play with WPF and getting hooks in for them to make sense.
    /// </summary>
    public abstract class ConsoleApplication : BaseApplication
    {
        protected virtual void Init()
        {
        }

        protected abstract void Execute();

        protected virtual EExitCode Shutdown()
        {
            return EExitCode.SUCCESS;
        }


        protected override EExitCode RunProgram()
        {
            Console.WriteLine($"Beginning Init() for {ApplicationName}.");
            Init();
            Console.WriteLine($"Beginning Execute() for {ApplicationName}.");
            Execute();
            Console.WriteLine($"Beginning Shutdown() for {ApplicationName}.");
            EExitCode executionResult = Shutdown();

            return executionResult;
        }
    }
}

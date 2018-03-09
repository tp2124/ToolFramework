using System.Collections.Generic;
using System;

using TP.Editor.CmdArg;
using TP.Services;

namespace TP.Editor
{
    public class CmdArgService : ICastedService
    {
        #region Constants
        public readonly string HELP_ARGUMENT = "help";
        public readonly string CMD_ARG_LEADING_CHARACTERS = "--";
        #endregion

        #region Fields
        Dictionary<string, string> ParsedArgumentValues;
        IEnumerable<CmdArgOption> CmdArgList;
        bool ContainsHelpArgument = false;
        #endregion

        public CmdArgService(string[] args, CmdArgOption[] supportedCmdArgs)
        {
            CmdArgList = supportedCmdArgs;
            ParsedArgumentValues = new Dictionary<string, string>(supportedCmdArgs.Length);
            foreach (CmdArgOption cmdArg in supportedCmdArgs)
            {
                // string parsedValue = String.Empty;
                // ParsedArgumentValues.Add(cmdArg.ArgumentName, parsedValue);
            }

            HandleHelpArgument(args);
        }

        public bool HasArgument(string argName)
        {
            return ParsedArgumentValues.ContainsKey(argName);
        }

        public bool GetArgumentValue(string argName, out string argValue)
        {
            return ParsedArgumentValues.TryGetValue(argName, out argValue);
        }

        public bool HasHelpArgument()
        {
            return ContainsHelpArgument;
        }

        public void PrintFullHelpInfo()
        {
            Console.WriteLine("------------- Full Argument Help Documenation ----------------");
            foreach (CmdArgOption argOption in CmdArgList)
            {
                string cmdArgValueDesc = string.Empty;
                if (argOption.ValueType == ECmdArgFlags.eRequiresValue)
                {
                    cmdArgValueDesc = "<value>";
                }
                Console.WriteLine($"{CMD_ARG_LEADING_CHARACTERS}{argOption.ArgumentName}\t{cmdArgValueDesc}\t{argOption.Description}");
            }
            Console.WriteLine("--------------------------------------------------------------");
        }

        private void HandleHelpArgument(string[] rawArguments)
        {
            foreach (string arg in rawArguments)
            {
                if (arg.StartsWith($"{CMD_ARG_LEADING_CHARACTERS}{HELP_ARGUMENT}"))
                {
                    PrintFullHelpInfo();
                }
            }
        }
    }
}

namespace TP.Editor.CmdArg
{
    public class CmdArgOption
    {
        readonly public string ArgumentName;
        readonly public string Description;
        readonly public ECmdArgFlags ValueType;

        public CmdArgOption(string argumentName, ECmdArgFlags valueType, string description)
        {
            ArgumentName = argumentName;
            ValueType = valueType;
            Description = description;
        }
    }
}

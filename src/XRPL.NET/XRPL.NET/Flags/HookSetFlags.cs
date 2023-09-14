namespace XRPL.NET.Flags;

[Flags]
public enum HookSetFlags : uint
{
    hsfOVERRIDE = 1,
    hsfNSDELETE = 2,
    hsfCOLLECT = 4
}

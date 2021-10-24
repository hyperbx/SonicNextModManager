using System.ComponentModel;

namespace SonicNextModManager
{
    public interface IConfiguration : INotifyPropertyChanged
    {
        [DefaultValue(false)]
        bool Setup_Complete { get; set; }

        [DefaultValue("en-GB")]
        string? General_Language { get; set; }

        [DefaultValue(false)]
        bool General_Debug { get; set; }

        [DefaultValue(0)]
        int Emulator_Backend { get; set; }

        [DefaultValue(0)]
        int Emulator_Resolution { get; set; }

        [DefaultValue(0)]
        int Emulator_Language { get; set; }

        [DefaultValue("")]
        string? Emulator_Arguments { get; set; }

        [DefaultValue(false)]
        bool Emulator_Fullscreen { get; set; }

        [DefaultValue(true)]
        bool Emulator_GammaCorrect { get; set; }

        [DefaultValue(false)]
        bool Emulator_LaunchAfterInstallingContent { get; set; }

        [DefaultValue("")]
        string? Path_ModsDirectory { get; set; }

        [DefaultValue("")]
        string? Path_GameExecutable { get; set; }

        [DefaultValue("")]
        string? Path_EmulatorExecutable { get; set; }
    }
}

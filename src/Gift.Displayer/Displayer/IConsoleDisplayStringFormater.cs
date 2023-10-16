using Gift.Domain.UIModel.Display;

namespace Gift.Displayer.Displayer
{
    public interface IConsoleDisplayStringFormater
    {
        string CreateDislayString(IScreenDisplay screenDisplay);
    }
}

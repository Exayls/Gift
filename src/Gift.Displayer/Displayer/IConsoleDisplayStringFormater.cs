using Gift.Domain.UIModel.Display;

namespace Gift.ApplicationService.Services.Displayer
{
    public interface IConsoleDisplayStringFormater
    {
        string CreateDislayString(IScreenDisplay screenDisplay);
    }
}

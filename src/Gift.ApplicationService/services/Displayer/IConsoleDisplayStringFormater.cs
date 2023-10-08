using Gift.Domain.UIModel.Display;

namespace Gift.ApplicationService.services.Displayer
{
    public interface IConsoleDisplayStringFormater
    {
        string CreateDislayString(IScreenDisplay screenDisplay);
    }
}

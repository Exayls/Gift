
using ExempleGift;
using Gift;
using Gift.UI;
using Gift.UI.MetaData;
using System.Text;


var ui = new GiftUI();
ui.SetChild(new Label("coucou", new Position(2, 58)));
Console.Out.Write(new Renderer().Render(ui));

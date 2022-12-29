
using ExempleGift;
using Gift;
using Gift.UI;
using Gift.UI.MetaData;
using System.Text;


var ui = new GiftUI(new Renderer(Console.Out));
ui.setChild(new Label("coucou", new Position(0, 58)));
ui.Render();

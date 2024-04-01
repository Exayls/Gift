# Gift

G.I.F.T.: GIFT Is Fully Terminal

![resit](assets/example.gif)

# Utilization

```cs
var gift = serviceProvider.GetRequiredService<IGiftService>();
gift.Initialize("ui.xml");
gift.Run();

```
| vstack | test |
|--------|------|
| vstack | e    |
| vstack | iett |

It works by sending signals to the application by using instances of Monitor:
Example

then a SignalHandler can be registered and can use the signal to perform actions on the user interface:
Example

the actions possible on the user interface are accessible through the services:
List service and method

one way to send a signal is by using the keyboard input, a config file for keys input is accessible and can be modified to add any signal:

Example with config file and signal name with handler

You can create your own component by implementing UIElement or Container.

# Color
There are colors

# Bounds

# 

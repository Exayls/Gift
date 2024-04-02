# Gift

G.I.F.T.: GIFT Is Fully Terminal

![resit](assets/example.gif)

# Utilization

```cs
var gift = serviceProvider.GetRequiredService<IGiftService>();
gift.Initialize("ui.xml");
gift.Run();

```

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

# Size
A container can have size 
If the height or width is positive, then the container will take the place of the rectangle define by its height and width.
If the height or width is equal to 0, the side of the rectangle will be the exact size needed to display its content.
If the height or width is negative, then the side of the rectangle will be the size of its parent container, or the whole terminal if no parent has a defined size.


# 

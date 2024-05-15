# Gift

G.I.F.T.: GIFT Is Fully terminal

Gift is a Terminal User Interface library that try to provide a simple way of building simple application without needing to create complex user interface.


![resit](assets/example.gif)

# Usage
You can set up a simple application by instantiating a GiftHost and running it.

```cs
using Microsoft.Extensions.Hosting;
using Serilog;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
                         .WriteTo.File($"logs/app_.log", rollingInterval: RollingInterval.Day)
                         .MinimumLevel.Debug()
                         .CreateLogger();

		var hostBuilder = new GiftHostBuilder("test.xml");
		hostBuilder.ConfigureLogging(builder =>
                            { builder.AddSerilog(); });
		var host = hostBuilder.Build();
		host.Run();
    }
}


```
# Xml
The Xml file should look like this where every tag is a new object to render:

```xml
<VStack border="simple"  Size="-1,-1">
	<VStack border="simple" frontColor="red" backColor="transparent" selectableContainer="true">
		<Label Text="Hello" />
		<Label Text="World" />
	</VStack>
	<Hstack>
		<Label border="simple" Text="Hello" />
		<Label Text="World" />
	</Hstack>
</VStack>
```
# Components
All components have attributes that you can add to their Xml that will change their behavior.
These attributes that can be used like this:
```xml
<Label backColor="red"/>
```
some are commons for all elements:
- backcolor
- frontcolor
- border

## Containers(Vstack, Hstack)
Some attributes are common for all containers:
- size
- height
- width
- selectablecontainer

You can create your own component by implementing UIElement or Container.

# Size
A container can have size 
If the height or width is positive, then the container will take the place of the rectangle define by its height and width.
If the height or width is equal to 0, the side of the rectangle will be the exact size needed to display its content.
If the height or width is negative, then the side of the rectangle will be the size of its parent container, or the whole terminal if no parent has a defined size.

# Event handling

The lib can receive signal with a name like in the example below:

```json
{
    "j": "Ui.NextElementInSelectedContainer",
    "k": "Ui.PreviousElementInSelectedContainer",
    "l": "Ui.NextContainer",
    "h": "Ui.PreviousContainer",
    "q": "Global.Quit"
}

```
Any signal emitted by a key pressed. Or any other input can be intercepted and handled by a ISignalHandlerService

you can add a signal handler by using:
```cs
gift.AddSignalHandler(mySignalHandler);

```
or

```cs
var signalBus = serviceProvider.GetRequiredService<ISignalBus>();
signalBus.AddSignalHandler(mySignalHandler);

```





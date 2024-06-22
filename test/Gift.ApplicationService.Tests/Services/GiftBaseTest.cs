// using Gift.ApplicationService.Services.SignalHandler.Bus;
// using Gift.ApplicationService.ServiceContracts;
// using Gift.ApplicationService.Services;
// using Gift.Domain.ServiceContracts;
// using Moq;
// using Microsoft.Extensions.Logging;

// namespace Gift.ApplicationService.Tests.Services
// {
//     public class GiftBaseTest
//     {
//         private readonly Mock<IMonitorService> monitorManagerMock;
//         private readonly Mock<ISignalBus> queueMock;
//         private readonly Mock<IDisplayService> displayManagerMock;
//         private readonly Mock<IXMLFileParser> xmlFileParserMock;
//         private readonly Mock<IRepository> repository;
//         private readonly GiftLauncherService giftBase;

//         public GiftBaseTest()
//         {
//             var logger = Mock.Of<ILogger<IGiftService>>();
//             monitorManagerMock = new Mock<IMonitorService>();
//             queueMock = new Mock<ISignalBus>();
//             displayManagerMock = new Mock<IDisplayService>();
//             xmlFileParserMock = new Mock<IXMLFileParser>();
//             repository = new Mock<IRepository>();

//             giftBase = new GiftLauncherService(
//                 monitorManager: monitorManagerMock.Object, bus: queueMock.Object,
//                 xmlFileParser: xmlFileParserMock.Object,
//                 displayService: displayManagerMock.Object,
//                 repository: repository.Object);
//         }
//     }
// }

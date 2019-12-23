using SeleniumTest.Drivers.Interfaces;
using SeleniumTest.Interfaces;

namespace SeleniumTest
{
    public class MainController : IMainController
    {
        private readonly ILoginDriver _loginDriver;
        private readonly IAlertCloserDriver _alertCloserDriver;
        private readonly IPlantDriver _plantDriver;

        public MainController(
            ILoginDriver loginDriver, 
            IAlertCloserDriver alertCloserDriver, 
            IPlantDriver plantDriver)
        {
            _loginDriver = loginDriver;
            _alertCloserDriver = alertCloserDriver;
            _plantDriver = plantDriver;
        }

        public void Run()
        {
            _loginDriver.Login();
            _alertCloserDriver.CloseAllAlerts();
            _plantDriver.Plant();
        }
    }
}

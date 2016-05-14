using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SpecFlow.BrowserStack
{
	[Binding]
	public class Setup
	{
		IWebDriver driver;

		[BeforeScenario]
		public void BeforeScenario()
		{
			var capabilities = new DesiredCapabilities();

			capabilities.SetCapability("os", ConfigurationManager.AppSettings["os"]);
			capabilities.SetCapability("os_version", ConfigurationManager.AppSettings["os_version"]);
			capabilities.SetCapability("browser", ConfigurationManager.AppSettings["browser"]);
      capabilities.SetCapability("browser_version", ConfigurationManager.AppSettings["browser_version"]);

      capabilities.SetCapability("browserstack.user", ConfigurationManager.AppSettings["browserstack.user"]);
			capabilities.SetCapability("browserstack.key", ConfigurationManager.AppSettings["browserstack.key"]);
			
			capabilities.SetCapability("build", "Sample Specflow tests");
			capabilities.SetCapability("name", ScenarioContext.Current.ScenarioInfo.Title);

      driver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["browserstack.hub"]), capabilities);
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
			ScenarioContext.Current["driver"] = driver;
		}

		[AfterScenario]
		public void AfterScenario()
		{
			driver.Dispose();
		}
	}
}

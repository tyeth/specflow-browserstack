using BrowserStack;
using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace SpecFlow.BrowserStack.LocalTests
{
	[Binding]
	public class Setup
	{
    static Local browserStackLocal;
		IWebDriver driver;

    [BeforeFeature]
    public static void SetupLocal()
    {
      browserStackLocal = new Local();
      List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
        new KeyValuePair<string, string>("key", ConfigurationManager.AppSettings["browserstack.key"]),
        new KeyValuePair<string, string>("forcelocal", "")
      };
      browserStackLocal.start(bsLocalArgs);
    }
    [AfterFeature]
    public static void StopLocal()
    {
      if (browserStackLocal != null)
      {
        browserStackLocal.stop();
      }
    }

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
			capabilities.SetCapability("browserstack.local", true);
			
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

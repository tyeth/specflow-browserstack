using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlow.BrowserStack.LocalTests
{
	[Binding]
	public class GoogleSteps
	{
		readonly IWebDriver _driver;

		public GoogleSteps()
		{
			_driver = (IWebDriver)ScenarioContext.Current["driver"];
		}

		[Given(@"I am on the google page")]
		public void GivenIAmOnTheGooglePage()
		{
			_driver.Navigate().GoToUrl("http://www.google.com");
		}

    [When(@"I navigate to (.*)")]
    public void WhenINavigateTo(String navigateUrl)
    {
      _driver.Navigate().GoToUrl(navigateUrl);
    }

    [Then(@"I see status as (.*)")]
    public void ThenISeeStatusAs(String expectedStatus)
    {
      StringAssert.Contains(_driver.FindElement(By.TagName("pre")).Text.Trim().ToLower(), "up and running");
    }

  }
}

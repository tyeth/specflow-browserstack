# SpecFlow-Browserstack

Execute [SpecFlow](https://github.com/techtalk/SpecFlow) scripts on BrowserStack.

## Usage

### Prerequisites

Visual Studio 2015 Update 2
To run tests in parallel, you will need to have access to execute `powershell` tools (`Run as Administrator` on `Command Prompt` works)

### Clone the repo

`git clone https://github.com/browserstack/specflow-browserstack.git`

### Install dependencies

Open the appropriate Visual Studio Solution file (.sln) and run `build`.
Visual Studio will automatically download the dependencies

### BrowserStack Authentication

To run the tests, `BROWSERSTACK_USERNAME` and `BROWSERSTACK_ACCESS_KEY` needs to be replaced with BrowserStack authentication.
These can be found on the automate accounts page on [BrowserStack](https://www.browserstack.com/accounts/automate)

These needs to be changed in the following files -

```
SpecFlow.BrowserStack/App.config
SpecFlow.BrowserStack.LocalTests/App.config
```

### Run the tests

The `NUnitTestAdapter` dependency provides a way to test from Visual Studio itself.
Just build the solution and, to run the tests -
Go to the `tests` menu -> In the `Run` sub-menu -> Click `All tests`

You can choose from `MacELCFirefox46` or `Win10Chrome50` build configurations. You can add your own configurations for different os/browser combinations.

To run the tests in parallel, powershell scripts are included in the sample, run `powershell.exe build.ps1` or `powershell.exe build_local.ps1`

example -
```
C:\Users\Admin\Desktop\specflow-browserstack>C:\windows\system32\windowspowershell\v1.0\powershell.exe C:\Users\Admin\Desktop\specflow-browserstack\build.ps1
C:\Users\Admin\Desktop\specflow-browserstack>C:\windows\system32\windowspowershell\v1.0\powershell.exe C:\Users\Admin\Desktop\specflow-browserstack\build_local.ps1
```

------

#### How to specify the capabilities

The [Code Generator](https://www.browserstack.com/automate/c-sharp#setting-os-and-browser) can come in very handy when specifying the capabilities especially for mobile devices.

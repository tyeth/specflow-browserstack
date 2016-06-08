# SpecFlow-Browserstack

Execute [SpecFlow](https://github.com/techtalk/SpecFlow) scripts on BrowserStack.

## Usage

### Prerequisites

Visual Studio 2015 Update 2

To run tests in parallel, you will need to have access to execute `powershell` tools.

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
LocalTest/LocalTest/App.config
SingleTest/SingleTest/App.config
ParallelTests/ParallelTests/App.config
```

### Run the tests

The `NUnitTestAdapter` dependency provides a way to test from Visual Studio itself.

#### For Single and Local Tests -

```
Go to the `tests` menu -> In the `Run` sub-menu -> Click `All tests`
You can choose from `MacELCFirefox46` or `Win10Chrome50` build configurations. You can add your own configurations for different os/browser combinations.
```

#### For Parallel Tests -

```
A build configuration named `RunInParallel` is added for convenience. Select the tests and click `Start` on the `Standard Toolbar` to run the tests.

Note - You might need to change the path of the current working directory for parallel tests.
To check the paths of the powershell build script -

1. Right Click on the `ParallelTests` project in the solution explorer and select `Properties`
2. Select `Debug` on the Left Pane
3. Check and correct the paths at the following -
  - The absolute path of `powershell.exe` in `Start external program`
  - The absolute path of `build.ps1` included in the repo in `Command line arguments`
  - The absolute path of `ParallelTests` folder (the folder which contains ParallelTests.sln) in `Working Directory`
```

------

#### How to specify the capabilities

The [Code Generator](https://www.browserstack.com/automate/c-sharp#setting-os-and-browser) can come in very handy when specifying the capabilities especially for mobile devices.

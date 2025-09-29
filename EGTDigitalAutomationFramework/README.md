# EGT Digital Automation Framework

[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)  
[![xUnit](https://img.shields.io/badge/Test-xUnit-orange.svg)](https://xunit.net/)  
[![Playwright](https://img.shields.io/badge/UI-Playwright-green.svg)](https://playwright.dev/dotnet)  
[![Allure](https://img.shields.io/badge/Reports-Allure-blueviolet.svg)](https://docs.qameta.io/allure/)  
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

---

## 📖 Overview

The **EGT Digital Automation Framework** is a modular and extensible **C# test automation framework** targeting **.NET 9.0**.  
It unifies **UI automation** (Playwright) and **API testing** with **xUnit**, providing a maintainable foundation for quality assurance.

---

## 🚀 Key Features

- **UI Automation** with Playwright and Page Object Model (POM)  
- **API Testing** with reusable clients and models  
- **Config-driven** test environments (`appsettings.*.json`)  
- **Parallel execution** supported by xUnit & Playwright fixtures  
- **Allure Reporting** with screenshots, logs, and step annotations  
- **Logging** with log4net  
- **CI/CD ready** (GitHub Actions / Jenkins / Azure DevOps)

---

## ⚙️ Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)  
- [Playwright CLI](https://playwright.dev/dotnet/docs/intro)  
- [Allure CLI](https://docs.qameta.io/allure/#_installing_a_commandline)  
- [Git](https://git-scm.com/downloads)  

---

## 📦 Installation & Setup

### 🔹 Windows

1. Install **.NET 9.0 SDK** from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download).  
2. Install **Git for Windows** from [git-scm.com](https://git-scm.com/download/win).  
3. Install **Playwright CLI**:
   ```powershell
   dotnet tool install --global Microsoft.Playwright.CLI
   playwright install
   ```
4. Install **Allure**:
   - Download the latest release from [Allure releases](https://github.com/allure-framework/allure2/releases).  
   - Extract and add the `bin` folder to your `PATH`.  
   - Verify:
     ```powershell
     allure --version
     ```

---

### 🔹 macOS

1. Install **.NET 9.0 SDK** using Homebrew:
   ```bash
   brew install --cask dotnet-sdk
   ```
2. Install **Git**:
   ```bash
   brew install git
   ```
3. Install **Playwright CLI**:
   ```bash
   dotnet tool install --global Microsoft.Playwright.CLI
   playwright install
   ```
4. Install **Allure** with Homebrew:
   ```bash
   brew install allure
   ```
5. Verify:
   ```bash
   dotnet --version
   allure --version
   ```

---

### 🔹 Linux (Ubuntu/Debian)

1. Install **.NET 9.0 SDK**:
   ```bash
   sudo apt-get update
   sudo apt-get install -y dotnet-sdk-9.0
   ```
   (If not available in apt yet, download manually from Microsoft’s site.)
2. Install **Git**:
   ```bash
   sudo apt-get install -y git
   ```
3. Install **Playwright CLI**:
   ```bash
   dotnet tool install --global Microsoft.Playwright.CLI
   playwright install
   ```
4. Install **Allure**:
   ```bash
   sudo apt-add-repository ppa:qameta/allure
   sudo apt-get update
   sudo apt-get install allure
   ```
5. Verify:
   ```bash
   dotnet --version
   allure --version
   ```

---

## ▶️ Running Tests

### Run All Tests
```bash
dotnet test
```

### Run Only UI Tests
```bash
dotnet test --filter "FullyQualifiedName~UI"
```

### Run Only API Tests
```bash
dotnet test --filter "FullyQualifiedName~API"
```

### Run with Environment
```bash
set DOTNET_ENVIRONMENT=Test   # Windows (PowerShell)
export DOTNET_ENVIRONMENT=Test  # macOS/Linux

dotnet test
```
### To Run UI test with specific browser
In the Configs/appsettings.*.json change the Browser property to the browser on which the tests to run e.g. "Chrome", "Firefox" and "Webkit"

---

## 📊 Allure Reporting

### Generate Results
Tests are configured to output Allure results into `allure-results/`.

### Generate & View Report
```bash
allure serve allure-results
```

This builds and opens the report in your browser.

### Generate Static Report
```bash
allure generate allure-results --clean -o allure-report
```

---

## 🔧 Configuration

Environment configs are stored in `Configs/appsettings.*.json`. Example:

```json
{
  "Headless": false,
  "SlowMo": 0,
  "Browser": "Chrome",
  "ViewportWidth": 1920,
  "ViewportHeight": 1080,
  "BaseUrl": "https://demoqa.com/automation-practice-form",
  "ApiUrl": "https://reqres.in/",
  "ApiKey": "reqres-free-v1"
}
```

Switch environment with:

```bash
export DOTNET_ENVIRONMENT=dev
```

---

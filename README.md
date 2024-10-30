# TIG-dash: Add-on ASP.NET Core MVC Snippets for Querying InfluxDB
ASP.NET Core MVC snippets to query InfluxDB from a TIG stack, providing an additional dashboard option. Originally designed for Cisco Call Manager performance monitoring, but adaptable for other use cases.

![TIG-dash diagram](https://github.com/user-attachments/assets/c4e9f927-7237-49f1-ae3f-98716d887f11)
![Sample](https://github.com/user-attachments/assets/a2cdd517-f217-48e9-8db2-6a4e00c4ddb7)

## Overview
**TIG-dash** provides essential ASP.NET Core MVC code snippets designed to query InfluxDB from a TIG stack. These snippets offer an additional dashboard option to a TIG stack, and can be integrated into existing .NET applications. This solution is particularly aimed at Cisco Call Manager performance monitoring, but can be adapted for any TIG stack or InfluxDB setup. Originally built as an addon for an existing GitHub Repo from sieteunoseis - https://github.com/sieteunoseis/cucm_tig_dashboard_ubuntu

## Features
- **Essential Code Snippets**: Includes C# controller logic, jQuery logic in the views, and the model, allowing for easy integration into your own .NET pages or apps.
- **Based on an existing repo for CUCM Performance Monitoring**: Pre-built to target TIG stack OVA image for Cisco Call Manager performance monitoring. See 'Overview'.

## Prerequisites
- **ASP.NET Core 3.1**
- **ASP.NET Core MVC Environment**
- **Pre-configured TIG Stack**: Ensure you have a working TIG stack with at least Telegraf and InfluxDB configured.

## Installation
1. **Clone the Repository**:
    ```bash
    git clone https://github.com/yourusername/TIG-dash.git
    ```
2. **Add the Files to Your Project**:
    - Copy the model, view, and controller files into your existing ASP.NET Core MVC project.
    - Edit the code where required to integrate it with your project.
  
## Usage
1. **Configure Required Settings**: Update any necessary settings in your project's `appsettings.json`.
2. **Run Your Application**:
    ```bash
    dotnet run
    ```

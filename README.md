# TIG-dash: ASP.NET Core MVC Snippets for Querying InfluxDB
ASP.NET Core MVC snippets to query InfluxDB from a TIG stack, providing an additional dashboard option. Originally designed for Cisco Call Manager performance monitoring, but adaptable for other use cases.

![TIG-dash diagram](https://github.com/user-attachments/assets/cb8b13e3-36df-4809-83d1-ee64bb448aa9)
![Sample](https://github.com/user-attachments/assets/ee4e33b7-7e64-4dc1-b295-01d98a937cee)


## Overview
**TIG-dash** offers an additional dashboard option to a TIG stack, and can be integrated into existing .NET applications. The repo is particularly aimed at Cisco Call Manager performance monitoring, but can be adapted for any TIG stack or InfluxDB setup. Originally built as an addon solution for an existing GitHub Repo from sieteunoseis - https://github.com/sieteunoseis/cucm_tig_dashboard_ubuntu

## Features
- **Essential Code Snippets**: Includes C# controller logic, jQuery logic in the views, and the model, allowing for easy integration into your own .NET pages or apps.
- **Based on an existing repo for CUCM Performance Monitoring**: Pre-built to target TIG stack OVA image for Cisco Call Manager performance monitoring. See 'Overview'.

## Prerequisites
- **ASP.NET Core MVC Environment (original solution was built on ASP.NET Core 3.1)**
- **Pre-configured TIG Stack**: Ensure you have a working TIG stack with at least Telegraf and InfluxDB configured.

## Installation
1. **Clone the Repository**:
    ```bash
    git clone https://github.com/pextonc/TIG-dash.git
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

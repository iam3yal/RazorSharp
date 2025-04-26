![Logo](assets/Logo.png)

RazorSharp is a Razor Class Library that aims to provide enterprise-class UI components for Blazor.

1. **Work in Progress**: This project is currently a work in progress so be aware that this library is not yet production-ready and it may not meet the same quality standards and support as mature products. 
2. **Solo Development**: I'm the sole contributor to this project at the moment. If you're interested in joining the effort, please let me know! 
3. **Open to Feedback**: Your feedback is highly appreciated! Feel free to provide suggestions, report issues, or contribute to its development.

## Why RazorSharp?

### Free and Open Source

RazorSharp is an open-source project, and it's completely free to use, even for commercial purposes.

### Community

I truly value the strength of community collaboration in the development of RazorSharp. It's not just about code for me; it's about building something amazing together. Your contributions, insights, and feedback mean a lot to me as an individual developer.

I'm sincerely grateful for your involvement as we collectively shape the future of RazorSharp, striving to create a robust and versatile component library.

[![Join us on Discord](https://discordapp.com/api/guilds/1160531142852743340/widget.png)](https://discord.gg/v4DymbjpWC)

### Features

RazorSharp offers a range of powerful features:

- [ ] **Stability**: Get started with battle-tested components, where you can rely on a rock-solid foundation right out of the box.
- [x] **Simplicity**: A flexible and powerful design, providing a user-friendly experience to use, extend and customize components to your needs.
- [ ] **Accessibility**: Prioritizing web accessibility with WCAG compliance, ARIA support, semantic markup, and keyboard navigation for inclusive and accessible applications.
- [ ] **RTL Support**: Ensures robust compatibility with Right-to-Left (RTL) languages, providing a user-friendly and culturally sensitive experience for RTL language users.

### In Progress

- [x] Implementing all components listed in the [Components Reference](https://github.com/iam3yal/RazorSharp/issues/4).
- [x] Adding unit tests to existing types and components.
- [x] Adding documentation to existing types and methods.
- [ ] GitHub Workflows
- [x] Move to .NET 8

### Future Plans

- [ ] Extensive examples and documentation.
- [ ] Internationalization and localization support.
- [ ] Themes and styles customization.
- [ ] Cross-cutting concerns support: logging, authentication, authorization, caching, dependency injection.
- [ ] Compare with other similar products.
- [ ] Develop a dedicated components demo website.
- [ ] Develop a components playground website for experimentation.
- [ ] Explore commercial support options for businesses which would allow me to dedicate more of my time to the development of this library. It's important to note that regardless to my decision here this will always be completely free to use, even for commercial purposes as noted above.

## Running Demos from the CLI

#### Installing .NET 8

To get started, you'll need to install the latest version of .NET 8 by following these steps:

1. Visit [this link](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script) to install the latest version of .NET 8.
2. After installation, open your command prompt or terminal and type the following command to verify that `dotnet` is correctly added to the `PATH` environment.
3. If the command displays information about .NET 8, it means the installation was successful. You're now ready to proceed with running the RazorSharp demos.

#### Building the solution 
To build the solution navigate to the `src` directory and follow these commands:
```
cd src
dotnet restore
dotnet build
```

#### Optional: WebAssembly & Sqlite Support
To use `Sqlite` with `WebAssembly` you have to install the `wasm-tools` so run these additional commands from the `src` directory:
```
cd RazorSharp.Demo.Blazor.WasmClient
sudo dotnet workload restore
cd ..
```

#### Optional: Enabling HTTPS Development Certificate
If you'd like to enable the HTTPS development certificate, run the following command:
```
dotnet dev-certs https --trust
```

#### Running the demo on Blazor Server (Server-Side Rendering)
To try the blazor server demo (`RazorSharp.Demo.Blazor.ServerApp`), run the following command:
```
dotnet run --project RazorSharp.Demo.Blazor.ServerApp
```

#### Running the demo on Blazor Client (WebAssembly)
To try the blazor wasm demo (`RazorSharp.Demo.Blazor.WasmClient`), run the following command:
```
dotnet run --project RazorSharp.Demo.Blazor.WasmServer
```
* The wasm demo `RazorSharp.Demo.Blazor.WasmClient` is served to the browser through `RazorSharp.Demo.Blazor.WasmServer`.
  
#### Running the DataServer for the Search demo
To run the DataServer for the Search demo, execute the command below. Afterward, you can run any of the previously mentioned demo projects (`RazorSharp.Demo.Blazor.ServerApp` or `RazorSharp.Demo.Blazor.WasmClient`) and click on Playground / Search.
```
dotnet run --project RazorSharp.Demo.Search.DataServer
```

## Terminating the `dotnet` Process
To terminate the currently running `dotnet` process, simply press `Ctrl^C`.

#### If there are still active `dotnet` processes and you wish to forcibly terminate them, you have two simple options:

1. **Option 1 (Linux and macOS)**: Execute the following command:
   ```
   killall dotnet
   ```

2. **Option 2 (Windows, Linux, and macOS)** : [Install](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell) the latest version of PowerShell if it's not already installed and execute the following command:
   ```
   pwsh -Command "Get-Process -Name *dotnet* | Stop-Process"
   ```
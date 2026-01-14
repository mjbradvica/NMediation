# NMediation

Simple, easy mediation and publishing for dotnet.

![TempIcon](https://i.imgur.com/hJSXnqi.png)

![build-status](https://github.com/mjbradvica/NMediation/workflows/build-test/badge.svg) ![downloads](https://img.shields.io/nuget/dt/NMediation) ![downloads](https://img.shields.io/nuget/v/NMediation) ![activity](https://img.shields.io/github/last-commit/mjbradvica/NMediation/master)

## Overview

NMediation gives you:

- :books: Simple and easy API
- :dash: Fast & Performant
- :twisted_rightwards_arrows: Full async and Cancellation Token support
- :moneybag: Free Forever
- :seedling: Easily transition from MediatR

## Table of Contents

- [NMediation](#nmediation)
  - [Overview](#overview)
  - [Samples](#samples)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [Contents](#contents)
  - [Quick Start](#quick-start)
    - [Setup](#setup)
    - [Mediation](#mediation)
    - [Publishing](#publishing)
  - [Detailed Usage](#detailed-usage)
    - [Pre- and post-processing handlers](#pre--and-post-processing-handlers)
  - [FAQ](#faq)

## Samples

If you would like code samples for NMediation, they may be found [here in the documents](https://github.com/mjbradvica/NMediation/tree/master/samples/NMediation.Samples).

## Dependencies

NMediation has a dependency on the [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions) package to allow integration into the base container.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/packages/NMediation/).

Install where you need with:

```bash
Install-Package NMediation
```

If you want to install just the base interface without the single dependency in certain projects.

```bash
Install-Package NMediation.Abstractions
```

## Contents

NMediation is the simplest implementation of the Mediator and Observer patterns for the dotnet framework. The library comes with zero excessive features to weight down performance or burden the end-user with unnecessary options.

The entire library consists of a series of interfaces alongside one base class and one type. It is purposely designed to allow a junior developer to learn in 15 minutes.

## Quick Start

### Setup

NMediation has a single line setup to hook itself into the base DI container.

```csharp
services.AddNMedation(Assembly.GetExecutingAssembly());
```

> You may pass either a single assembly or a parameterized list.

### Mediation

Mediation involves sending a request object to a single handler and returning a single response or a substitute for void.

> It is recommended you always return an indicator to flag either the handler operation was a success or not.

Create a response object for your operation:

```csharp
 public class WeatherResponse
 {
     public IEnumerable<string> Weather { get; init; } = Enumerable.Empty<string>();
 }
```

Create a request object that inherits the "IPayload" of type T where T is your response type.

```csharp
public class WeatherRequest : IPayload<WeatherResponse>
{
}
```

As always, you may pass whatever metadata is required as a property.

Create a handler for the request object:

The handler will inherit from the "IPayloadHandler" interface of type T and K, where T is your request type and K is your response type.

```csharp
public class WeatherHandler : IPayloadHandler<WeatherRequest, WeatherResponse>
{
    private readonly IWeatherSource _weatherSource;

    // Constructor omitted.

    public async Task<WeatherResponse> Handle(WeatherRequest payload, CancellationToken cancellationToken)
    {
        var currentWeather = await _weatherSource.GetCurrentWeather();

        return new WeatherResponse
        {
            Weather = currentWeather,
        };
    }
}
```

You may inject whatever dependencies are required for your handlers.

To start a mediation request, inject the "IMediation" interface into the source and send the request via the "Mediate" function.

```csharp
// API Controller

public async Task<IActionResult> GetWeather()
{
    var result = await _medation.Mediate(new WeatherRequest());

    return Ok(result);
}
```

### Publishing

Publishing involves sending an event to N number of handlers in a fire-and-forgot method with no return.

Create an event or occurrence to publish.

```csharp
public class MyOccurrence : IOccurrence
{
}
```

The interface is to designate the type to determine which handlers to send the event to. You may add as much metadata as you require.

Create as many handlers as required to operate on the event.

Simply implement the "IOccurrenceHandler" of type T where T is the name of your event.

```csharp
public class MyOccurrenceHandler : IOccurrenceHandler<MyOccurrence>
{
    public Task Handle(MyOccurrence occurrence, CancellationToken cancellationToken)
    {
        // Do whatever is required.
    }
}
```

To publish an event, call the "Publish" method on the "IMediation" interface.

```csharp
var occurrence = new MyOccurrence();

await _medation.Publish(occurrence);
```

## Detailed Usage

### Pre- and post-processing handlers

NMediation comes with a built-in base handler that allows you to perform certain tasks before and after a handler's main task.

Let's say we want to log our payload and response object from certain handlers. That is a simple task to perform.

Have your logging handler inherit from the "BaseProcessingHandler" pass the type of your payload and response types like you would any other handler.

```csharp
public abstract class BaseLoggingHandler : BaseProcessingHandler<WeatherRequest, WeatherResponse>
{
    private readonly ILogger<BaseLoggingHandler> _logger;

    public BaseLoggingHandler(ILogger<BaseLoggingHandler> logger)
    {
        _logger = logger;
    }

    protected override Task<WeatherRequest> PreProcessing(WeatherRequest payload, CancellationToken cancellationToken)
    {
        _logger.LogInformation("State of initial payload: {Payload}", payload);

        return Task.FromResult(payload);
    }

    protected override Task<WeatherResponse> DoWork(WeatherRequest payload, CancellationToken cancellationToken);

    protected override Task<WeatherResponse> PostProcessing(WeatherResponse response, CancellationToken cancellationToken)
    {
        _logger.LogInformation("State of final response: {Response}", response);

        return Task.FromResult(response);
    }
}
```

Your handler will implement your base handler and only implement the "DoWork" function.

```csharp
public class MyWeatherHandler : BaseLoggingHandler
{
    public MyWeatherHandler(ILogger<BaseLoggingHandler> logger)
        : base(logger)
    {
    }

    protected override Task<string> DoWork(GetWeatherRequest payload, CancellationToken cancellationToken)
    {
        const string response = "The weather is hot!";

        return Task.FromResult(response);
    }
}
```

You may also continue to chain the generics down to the base handler to use in any situation.

```csharp
public abstract class BaseGenericHandler<TRequest, TResponse> : BaseProcessingHandler<TRequest, TResponse>
    where TRequest : IPayload<TResponse>
{
    protected override Task<TResponse> PostProcessing(TResponse response, CancellationToken cancellationToken)
    {
        return Task.FromResult(response);
    }

    protected override Task<TRequest> PreProcessing(TRequest payload, CancellationToken cancellationToken)
    {
        return Task.FromResult(payload);
    }
}
```

## FAQ

### Do I need NMediation?

You don't need any library. However, NMediation can be used in 99% of traditional applications. It does a great job at creating clear lines of separation between application level code and other parts of your project.

The other wonder side effect of NMediation is you can use feature folders for better project composition.

### Does NMediation need a commercial license to use?

No! NMediation is 100% free forever. It uses the open source MIT license.

### What are the main difference between NMediation and MediatR?

NMedation has simpler setup.
NMedation is blazing fast, with no excess ceremony.
NMedation only allows for fully typed contracts, no blank objects.
NMedation is free.
NMedation is easier to debug pre- and post-processing because it uses base classes for those operations.

### Is it hard to transition over to NMediation?

Not at all, it is best to transition over time. You can convert one handler at a time until your application is fully converted.

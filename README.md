# NMediation

Simple, easy mediation and publishing for .NET. Free forever.

![TempIcon](https://i.imgur.com/8ueAzZA.png[/img])

![build-status](https://github.com/mjbradvica/NMediation/workflows/build-test/badge.svg) ![downloads](https://img.shields.io/nuget/dt/NMediation) ![downloads](https://img.shields.io/nuget/v/NMediation) ![activity](https://img.shields.io/github/last-commit/mjbradvica/NMediation/master)

## Overview

NMediation gives you:

- :books: Simple and easy API
- :dash: Fast & Performant
- :twisted_rightwards_arrows: Full async and Cancellation Token support
- :moneybag: Free Forever

## Table of Contents

## Samples

If you would like code samples for ClearDomain, they may be found [here in the documents](https://github.com/mjbradvica/NMediation/tree/master/samples/NMediation.Samples).

## Dependencies

NMediation has a dependency on the [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions) package to allow integration into the base container.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/packages/NMediation/).

Install where you need with:

```bash
Install-Package NMediation
```

## Contents

NMediation is the simplest implementation of the Mediator and Observer patterns for the Dotnet framework. The library comes with zero excessive features to weight down performance or burden the end-user with unnecessary options.

The entire library consists of a series of interfaces alongside one base class and one type. It is purposely designed to allow a junior developer to learn in 15 minutes.

## Quick Start

### Setup

NMediation has a single line setup to hook itself into the base container.

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

As always, you maybe pass whatever metadata is required as a property.

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

To start a mediation request, inject the "IMedation" interface into the source and send the request via the "Mediate" function.

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

To publish an event, call the "Publish" method on the IMediation interface.

```csharp
var occurrence = new MyOccurrence();

await _medation.Publish(occurrence);
```

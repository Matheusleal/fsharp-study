module Zettai

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection

open Giraffe

let webApp =
    choose [
        route "/" >=> text "Hello Zettai user!"]

let configureApp (app : IApplicationBuilder) = app.UseGiraffe webApp

let configureServices (services : IServiceCollection) = services.AddGiraffe() |> ignore

let configureHost (host : IWebHostBuilder) =
    host
        .Configure(configureApp)
        .ConfigureServices(configureServices)

[<EntryPoint>]
let main _ =
    Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(configureHost >> ignore)
        .Build()
        .Run()
    0
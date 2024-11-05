module Zettai.Tests

open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.TestHost

open Xunit
//open FsUnit.Xunit
open Swensen.Unquote
open System.Net


[<Fact>]
//let hello_world_test () =  "Hello Zettai user! 1"  |> should equal "Hello Zettai user!"
let hello_world_test2 () =  
    let whb = new WebHostBuilder() |> Zettai.configureHost
    let server = new TestServer(whb)
    let client = server.CreateClient()

    let response = 
        task {
            let! response = client.GetAsync("/")
            let! content = response.Content.ReadAsStringAsync()

            return (response.StatusCode, content)
        }
        |> Async.AwaitTask
        |> Async.RunSynchronously

    test <@ response = (HttpStatusCode.OK, "Hello Zettai user!") @>

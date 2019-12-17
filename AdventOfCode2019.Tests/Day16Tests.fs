module Day16ests

open AdventOfCode2019
open Xunit
open AdventOfCode2019.Day16
open System.IO
open Xunit.Abstractions
  
type Day16Tests(output:ITestOutputHelper) =

    [<Fact>]
    member __.``Example1`` () =
        let input = "12345678"
        let phases = 1 
        
        let actual = part1 input phases output
        let expected = "48226158"

        Assert.Equal(expected, actual)


    [<Fact>]
    member __.``Example2`` () =
        let input = "12345678"
        let phases = 4
        
        let actual = part1 input phases output
        let expected = "01029498"

        Assert.Equal(expected, actual)

    [<Fact>]
    member __.``Example3`` () =
        let input = "69317163492948606335995924319873"
        let phases = 100
        
        let actual = part1 input phases output
        let expected = "52432133"

        Assert.Equal(expected, actual.Substring(0,8))


    [<Fact>]
    member __.``Part1`` () =
        let input = File.ReadAllText("Input/Day16.txt")
        
        let phases = 100
        
        let actual = part1 input phases output
        let expected = "42205986"

        Assert.Equal(expected, actual.Substring(0,8))
        

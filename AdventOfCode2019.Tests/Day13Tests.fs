module Day13Tests

open Xunit
open AdventOfCode2019.Day13
open System.IO
open Xunit.Abstractions
  
type Day13Tests(output:ITestOutputHelper) =

    [<Fact>]
    member __.``Part1`` () =
        let input = File.ReadAllText(@"Input/Day13.txt")
        let expected = 236
        
        let actual = part1 input

        Assert.Equal(expected, actual) 

    [<Fact>]
    member __.``Part2`` () =
        let input = File.ReadAllText(@"Input/Day13.txt")
        let expected = 11040L
        
        let actual = part2 input

        Assert.Equal(expected, actual) 

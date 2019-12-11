module Day11Tests

open Xunit
open AdventOfCode2019.Day11
open System.IO
open Xunit.Abstractions
  
type Day11Tests(output:ITestOutputHelper) =

    [<Fact>]
    member __.``Part1`` () =
        let input = File.ReadAllText(@"Input/Day11.txt")
        let expected = 2268
        
        let actual = part1 input

        Assert.Equal(expected, Map.count actual) 

    [<Fact>]
    member __.``Part2`` () =
        let input = File.ReadAllText(@"Input/Day11.txt")
        let expected = "  ██  ████ ███  █  █ ████   ██  ██  ███    \r\n" +
                       " █  █ █    █  █ █ █     █    █ █  █ █  █   \r\n" +
                       " █    ███  █  █ ██     █     █ █    █  █   \r\n" +
                       " █    █    ███  █ █   █      █ █    ███    \r\n" +
                       " █  █ █    █    █ █  █    █  █ █  █ █ █    \r\n" +
                       "  ██  ████ █    █  █ ████  ██   ██  █  █   " 
        
        let actual = part2 input
        
        output.WriteLine(actual)
        Assert.Equal(expected,actual) 


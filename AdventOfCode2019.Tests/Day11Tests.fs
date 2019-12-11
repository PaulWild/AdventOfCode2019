module Day11Tests

open Xunit
open AdventOfCode2019.Day11
open System.IO
  
[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day11.txt")
    let expected = 2268
    
    let actual = part1 input 
    Assert.Equal(expected, Map.count actual) 

module Day6Tests

open Xunit
open AdventOfCode2019.Day6
open System.IO

let input = "COM)B B)C C)D D)E E)F B)G G)H D)I E)J J)K K)L"

let innerSplit (str: string) = 
    let split = str.Split(')')
    (split.[1],split.[0])

[<Fact>]
let ``Example1`` () =
    let resultList = input.Split(" ") |> Array.toList |> List.map innerSplit |> Map.ofList
    let result = countParents resultList 
    Assert.Equal(42, result)

[<Fact>]
let ``Part1`` () =
    let resultList = File.ReadAllLines(@"Input/Day6.txt") |> Array.toList |> List.map innerSplit |> Map.ofList
    let result = countParents resultList 
    Assert.Equal(249308, result)
 
[<Fact>]
let ``Part2`` () =
    let resultList = File.ReadAllLines(@"Input/Day6.txt") |> Array.toList |> List.map innerSplit |> Map.ofList
    let result = part2 resultList 
    Assert.Equal(349, result)
        
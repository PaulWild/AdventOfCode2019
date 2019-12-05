module Day5Tests

open Xunit
open AdventOfCode2019.Day2
open System.IO

[<Fact>]
let ``Example1`` () =
    let input = "3,0,4,0,99"
    let expected = 3500
    let actual = runForDay5 input (Some 3500)
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day5.txt")
    let expected = 13818007
    let actual = runForDay5 input (Some 1)
    Assert.Equal(expected, actual) 



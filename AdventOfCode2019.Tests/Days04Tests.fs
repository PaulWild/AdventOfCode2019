module Days4Tests

open Xunit
open AdventOfCode2019.Day4

[<Fact>]
let ``Part1`` () =
    let startNumber = 171309
    let endNumber = 643603
    let expected = 1625
    let actual = Part1 startNumber endNumber
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Part2`` () =
    let startNumber = 171309
    let endNumber = 643603
    let expected = 1111
    let actual = Part2 startNumber endNumber
    Assert.Equal(expected, actual) 
    
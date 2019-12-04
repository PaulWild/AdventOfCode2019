module Days4Tests

open Xunit
open AdventOfCode2019.Day4

[<Fact>]
let ``Example1`` () =
    let input = 111111
    let expected = true
    let actual = processNumber input
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example2`` () =
    let input = 223450
    let expected = false
    let actual = processNumber input
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example3`` () =
    let input = 123789
    let expected = false
    let actual = processNumber input
    Assert.Equal(expected, actual) 

    
[<Fact>]
let ``HasEven`` () =
    let input = "223" |> Seq.toList
    let expected = true
    let actual = hasSingleDoubleDigit Single input
    Assert.Equal(expected, actual) 
    

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
    
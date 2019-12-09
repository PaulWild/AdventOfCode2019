module Day5Tests

open Xunit
open AdventOfCode2019.Day2
open System.IO

[<Fact>]
let ``Example1`` () =
    let input = "3,0,4,0,99"
    let expected = Some 3500L
    let actual = runForDay5 input (Some 3500L)
    Assert.Equal(expected, actual.Output) 


[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day5.txt")
    let expected = Some 13818007L
    let actual = runForDay5 input (Some 1L)
    Assert.Equal(expected, actual.Output) 



[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllText(@"Input/Day5.txt")
    let expected = Some 3176266L
    let actual = runForDay5 input (Some 5L)
    Assert.Equal(expected, actual.Output) 


[<Fact>]
let ``Example2`` () =
    let input = "3,9,8,9,10,9,4,9,99,-1,8"
    let expected = Some 1L
    let actual = runForDay5 input (Some 8L)
    Assert.Equal(expected, actual.Output) 


[<Fact>]
let ``Example3`` () =
    let input = "3,9,8,9,10,9,4,9,99,-1,8"
    let expected = Some 0L
    let actual = runForDay5 input (Some 6L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example4`` () =
    let input = "3,9,7,9,10,9,4,9,99,-1,8"
    let expected = Some 0L
    let actual = runForDay5 input (Some 8L)
    Assert.Equal(expected, actual.Output) 


[<Fact>]
let ``Example5`` () =
    let input = "3,9,7,9,10,9,4,9,99,-1,8"
    let expected = Some 1L
    let actual = runForDay5 input (Some 6L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example6`` () =
    let input = "3,3,1108,-1,8,3,4,3,99"
    let expected = Some 1L
    let actual = runForDay5 input (Some 8L)
    Assert.Equal(expected, actual.Output) 


[<Fact>]
let ``Example7`` () =
    let input = "3,3,1108,-1,8,3,4,3,99"
    let expected = Some 0L
    let actual = runForDay5 input (Some 6L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example8`` () =
    let input = "3,3,1107,-1,8,3,4,3,99"
    let expected = Some 1L
    let actual = runForDay5 input (Some 6L)
    Assert.Equal(expected, actual.Output) 


[<Fact>]
let ``Example9`` () =
    let input = "3,3,1107,-1,8,3,4,3,99"
    let expected = Some 0L
    let actual = runForDay5 input (Some 10L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example10`` () =
    let input = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9"
    let expected = Some 0L
    let actual = runForDay5 input (Some 0L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example11`` () =
    let input = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9"
    let expected = Some 1L
    let actual = runForDay5 input (Some 12L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example12`` () =
    let input = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1"
    let expected = Some 0L
    let actual = runForDay5 input (Some 0L)
    Assert.Equal(expected, actual.Output) 

[<Fact>]
let ``Example13`` () =
    let input = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1"
    let expected = Some 1L
    let actual = runForDay5 input (Some 12L)
    Assert.Equal(expected, actual.Output) 
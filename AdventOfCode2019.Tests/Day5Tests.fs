module Day5Tests

open Xunit
open AdventOfCode2019.Day2
open System.IO

[<Fact>]
let ``Example1`` () =
    let input = "3,0,4,0,99"
    let expected = 3500
    let actual = runForDay5 input (Some [3500])
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day5.txt")
    let expected = 13818007
    let actual = runForDay5 input (Some [1])
    Assert.Equal(expected, actual) 



[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllText(@"Input/Day5.txt")
    let expected = 3176266
    let actual = runForDay5 input (Some [5])
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example2`` () =
    let input = "3,9,8,9,10,9,4,9,99,-1,8"
    let expected = 1
    let actual = runForDay5 input (Some [8])
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example3`` () =
    let input = "3,9,8,9,10,9,4,9,99,-1,8"
    let expected = 0
    let actual = runForDay5 input (Some [6])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example4`` () =
    let input = "3,9,7,9,10,9,4,9,99,-1,8"
    let expected = 0
    let actual = runForDay5 input (Some [8])
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example5`` () =
    let input = "3,9,7,9,10,9,4,9,99,-1,8"
    let expected = 1
    let actual = runForDay5 input (Some [6])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example6`` () =
    let input = "3,3,1108,-1,8,3,4,3,99"
    let expected = 1
    let actual = runForDay5 input (Some [8])
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example7`` () =
    let input = "3,3,1108,-1,8,3,4,3,99"
    let expected = 0
    let actual = runForDay5 input (Some [6])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example8`` () =
    let input = "3,3,1107,-1,8,3,4,3,99"
    let expected = 1
    let actual = runForDay5 input (Some [6])
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example9`` () =
    let input = "3,3,1107,-1,8,3,4,3,99"
    let expected = 0
    let actual = runForDay5 input (Some [10])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example10`` () =
    let input = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9"
    let expected = 0
    let actual = runForDay5 input (Some [0])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example11`` () =
    let input = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9"
    let expected = 1
    let actual = runForDay5 input (Some [12])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example12`` () =
    let input = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1"
    let expected = 0
    let actual = runForDay5 input (Some [0])
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example13`` () =
    let input = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1"
    let expected = 1
    let actual = runForDay5 input (Some [12])
    Assert.Equal(expected, actual) 
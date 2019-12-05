module Day2Tests

open Xunit
open AdventOfCode2019.Day2

let resultToString (result: seq<int>) =
    result |> Seq.map (fun x-> x.ToString()) |> String.concat ","


[<Fact>]
let ``Example1`` () =
    let input = "1,9,10,3,2,3,11,0,99,30,40,50"
    let expected = 3500
    let actual = runFor input 9 10
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example2`` () =
    let input = "1,0,0,0,99"
    let expected = 2
    let actual = runFor input 0 0
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example3`` () =
    let input = "2,3,0,3,99"
    let expected = 2
    let actual = runFor input 3 0
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example4`` () =
    let input = "2,4,4,5,99,0"
    let expected = 2
    let actual = runFor input 4 4
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example5`` () =
    let input = "1,1,1,4,99,5,6,0,99"
    let expected = 30
    let actual = runFor input 1 1
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Part1`` () =
    let expected = 3790645
    let actual = Part1 
    Assert.Equal(expected, actual)
    

[<Fact>]
let ``Part2`` () =
    let expected = (65,77)
    let actual = Part2
    Assert.Equal(expected, actual) 
module Day3Tests

open Xunit
open AdventOfCode2019.Day3

let resultToString (result: seq<int>) =
    result |> Seq.map (fun x-> x.ToString()) |> String.concat ","


[<Fact>]
let ``Example1`` () =
    let input = ["R8,U5,L5,D3";"U7,R6,D4,L4"]
    let expected = 6
    let actual = runFor input
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example2`` () =
    let input = ["R75,D30,R83,U83,L12,D49,R71,U7,L72";"U62,R66,U55,R34,D71,R55,D58,R83"]
    let expected = 159
    let actual = runFor input
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example3`` () =
    let input = ["R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";"U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"]
    let expected = 135
    let actual = runFor input
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Part1`` () =
    let expected = 1017
    let actual = Part1
    Assert.Equal(expected, actual) 



[<Fact>]
let ``Example4`` () =
    let input =["R8,U5,L5,D3";"U7,R6,D4,L4"]
    let expected = 30
    let actual = Part2 input
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example5`` () =
    let input = ["R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51";"U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"]
    let expected = 410
    let actual = Part2 input
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Part2`` () =
    let expected = 410
    let actual = Part2 (input |> Array.toList)
    Assert.Equal(expected, actual) 

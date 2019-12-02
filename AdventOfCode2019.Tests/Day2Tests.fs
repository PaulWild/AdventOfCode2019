module Da2Tests

open Xunit
open AdventOfCode2019.Day2

let resultToString (result: seq<int>) =
    result |> Seq.map (fun x-> x.ToString()) |> String.concat ","


[<Fact>]
let ``Example1`` () =
    let input = [1; 9; 10; 3; 2; 3; 11; 0; 99; 30; 40; 50]
    let expected = "3500,9,10,70,2,3,11,0,99,30,40,50"
    let actual = resultToString (Processor input)
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example2`` () =
    let input = [1;0;0;0;99]
    let expected = "2,0,0,0,99"
    let actual = resultToString (Processor input)
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example3`` () =
    let input = [2;3;0;3;99]
    let expected = "2,3,0,6,99"
    let actual = resultToString (Processor input)
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example4`` () =
    let input = [2;4;4;5;99;0]
    let expected = "2,4,4,5,99,9801"
    let actual = resultToString (Processor input)
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example5`` () =
    let input = [1;1;1;4;99;5;6;0;99]
    let expected = "30,1,1,4,2,5,6,0,99"
    let actual = resultToString (Processor input)
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Part1`` () =
    let expected = 3790645
    let actual = Part1 |> Seq.toList
    Assert.Equal(expected, actual.Head)
    

[<Fact>]
let ``Part2`` () =
    let expected = (65,77)
    let actual = Part2
    Assert.Equal(expected, actual) 
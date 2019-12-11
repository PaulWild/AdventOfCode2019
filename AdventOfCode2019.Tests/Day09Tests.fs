module Day9Tests

open Xunit
open AdventOfCode2019.Day9
open AdventOfCode2019.IntCode
open System.IO
  
[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day9.txt")
    let expected = 2775723069L
    
    let actual = run input <| Some 1L
    Assert.Equal(expected, actual.Output.[0]) 

[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllText(@"Input/Day9.txt")
    let expected = 49115L
    
    let actual = run input <| Some 2L
    Assert.Equal(expected, actual.Output.[0])  

[<Fact>]
let ``Example1`` () =
    let input = "104,1125899906842624,99"

    let actual = run input None 
    Assert.Equal(1125899906842624L ,actual.Output.[0])

[<Fact>]
let ``Example2`` () =
    let input = "1102,34915192,34915192,7,4,7,99,0"
    
    let actual = run input None 
    Assert.Equal(1219070632396864L ,actual.Output.[0])

[<Fact>]
let ``Example3`` () =
    let input = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99"
    
    let actual = run input None
    let res = actual.Output |> List.rev |> List.map (fun x -> x.ToString()) |> String.concat ","
    Assert.Equal(input , res)
     
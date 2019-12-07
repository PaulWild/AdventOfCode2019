module Day7Tests

open Xunit
open AdventOfCode2019.Day2
open AdventOfCode2019.Day7
open System.IO
  
[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day7.txt")
    let expected = 34852
    
    let actual = runForPart1 input 
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example2`` () =
    let inputExample = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5"
    let phases = [9;8;7;6;5] 
  
    
    let rec run phases input =
        match phases with
        | x :: xs ->  run xs (runForDay5 inputExample <| Some [x; input])
        | [] -> input
        
    run phases 0
    //Assert.Equal(0,run phases 0)

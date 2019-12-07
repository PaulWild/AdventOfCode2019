module Day7Tests

open Xunit
open AdventOfCode2019.Day2
open AdventOfCode2019.Day7
open System.IO
  

[<Fact>]
let ``Example1`` () =
    let inputExample = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0"
    let phases = [4;3;2;1;0] 
  
    
    let rec run phases input =
        match phases with
        | x :: xs ->  run xs (runForDay5 inputExample <| Some [x; input])
        | [] -> input
        
    12
    //Assert.Equal(0,run phases 0)
   

[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllText(@"Input/Day7.txt")
    let expected = 3176266
    
    let actual = runForPart1 input 
    Assert.Equal(expected, actual) 


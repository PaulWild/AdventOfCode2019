module Day7Tests

open Xunit
open AdventOfCode2019.Day7
open AdventOfCode2019.IntCode
open System.IO
  
[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day7.txt")
    let expected = 34852L
    
    let actual = runForPart1 input 
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllText(@"Input/Day7.txt")
    let expected = 44282086L
    
    let actual = runForPart2 input 
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Example2`` () =
    let input = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10"

    let actual = runForPart2 input 
    Assert.Equal(18216L,actual)

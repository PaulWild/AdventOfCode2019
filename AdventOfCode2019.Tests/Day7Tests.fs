module Day7Tests

open AdventOfCode2019
open Xunit
open AdventOfCode2019.Day7
open AdventOfCode2019.Day2
open System.IO
  
[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllText(@"Input/Day7.txt")
    let expected = 34852
    
    let actual = runForPart1 input 
    Assert.Equal(expected, actual) 

[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllText(@"Input/Day7.txt")
    let expected = Some 44282086
    
    let actual = runForPart2 input 
    Assert.Equal(expected, actual) 


[<Fact>]
let ``Example2`` () =
    let inputExample = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10"
    let x = [9;7;8;5;6]

    let map = inputExample.Split ','
                |> Seq.map int
                |> Seq.mapi (fun idx value -> (idx, value))
                |> Map.ofSeq
    let data = { IntCodes=map; Input=(Some 0); CurrentIndex=0; Output=None; State=Running}  
    let actual = feedback
                     (Processor {data with Input=Some x.[0]})
                     (Processor {data with Input=Some x.[1]})
                     (Processor {data with Input=Some x.[2]})
                     (Processor {data with Input=Some x.[3]})
                     (Processor {data with Input=Some x.[4]})
                     (Some 0)

    Assert.Equal(Some 18216,actual)

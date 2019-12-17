module Day15Tests

open Xunit
open AdventOfCode2019.Day15
open System.IO
open Xunit.Abstractions
  
type Day15Tests(output:ITestOutputHelper) =

    [<Fact>]
    member __.``Part1`` () =
        let input = File.ReadAllText(@"Input/Day15.txt")
        let expected = 300
        
        let (_,_,_,actual) = part1 input (fun _ _ _-> ())

        Assert.Equal(expected, actual) 

    [<Fact>]
    member __.``Part2`` () =
        let input = File.ReadAllText(@"Input/Day15.txt")
        let expected = 312
       
        let (_,_,_,actual) = part2 input (fun _ _ _-> ())

        Assert.Equal(expected, actual) 

module Day12Tests

open Xunit
open System.IO
open AdventOfCode2019.Day12



let day12Input = [InitPlanet {X= 3; Y= -6; Z= 6}; InitPlanet {X=10; Y= 7; Z= -9}; InitPlanet {X= -3; Y= -7; Z= 9}; InitPlanet {X= -8; Y= 0; Z= 4}]
    
[<Fact>]
let ``Example2`` () =
    let input = [InitPlanet {X= -1; Y= 0; Z= 2}; InitPlanet {X=2; Y= -10; Z= -7}; InitPlanet {X= 4; Y= -8; Z= 8}; InitPlanet {X= 3; Y= 5; Z= -1}]
    let result = part1 input 10
    let expected = 179
    Assert.Equal(expected, result) 

[<Fact>]
let ``Part1`` () =
    let result = part1 day12Input 1000
    let expected = 179
    Assert.Equal(expected, result) 


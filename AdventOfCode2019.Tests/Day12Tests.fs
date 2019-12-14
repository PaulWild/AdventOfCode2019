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
let ``Example5`` () =
    let input = [InitPlanet {X= -8; Y= -10; Z= 0}; InitPlanet {X=5; Y= 5; Z= 10}; InitPlanet {X= 2; Y= -7; Z= 3}; InitPlanet {X= 9; Y= -8; Z= -3}]
    let result = part1 input 100
    let expected = 1940
    Assert.Equal(expected, result) 


[<Fact>]
let ``Part1`` () =
    let result = part1 day12Input 1000
    let expected = 6849
    Assert.Equal(expected, result) 




[<Fact>]
let ``Part2`` () =
    let result = part2 day12Input
    let expected = 356658899375688L
    Assert.Equal(expected, result) 

[<Fact>]
let ``Example3`` () =
    let input =[InitPlanet {X= -1; Y= 0; Z= 2}; InitPlanet {X=2; Y= -10; Z= -7}; InitPlanet {X= 4; Y= -8; Z= 8}; InitPlanet {X= 3; Y= 5; Z= -1}]
    let result = part2 input 
    let expected = int64 2772
    Assert.Equal(expected, result) 


[<Fact>]
let ``Example6`` () =
    let input = [InitPlanet {X= -8; Y= -10; Z= 0}; InitPlanet {X=5; Y= 5; Z= 10}; InitPlanet {X= 2; Y= -7; Z= 3}; InitPlanet {X= 9; Y= -8; Z= -3}]
    let result = part2 input 
    let expected = 4686774924L
    Assert.Equal(expected, result) 

[<Fact>]
let ``tupleEqual`` () =
    let result = (1,2,2) = (1,2,2)
    let expected = true
    Assert.Equal(expected, result) 

module Day1Tests

open System
open Xunit
open AdventOfCode2019.Day1

[<Fact>]
let ``Example1`` () =
    let actual = fuelRequired 12.0
    Assert.Equal(2.0, actual) 
    
[<Fact>]
let ``Example2`` () =
    let actual = fuelRequired 14.0
    Assert.Equal(2.0, actual) 
 
[<Fact>]
let ``Example3`` () =
    let actual = fuelRequired 1969.0
    Assert.Equal(654.0, actual) 

        
[<Fact>]
let ``Example4`` () =
    let actual = fuelRequired 100756.0
    Assert.Equal(33583.0, actual) 


[<Fact>]
let ``Part1`` () =
    let actual = Part1
    Assert.Equal(3339288.0, actual)
    
 
[<Fact>]
let ``Part2.Example1`` () =
    let actual = fuelRequiredPart2 14.0 
    Assert.Equal(2.0, actual) 

        
[<Fact>]
let ``Part2.Example2`` () =
    let actual = fuelRequiredPart2 1969.0 
    Assert.Equal(966.0, actual) 

[<Fact>]
let ``Part2.Example3`` () =
    let actual = fuelRequiredPart2 100756.0 
    Assert.Equal(50346.0, actual)
    
[<Fact>]
let ``Part2`` () =
    let actual = Part2
    Assert.Equal(5006064.0, actual)

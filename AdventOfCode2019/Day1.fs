namespace AdventOfCode2019

open System
open System.IO

module Day1 =
   
    let lines = File.ReadLines(@"Input/Day1.txt")
    
    let fuelRequired mass =
        (mass / 3.0 |> Math.Floor) - 2.0

    let fuelRequiredPart2 mass =
        let rec fuelRequiredInternal mass total =
            let res = fuelRequired mass   
            if (res > 0.0) then fuelRequiredInternal res (res + total)
            else total
        fuelRequiredInternal mass 0.0 
                         
    let Part1 =
        Seq.map float lines
            |> Seq.map fuelRequired
            |> Seq.sum

    let Part2 =
        Seq.map float lines
            |> Seq.map fuelRequiredPart2
            |> Seq.sum


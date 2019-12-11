namespace AdventOfCode2019

open System.IO

module Day1 =
   
    let lines = File.ReadLines(@"Input/Day1.txt")
    
    let fuelRequired mass = mass / 3 - 2

    let fuelRequiredPart2 mass =
        let rec fuelRequiredInternal mass total =
            let res = fuelRequired mass   
            if (res > 0) then fuelRequiredInternal res (res + total)
            else total
        fuelRequiredInternal mass 0
        
    let run x = lines |> Seq.map int |> Seq.map x |> Seq.sum
    
    let Part1 = run fuelRequired
        
    let Part2 = run fuelRequiredPart2
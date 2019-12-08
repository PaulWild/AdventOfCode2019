namespace AdventOfCode2019

open System.IO
open AdventOfCode2019.IntCode

module Day2 =
                    
    let input = File.ReadAllText(@"Input/Day2.txt")

    let runForDay5 (input: string) inputValue = 
        let map = stringToMap input
        InitState map inputValue |> Processor
        
    let runFor (input: string)  noun verb =
        let map = stringToMap input
                    |> Map.add 1 noun
                    |> Map.add 2 verb
        InitState map None |> Processor
    let Part1 = runFor input 12 2 

    let Part2 =
        let rec tryFind (noun,verb) =
            let result = runFor input noun verb
            if result.IntCodes.[0] = 19690720 then (noun, verb) else            
                match (noun,verb) with
                | (99,99) -> failwith "couldn't find a result"
                | (_,99) -> tryFind (noun+1, 0)
                | (_,_)   -> tryFind (noun, verb+1)
        
        tryFind (0,0)
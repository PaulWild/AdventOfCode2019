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
                    |> Map.add 1L noun
                    |> Map.add 2L verb
        InitState map None |> Processor
    let Part1 = runFor input 12L 2L

    let Part2 =
        let rec tryFind (noun,verb) =
            let result = runFor input noun verb
            if result.IntCodes.[0L] = 19690720L then (noun, verb) else            
                match (noun,verb) with
                | (99L,99L) -> failwith "couldn't find a result"
                | (_,99L) -> tryFind (noun+1L, 0L)
                | (_,_)   -> tryFind (noun, verb+1L)
        
        tryFind (0L,0L)
namespace AdventOfCode2019

open AdventOfCode2019.IntCode

module Day5 =
    
    let runForDay5 (input: string) inputValue = 
        InitState (stringToMap input) inputValue |> Processor
        
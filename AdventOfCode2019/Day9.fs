namespace AdventOfCode2019

open System
open IntCode

module Day9 =

    let run (input: string) inputValue = 
        let map = stringToMap input
        InitState map inputValue |> Processor
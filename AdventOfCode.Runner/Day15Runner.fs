namespace AdventOfCodeRunner 

open AdventOfCode2019.Day15
open System
open System.Threading
open System.IO

module Day15Runner =

let SpaceToChar pos input = 
    let item = match input with
                | Space -> "."
                | Wall -> "\u2588"
                | Oxygen -> "o"

    Console.SetCursorPosition(int pos.X, int pos.Y)
    Console.Write (item)
   
 
let SpaceToCharOxy pos input = 
    match input with
    | Space -> 
                Console.SetCursorPosition(int pos.X, int pos.Y)
                Console.Write ("\u2588")
    | _ -> ()
     
let printer isOxygen position square  =

    if isOxygen then Console.ForegroundColor <- System.ConsoleColor.Blue
    let xOffset = 25L
    let yOffset = 25L
    let newPosition = { position with X=position.X + xOffset; Y =position.Y + yOffset}

    if not isOxygen then SpaceToChar newPosition square else SpaceToCharOxy newPosition square
    Thread.SpinWait 100000

let runner = 
    Console.Clear()
    Console.CursorVisible <- false
    
    let input = File.ReadAllText(@"Input/Day15.txt")
    part2 input (printer)
    
    Console.ForegroundColor <- System.ConsoleColor.White
    Console.CursorVisible <- true    
    Console.SetCursorPosition(1,1)
    System.Console.ReadKey() |> ignore
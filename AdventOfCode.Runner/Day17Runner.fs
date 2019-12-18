namespace AdventOfCodeRunner 

open AdventOfCode2019.Day17
open System
open System.Threading
open System.IO

module Day17Runner =

    let SpaceToChar input pos =
        let item = match input with 
                    | RobotUp -> "^"
                    | RobotDown -> "V"
                    | RobotLeft -> "<"
                    | RobotRight -> ">"
                    | RobotDeath -> "X"
                    | Space -> "."
                    | Scaffold -> "#"
                    | Unknown x -> Convert.ToChar(x).ToString()

        Console.SetCursorPosition(int pos.X, int pos.Y)
        Console.Write (item)
       
         
    let printer position square  =
        SpaceToChar position square

    let runner = 
        Console.Clear()
        Console.CursorVisible <- false
        
        let input = File.ReadAllText(@"Input/Day17.txt")
        part1 input printer
        
        Console.ForegroundColor <- System.ConsoleColor.White
        Console.CursorVisible <- true    
        Console.SetCursorPosition(1,1)
        System.Console.ReadKey() |> ignore
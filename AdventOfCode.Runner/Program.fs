// Learn more about F# at http://fsharp.org

open System
open System.IO
open System.Threading
open AdventOfCode2019.Day13
open AdventOfCode2019.IntCode

let tileToIcon tile =
    match tile with
    | Empty -> " "
    | Ball -> "o"
    | Paddle -> "="
    | Wall -> "\u2588"
    | Block -> "#"
    | Score(x) -> x.ToString()
    

let printer (x: Map<Pos,Tile>) =
    x |> Map.iter (fun pos tile ->
        let y = if (pos.X = -1L) then 22L else pos.Y + 1L
        let x = if (pos.X = -1L) then 3L else pos.X
        Console.CursorVisible <- false
        Console.SetCursorPosition(int x, int y)
        Console.Write (tileToIcon tile))
    Thread.SpinWait 100
    

[<EntryPoint>]
let main argv =
    let input = File.ReadAllText(@"Input/Day13.txt")
    let map = (stringToMap input) |> Map.add 0L 2L
    let data = InitState map None 
    play data Map.empty printer
    
    -1

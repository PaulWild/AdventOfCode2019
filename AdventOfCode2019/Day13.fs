namespace AdventOfCode2019

open System
open IntCode

module Day13 =
    type Pos = { X:int64; Y:int64 }
    
    type Tile = Empty | Wall | Block | Paddle | Ball | Score of int64
    
    type Pixel = {Position: Pos; Tile: Tile}
    
    let intToTile num =
        match num with
        | 0L -> Empty
        | 1L -> Wall
        | 2L -> Block
        | 3L -> Paddle
        | 4L -> Ball
        | x -> Score x 
    
    let rec chunk output res =
        match output with
        | tile :: y :: x :: xs -> chunk xs (({X=x; Y=y},intToTile tile) :: res)
        | _ -> res 
        
    let part1 input =
        let map = stringToMap input
        let data = InitState map None 
        
        let output = Processor data
        chunk output.Output List.empty |> List.filter (fun (pos,x) -> x = Block) |> List.length
        
    let rec play input theBoard =
        let output = Processor input
        let board = chunk output.Output List.empty 

        let newBoard = board  |> Map |> Map.fold (fun (agg: Map<Pos,Tile>) pos tile -> agg.Add(pos,tile))  theBoard

        let paddle = newBoard |> Map.toList |> List.find (fun (_,x) -> x = Paddle) |> fst
        let ball = newBoard |> Map.toList |> List.find (fun (_,x) -> x = Ball) |> fst
        let blockCount = newBoard |> Map.toList |> List.filter (fun (_,x) -> x = Block) |> List.length
        
        let newInput = if (ball.X < paddle.X) then {output with Input = Some -1L; Output = List.empty } else
                       if (ball.X > paddle.X) then {output with Input = Some 1L; Output = List.empty } else
                       {output with Input = Some 0L;  Output = List.empty }
  
        if blockCount = 0 then
            let score = board |> List.find (fun (_,x) -> match x with | Score(_) -> true | _ -> false) |> snd
            match score with
            | Score(x) -> x
            | _ -> -1L
        else
            play newInput newBoard
        

    let part2 input =
        let map = (stringToMap input) |> Map.add 0L 2L
        let data = InitState map None 
        play data Map.empty

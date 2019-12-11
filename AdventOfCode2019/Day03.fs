namespace AdventOfCode2019

open System.IO

module Day3 =           
    let input = File.ReadAllLines(@"Input/Day3.txt")

    type movement = Up | Down | Left | Right
    
    type Pos = { x: int; y: int }
    
    let toMovement (item: string) =
        let direction = item.Substring(0,1)
        let distance = int <| item.Substring(1, item.Length-1)
        
        match direction with
        | "U" -> [1..distance] |> List.map (fun _ -> Up)
        | "L" -> [1..distance] |> List.map (fun _ -> Left)
        | "R" -> [1..distance] |> List.map (fun _ -> Right)
        | "D" -> [1..distance] |> List.map (fun _ -> Down)
        | _ -> failwithf "unknown direction"
        
    let parseRow (row: string) =
        row.Split(",") |> Seq.map toMovement |> Seq.collect (fun x -> x) |> Seq.toList
        
    let addMove (movement: movement) (points: Pos list) =
        let current = points.Head
        let newPoint = match movement with
                        | Up -> {x=current.x; y=current.y+1}
                        | Left -> {x=current.x-1; y=current.y}
                        | Right -> {x=current.x+1; y=current.y}
                        | Down -> {x=current.x; y=current.y-1}
        newPoint :: points
        
    let rec calculatePoints (points: Pos list) (movementList: movement list)=
        let movement = movementList.Head
        let lines = addMove movement points
             
        match movementList with
                            | [] | [_] -> lines
                            | _ :: xs -> calculatePoints lines xs
    
    let manhattenDistance (p1: Pos) (p2: Pos) =
        let x = p1.x - p2.x
        let y = p1.y - p2.y
        
        abs x + abs y 
           
    let runFor (input: string list) =
        let lines = [{x=0;y=0}]
        
        let row1 = parseRow(input.[0]) |> calculatePoints lines |> set
        let row2 = parseRow(input.[1]) |> calculatePoints lines |> set
        
        Set.intersect row1 row2
            |> Set.filter (fun x-> x.x <> 0 && x.y <> 0)
            |> Set.map (fun x -> manhattenDistance {x=0; y=0} x)
            |> Set.minElement
        
    let Part1 = runFor <| Array.toList input
    
    let Part2 (input: string list) =
        let lines = [{x=0;y=0}]
        
        let row1 = parseRow(input.[0]) |> calculatePoints lines |> List.rev
        let row2 = parseRow(input.[1]) |> calculatePoints lines |> List.rev
             
        let intersections = Set.intersect (row1 |> set) (row2 |> set) |> Set.filter (fun x-> x.x <> 0 && x.y <> 0)
        let row =intersections |> Set.map (fun x-> (List.findIndex (fun y-> x.x = y.x && x.y = y.y) row2, List.findIndex (fun y-> x.x = y.x && x.y = y.y) row1)) |> Set.toList      
                
        row |> List.map (fun (x,y)-> x+y) |> List.min 

    
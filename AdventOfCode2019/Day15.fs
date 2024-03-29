namespace AdventOfCode2019

open IntCode

module Day15 =
    
    type Position = { X: int64; Y: int64 }
    
    type Direction = North | South | East | West 
    
    type Square = Space | Wall | Oxygen
    
    let dirToInt dir =
        match dir with
        | North -> 1L
        | South -> 2L
        | West -> 3L
        | East -> 4L
    
    let intToSquare value =
        match value with
        | 0L -> Wall
        | 1L -> Space
        | 2L -> Oxygen
        | _ -> failwithf "nope"

    let move pos dir =
        match dir with
        | North -> { pos with X= pos.X - 1L }
        | South -> { pos with X= pos.X + 1L }
        | East  -> { pos with Y= pos.Y + 1L }
        | West  -> { pos with Y= pos.Y - 1L }

    let rec randomWalk program (spaceMap: Map<Position,Square>) position direction printer=
        let potentialMove = move position direction
        
        if (spaceMap.ContainsKey(potentialMove)) then [None] //We have been here so remove this path
        else
            let inputedProrgram = { program with Input = Some(dirToInt direction) }
            let movedProgram = Processor inputedProrgram
            let newSquare = intToSquare movedProgram.Output.Head
            let newSpaceMap = spaceMap.Add(potentialMove, newSquare)
            
            printer potentialMove newSquare 

            match newSquare with
            | Wall -> [Some (position, inputedProrgram, false, inputedProrgram.Output.Length)]
            | Oxygen -> [Some (potentialMove, movedProgram, true, movedProgram.Output.Length)]
            | Space -> [randomWalk movedProgram newSpaceMap potentialMove North printer;
                            randomWalk movedProgram newSpaceMap potentialMove East printer;
                            randomWalk movedProgram newSpaceMap potentialMove South printer;
                            randomWalk movedProgram newSpaceMap potentialMove West printer] 
                        |> List.collect (fun x-> x)

    let part1 rawInput p  =
        let printer = p false
        let input = stringToMap rawInput
        let start = { X =0L; Y=0L }
        let spaceMap = [(start, Space)] |> Map.ofSeq
        let program = InitState input None
        
        let results = [randomWalk program spaceMap start North printer;
                         randomWalk program spaceMap start South printer;
                         randomWalk program spaceMap start East printer;
                         randomWalk program spaceMap start West printer] |> List.collect (fun x->x)
        results |> List.choose id |> List.filter (fun (_,_,isOxygen,_) -> isOxygen ) |> List.minBy (fun (_,_,_,dis) -> dis)


    let part2 rawInput p =
        let (pos,program,_,_) =part1 rawInput p 
        let printer = p true

        let spaceMap = [(pos, Oxygen)] |> Map.ofSeq
  
        let results = [randomWalk { program with Output=List.empty} spaceMap pos North printer;
                     randomWalk program spaceMap pos East printer;
                     randomWalk program spaceMap pos South printer;
                     randomWalk program spaceMap pos West printer] |> List.collect (fun x->x)
        results |> List.choose id |> List.maxBy (fun (_,_,_,dis) -> dis)



        
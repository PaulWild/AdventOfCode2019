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
    
    let go rawInput =
        
        let rec randomWalk program (spaceMap: Map<Position,Square>) position direction=
            let potentialMove = move position direction
            
            if (spaceMap.ContainsKey(potentialMove)) then None //We have been here so remove this path
            else
                let inputedProrgram = { program with Input = Some(dirToInt direction) }
                let movedProgram = Processor inputedProrgram
                let newSquare = intToSquare movedProgram.Output.Head
                let newSpaceMap = spaceMap.Add(potentialMove, newSquare)
                
                match newSquare with
                | Wall -> None
                | Oxygen -> Some (potentialMove, movedProgram, movedProgram.Output.Length)
                | Space ->
                            let lst = [randomWalk movedProgram newSpaceMap potentialMove North;
                                        randomWalk movedProgram newSpaceMap potentialMove East;
                                        randomWalk movedProgram newSpaceMap potentialMove South;
                                        randomWalk movedProgram newSpaceMap potentialMove West] |> List.choose id
                            if (List.isEmpty lst) then None else Some(List.minBy (fun (_,_,dis) -> dis) lst)
        
        let input = stringToMap rawInput
        let start = { X =0L; Y=0L }
        let spaceMap = [(start, Space)] |> Map.ofSeq
        let program = InitState input None
        
        [randomWalk program spaceMap start North;
         randomWalk program spaceMap start South;
         randomWalk program spaceMap start East;
         randomWalk program spaceMap start West] |> List.choose id |> List.minBy (fun (_,_,dis) -> dis)

        

    let go2 rawInput =
        let (oxygenPos,program,_) =go rawInput
        
        let rec randomWalk program (spaceMap: Map<Position,Square>) position direction=
            let potentialMove = move position direction
            
            if (spaceMap.ContainsKey(potentialMove)) then None //We have been here so remove this path
            else
                let inputedProrgram = { program with Input = Some(dirToInt direction) }
                let movedProgram = Processor inputedProrgram
                let newSquare = intToSquare movedProgram.Output.Head
                let newSpaceMap = spaceMap.Add(potentialMove, newSquare)
                
                match newSquare with
                | Wall -> Some (position, movedProgram.Output.Length-1) // dont move for a wall
                | Oxygen -> Some (potentialMove, movedProgram.Output.Length)
                | Space -> 
                            let lst = [randomWalk movedProgram newSpaceMap potentialMove North;
                                        randomWalk movedProgram newSpaceMap potentialMove East;
                                        randomWalk movedProgram newSpaceMap potentialMove South;
                                        randomWalk movedProgram newSpaceMap potentialMove West] |> List.choose id
                            if (List.isEmpty lst) then None else Some(List.maxBy (fun (_, dis) -> dis) lst)

        let spaceMap = [(oxygenPos, Oxygen)] |> Map.ofSeq
  
        let tmp = [randomWalk { program with Output=List.empty} spaceMap oxygenPos North;
                     randomWalk program spaceMap oxygenPos East;
                     randomWalk program spaceMap oxygenPos South;
                     randomWalk program spaceMap oxygenPos West]
        tmp |> List.choose id |> List.maxBy (fun (_,dis) -> dis)



        
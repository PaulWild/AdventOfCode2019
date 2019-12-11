namespace AdventOfCode2019

open IntCode

module Day11 =

    type Pos = { X: int; Y: int}

    type Colour = Black | White

    type Movement = | Up | Down | Left | Right

    type Turn = | L | R

    let getColourAtPos (map: Map<Pos,Colour>) pos =
        let hasValue = map.TryFind pos 
        match hasValue with
        | Some(x) -> x
        | None -> Black

    let setColourAtPos (map: Map<Pos,Colour>) pos colour =
        map.Add(pos, colour)

    let intToColour value = 
        match value with
        | 0L -> Black
        | 1L -> White
        | _ -> failwithf "nope" 

    let colourToInt value = 
        match value with
        | Black -> 0L
        | White -> 1L

    let intToTurn value =
        match value with
        | 0L -> L
        | 1L -> R
        | _ -> failwithf "nope" 

    let changeDirection currentDirection turn = 
        match turn with
        | L -> match currentDirection with
                    | Up -> Left
                    | Left -> Down
                    | Down -> Right
                    | Right -> Up
        | R -> match currentDirection with
                    | Up -> Right
                    | Right -> Down
                    | Down -> Left
                    | Left -> Up

    let move currentPos direction =
        match direction with 
        | Up -> {X=currentPos.X; Y= currentPos.Y - 1}
        | Down -> {X=currentPos.X; Y= currentPos.Y + 1}
        | Left -> {X=currentPos.X - 1 ; Y= currentPos.Y }
        | Right -> {X=currentPos.X + 1 ; Y= currentPos.Y }

    let processMove (data: Data) (paintedMap: Map<Pos,Colour>) pos currentDirection =
        let currentColour = getColourAtPos paintedMap pos
        let dataWithColour = Processor { data with Input = Some(colourToInt currentColour) } 

        let (dir,colour) = match dataWithColour.Output with
                                        | direction :: colour ::_ -> (intToTurn direction, intToColour colour)
                                        | _ -> failwithf "nope"

        let newMap = setColourAtPos paintedMap pos colour
        let newDirection = changeDirection currentDirection dir
        let newPos = move pos newDirection

        (dataWithColour, newMap, newPos, newDirection)


    let rec processMoves (data: Data) (paintedMap: Map<Pos,Colour>) pos currentDirection =
        let (dataWithColour, newMap, newPos, newDirection) = processMove data paintedMap pos currentDirection
        match dataWithColour.State with
        | Halted -> newMap 
        | _ -> processMoves dataWithColour newMap newPos newDirection

    let part1 input =
        let map = stringToMap input
        let data = InitState map None
        processMoves data Map.empty {X=0;Y=0} Up









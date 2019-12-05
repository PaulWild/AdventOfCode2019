namespace AdventOfCode2019

open System.IO

module Day2 =
    
    type Mode = | Pos | Im

    type Op = | Plus | Multiply | Set | Get | Halt | JumpTrue | JumpFalse | LessThan | Equals

    let plus x y = x + y
    
    let multiply  x y = x * y

    let lessThan x y = if x < y then 1 else 0 

    let equals x y = if x = y then 1 else 0
    
    let getAt (map: Map<int,int>) idx mode =
        match mode with 
        | Pos -> map.[map.[idx]]
        | Im -> map.[idx]

    let calculateItem (map: Map<int,int>) currentIndex operation =
        let (op, p1, p2, p3) = operation

        let x = getAt map (currentIndex + 1) p1
        let y = getAt map (currentIndex + 2) p2
        let pos = getAt map (currentIndex + 3) Im

        let result = op x y
        map.Add(pos, result)

    let setInput (map: Map<int, int>) currentIndex value =
        let setAt = map.[currentIndex + 1]
        match value with
        | Some x ->  map.Add(setAt, x)
        | None -> failwithf "no input value set doofus"

    let getOutput (map: Map<int, int>) currentIndex p1  =
        getAt map (currentIndex + 1) p1

    let toMode char = 
        match char with
        | '0' -> Pos
        | '1' -> Im
        | _ -> failwithf "not a mode type"

    let processCrazyIntCode number =
        let fullCode = number.ToString().PadLeft(5, '0')
        let op = match fullCode.[4] with
                    | '1' -> Plus
                    | '2' -> Multiply
                    | '3' -> Set
                    | '4' -> Get
                    | '5' -> JumpTrue
                    | '6' -> JumpFalse
                    | '7' -> LessThan
                    | '8' -> Equals
                    | '9' -> Halt
                    | _ -> failwithf "derp"

        let pos1 = toMode fullCode.[2]
        let pos2 = toMode fullCode.[1]
        let pos3 = toMode fullCode.[0]
        (op,pos1,pos2,pos3)
        
    let jumpTrue  (map: Map<int,int>) currentIndex modes = 
        let (m1 ,m2) = modes
        if (getAt map (currentIndex+1) m1) <> 0 then (getAt map (currentIndex+2) m2) else currentIndex + 3


    let jumpFalse (map: Map<int,int>) currentIndex modes = 
        let (m1, m2) = modes
        if (getAt map (currentIndex+1) m1) = 0 then (getAt map (currentIndex+2) m2) else currentIndex + 3

    let Processor inputValue input =             
        let rec run currentIndex output (map: Map<int,int>)    =

            let (opType, m1,m2,m3) = processCrazyIntCode map.[currentIndex]
            match opType with
            | Plus      -> run (currentIndex + 4) output <| calculateItem map currentIndex (plus, m1, m2 ,m3) 
            | Multiply  -> run (currentIndex + 4) output <| calculateItem map currentIndex (multiply, m1, m2, m3) 
            | Set       -> run (currentIndex + 2) output <| setInput map currentIndex inputValue
            | Get       -> run (currentIndex + 2) (Some (getOutput map currentIndex m1)) map 
            | LessThan  -> run (currentIndex + 4) output <| calculateItem map currentIndex (lessThan, m1, m2, m3) 
            | Equals    -> run (currentIndex + 4) output <| calculateItem map currentIndex (equals, m1, m2, m3)
            | JumpTrue  -> run (jumpTrue map currentIndex (m1,m2)) output map 
            | JumpFalse -> run (jumpFalse map currentIndex (m1,m2)) output map                   
            | Halt      -> match output with | Some x -> x | None ->  map.[0]

        run 0 None input 
                  
    let input = File.ReadAllText(@"Input/Day2.txt")

    let runForDay5 (input: string) inputValue = 
        input.Split ','
            |> Seq.map int
            |> Seq.mapi (fun idx value -> (idx, value))
            |> Map.ofSeq
            |> Processor inputValue

    let runFor (input: string)  noun verb =
        input.Split ','
            |> Seq.map int
            |> Seq.mapi (fun idx value -> (idx, value))
            |> Map.ofSeq
            |> Map.add 1 noun
            |> Map.add 2 verb
            |> Processor None
    
    let Part1 = runFor input 12 2 

    let Part2 =
        let rec tryFind (noun,verb) =
            let result = runFor input noun verb
            if result = 19690720 then (noun, verb) else            
                match (noun,verb) with
                | (99,99) -> failwith "couldn't find a result"
                | (_,99) -> tryFind (noun+1, 0)
                | (_,_)   -> tryFind (noun, verb+1)
        
        tryFind (0,0)
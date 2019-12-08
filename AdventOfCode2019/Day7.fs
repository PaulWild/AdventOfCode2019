namespace AdventOfCode2019

open Day2


module Day7 =
    let permutations (l: int list) = 
        let rec permInt (blah:int list*int list) =
            match blah with
            | (xs, []) -> [xs]
            | (xs, ys) ->
                 ys
                     |> List.map (fun x -> (x :: xs, List.filter (fun y -> x <> y) ys))
                     |> List.map (fun x -> permInt x)
                     |> List.collect (fun x -> x)              
                       
        permInt ([], l)

    let processForPhase (data: Data) phase input =
        let dp = { data with Input = Some phase } |> Processor
        { dp with Input = Some input; State=Running} |> Processor
        
    let rec run phases data input =
        match phases with
        | x :: xs ->
            let d = processForPhase data x input
            run xs data d.Output.Value
        | [] -> input        
        
    let runForDay7 (input: string) inputValue phases= 
        let map = input.Split ','
                    |> Seq.map int
                    |> Seq.mapi (fun idx value -> (idx, value))
                    |> Map.ofSeq
        run phases { IntCodes=map; Input=inputValue; CurrentIndex=0; Output=None; State=Running} 0 
     
    let runForPart1 (input: string) =
        let phases = [4;3;2;1;0] 
        let perm = permutations phases
        perm |> List.map (fun x -> runForDay7 input (Some 0) x) |> List.max
//
//        
//    let runForPart2 input =
//    
//        let phases = [9;8;7;6;5] 
//        let perm = permutations phases
//        perm |> List.map (fun x -> run x input 0) |> List.max
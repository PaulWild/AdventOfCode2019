namespace AdventOfCode2019

open IntCode

module Day7 =
    
    //NB this wont work when there are duplicates in the list 
    let permutations (l: int64 list) = 
        let rec permInt (blah:int64 list*int64 list) =
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
        
    let runForPart1 (input: string) =
        let phases = [4L;3L;2L;1L;0L] 
        let perm = permutations phases
        let map = stringToMap input
        let data = InitState map None
        
        perm |> List.map (fun x -> run x data 0L) |> List.max
        
    let rec feedback a1 a2 a3 a4 a5 input =
        let amp1 = Processor {a1 with Input = input }
        let amp2 = Processor {a2 with Input = amp1.Output } 
        let amp3 = Processor {a3 with Input = amp2.Output }
        let amp4 = Processor {a4 with Input = amp3.Output }
        let amp5 = Processor {a5 with Input = amp4.Output }
        
        match amp5.State with
        | Running | Input -> feedback amp1 amp2 amp3 amp4 amp5 amp5.Output
        | Halted -> amp5.Output

    let runForPart2 (input: string) =
        let phases = [9L;8L;7L;6L;5L]
        let perm = permutations phases
        let map = stringToMap input
        let data = InitState map (Some 0L)
        
        perm |> List.map (fun x -> feedback
                                    (Processor {data with Input=Some x.[0]})
                                    (Processor {data with Input=Some x.[1]})
                                    (Processor {data with Input=Some x.[2]})
                                    (Processor {data with Input=Some x.[3]})
                                    (Processor {data with Input=Some x.[4]})
                                    (Some 0L)) |> List.max

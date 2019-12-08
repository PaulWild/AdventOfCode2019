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
        let phases = [9;8;7;6;5]
        let perm = permutations phases
        let map = input.Split ','
                    |> Seq.map int
                    |> Seq.mapi (fun idx value -> (idx, value))
                    |> Map.ofSeq
        let data = { IntCodes=map; Input=(Some 0); CurrentIndex=0; Output=None; State=Running}  
        perm |> List.map (fun x -> feedback
                                    (Processor {data with Input=Some x.[0]})
                                    (Processor {data with Input=Some x.[1]})
                                    (Processor {data with Input=Some x.[2]})
                                    (Processor {data with Input=Some x.[3]})
                                    (Processor {data with Input=Some x.[4]})
                                    (Some 0)) |> List.max

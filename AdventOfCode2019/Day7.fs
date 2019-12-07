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

    let rec run phases program input =
        match phases with
        | x :: xs ->  run xs program (runForDay5 program <| Some [x; input])
        | [] -> input
        
    let runForPart1 input =
    
        let phases = [4;3;2;1;0] 
        let perm = permutations phases
        perm |> List.map (fun x -> run x input 0) |> List.max
        
        

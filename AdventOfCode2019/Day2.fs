namespace AdventOfCode2019

open System.IO

module Day2 =
    
    let calculateItem (map: Map<int,int>) currentIndex operation =
        let x = map.[currentIndex + 1]
        let y = map.[currentIndex + 2]
        let pos = map.[currentIndex + 3]

        let result = operation map.[x] map.[y] 
        map.Add(pos, result)

    let plus x y = x + y
    
    let multiply  x y = x * y
    
    let Processor input =             
        let rec run currentIndex (map: Map<int,int>)   =
            let newIndex = currentIndex + 4
            
            match map.[currentIndex] with
            | 1  -> run newIndex <| calculateItem map currentIndex plus 
            | 2  -> run newIndex <| calculateItem map currentIndex multiply                                       
            | 99 -> map
            | _  -> failwithf "unknown value"
            
        run 0 input |> Map.toList |> List.map (fun (_, value) -> value)
                  
    let input = File.ReadAllText(@"Input/Day2.txt")

    let runFor (input: string)  noun verb =
        input.Split ','
            |> Seq.map int
            |> Seq.mapi (fun idx value -> (idx, value))
            |> Map.ofSeq
            |> Map.add 1 noun
            |> Map.add 2 verb
            |> Processor
    
    let Part1 = runFor input 12 2

    let Part2 =
        let rec tryFind (noun,verb) =
            let result = runFor input noun verb
            if result.[0] = 19690720 then (noun, verb) else            
                match (noun,verb) with
                | (99,99) -> failwith "couldn't find a result"
                | (_,99) -> tryFind (noun+1, 0)
                | (_,_)   -> tryFind (noun, verb+1)
        
        tryFind (0,0)
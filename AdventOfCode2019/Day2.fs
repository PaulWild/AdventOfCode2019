namespace AdventOfCode2019

open System.IO

module Day2 =
    
    let Processor input =             
        let rec run (map: Map<int,int>) currentIndex  =
            match map.[currentIndex] with
            | 1 | 2 as op ->                    
                let x = map.[currentIndex + 1]
                let y = map.[currentIndex + 2]
                let pos = map.[currentIndex + 3]
                let newIndex = currentIndex + 4

                let result = if op = 1 then map.[x] + map.[y] else  map.[x] * map.[y] 
                let newMap = map.Add(pos, result)
                run newMap newIndex    
            | 99 -> map
            | _ -> failwithf "unknown value"
        
        let result = run input 0
        [0..result.Count-1] |> Seq.map (fun x-> result.[x])       
        
    let Part1 =
        let lines = File.ReadAllText(@"Input/Day2.txt")
        let input = lines.Split ','
                    |> Seq.map int
                    |> Seq.mapi (fun idx value -> (idx, value))
                    |> Map.ofSeq
                    |> Map.add 1 12
                    |> Map.add 2 2
                
        Processor input

    let Part2 =
        let lines = File.ReadAllText(@"Input/Day2.txt")
        
        let rec tryFind (noun,verb) =
            let input = lines.Split ','
                        |> Seq.map int
                        |> Seq.mapi (fun idx value -> (idx, value))
                        |> Map.ofSeq
                        |> Map.add 1 noun
                        |> Map.add 2 verb

            let result = Processor input |> Seq.toList
            
            if result.[0] = 19690720 then (noun, verb) else            
                match (noun,verb) with
                | (99,99) -> failwith "couldn't find a result"
                | (_, 99) -> tryFind (noun+1, 0)
                | (_,_)   -> tryFind (noun, verb+1)
        
        tryFind (0,0)
            

        


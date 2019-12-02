namespace AdventOfCode2019

open System
open System.IO

module Day2 =
    
    let Processor input =
             
        let rec run (map: Map<int,int>) (currentIndex:int) =
            let op = map.[currentIndex]

            if op = 1 then               
                let x = map.[currentIndex + 1]
                let y = map.[currentIndex + 2]
                let pos = map.[currentIndex + 3]
                let newIndex = currentIndex + 4

                let newMap = map.Add(pos, map.[x] + map.[y])
                run newMap newIndex 
            else if op = 2 then
                let x = map.[currentIndex + 1]
                let y = map.[currentIndex + 2]
                let pos = map.[currentIndex + 3]
                let newIndex = currentIndex + 4

                let newMap = map.Add(pos, map.[x] * map.[y])
                run newMap newIndex 
            else if op = 99 then
                map
            else
                failwithf "unknown value"
        
        let valueMap = Seq.mapi (fun idx value -> (idx, value)) input |> Map.ofSeq
        let result = run valueMap 0
        [0..result.Count-1] |> Seq.map (fun x-> result.[x])       
        
    let Part1 =
        let lines = File.ReadAllText(@"Input/Day2.txt")
        let input = lines.Split ','
                    |> Seq.map int
                    |> Seq.mapi (fun idx value -> if idx=1 then 12 else if idx=2 then 2 else value) 
        Processor input

    let Part2 =
        let lines = File.ReadAllText(@"Input/Day2.txt")
        
        let rec tryFind (noun,verb) =
            let input = lines.Split ','
                        |> Seq.map int
                        |> Seq.mapi (fun idx value -> if idx=1 then noun else if idx=2 then verb else value) 

            let result = Processor input |> Seq.toList
            
            if result.[0] = 19690720 then (noun, verb) else            
                match (noun,verb) with
                | (99,99) -> failwith "couldn't find a result"
                | (_, 99) -> tryFind (noun+1, 0)
                | (_,_)   -> tryFind (noun, verb+1)
        
        tryFind (0,0)
            

        


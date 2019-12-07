namespace AdventOfCode2019

open System.IO

module Day2 =
    let plus x y = x + y
    let multiply  x y = x * y
    let lessThan x y = if x < y then 1 else 0 
    let equals x y = if x = y then 1 else 0
    let charToInt c = int c - int '0'
    type Data = {
        Output: int Option;
        IntCodes: Map<int,int>;
        CurrentIndex: int;
        Input: int list Option;
    }
    
    let getAt data idx mode =
        match mode with 
        | 0 -> data.IntCodes.[data.IntCodes.[idx]]
        | 1 -> data.IntCodes.[idx]
        | _ -> failwithf "nope"
        
    let calculateItem data operation =
        let (op, p1, p2, _) = operation

        let x = getAt data (data.CurrentIndex + 1) p1
        let y = getAt data (data.CurrentIndex + 2) p2
        let pos = getAt data (data.CurrentIndex + 3) 1

        let result = op x y
        {data with
            IntCodes = data.IntCodes.Add(pos, result);
            CurrentIndex = data.CurrentIndex+4 }

    let setInput data =
        let setAt = data.IntCodes.[data.CurrentIndex + 1]
        match data.Input with
        | Some (x :: hs) ->  {data with
                                IntCodes = data.IntCodes.Add(setAt, x);
                                CurrentIndex = data.CurrentIndex+2
                                Input = Some hs }
        | None | Some []-> failwithf "no input value set doofus"

    let getOutput data p1  =
        {data with
                Output = getAt data (data.CurrentIndex + 1) p1 |> Some;
                CurrentIndex = data.CurrentIndex+2}

    let getModesAndOp data =
        let fullCode = data.IntCodes.[data.CurrentIndex].ToString().PadLeft(5, '0')
        let op = charToInt fullCode.[4]                 
        let pos1 = charToInt fullCode.[2]
        let pos2 = charToInt fullCode.[1]
        let pos3 = charToInt fullCode.[0]
        (op,pos1,pos2,pos3)
        
    let jumpTrue data modes = 
        let (m1 ,m2) = modes
        if (getAt data (data.CurrentIndex+1) m1) <> 0
            then { data with CurrentIndex = (getAt data (data.CurrentIndex+2) m2)}
            else { data with CurrentIndex = data.CurrentIndex+3}

    let jumpFalse data modes  = 
        let (m1, m2) = modes
        if (getAt data (data.CurrentIndex+1) m1) = 0
            then { data with CurrentIndex = (getAt data (data.CurrentIndex+2) m2)}
            else { data with CurrentIndex = data.CurrentIndex+3}

    let Processor data =             
        let rec run data =
            let (opType, m1,m2,m3) = getModesAndOp data
            match opType with
            | 1 -> run <| calculateItem data (plus, m1, m2 ,m3)
            | 2 -> run <| calculateItem data (multiply, m1, m2 ,m3)  
            | 3 -> run <| setInput data
            | 4 -> run <| getOutput data m1       
            | 5 -> run <| jumpTrue data (m1,m2) 
            | 6 -> run <| jumpFalse data (m1,m2)
            | 7 -> run <| calculateItem data (lessThan, m1, m2, m3) 
            | 8 -> run <| calculateItem data (equals, m1, m2, m3)
            | 9 -> match data.Output with | Some x -> x | None ->  data.IntCodes.[0]
            | _ -> failwithf "nope"

        run data 
                  
    let input = File.ReadAllText(@"Input/Day2.txt")

    let runForDay5 (input: string) inputValue = 
        let map = input.Split ','
                    |> Seq.map int
                    |> Seq.mapi (fun idx value -> (idx, value))
                    |> Map.ofSeq
        Processor { IntCodes=map; Input=inputValue; Output=None; CurrentIndex=0 }

    let runFor (input: string)  noun verb =
        let map = input.Split ','
                    |> Seq.map int
                    |> Seq.mapi (fun idx value -> (idx, value))
                    |> Map.ofSeq
                    |> Map.add 1 noun
                    |> Map.add 2 verb
        Processor { IntCodes=map; Input=None; Output=None; CurrentIndex=0 }
    
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
namespace AdventOfCode2019

module IntCode =

    let plus x y = x + y
    
    let multiply  x y = x * y
    
    let lessThan x y = if x < y then 1L else 0L 
    
    let equals x y = if x = y then 1L else 0L
    
    let charToInt c = int c - int '0'
    
    type state = Halted | Input | Running
    
    type Data = {
        State: state
        Input: int64 Option;
        Output: int64 Option;
        IntCodes: Map<int64,int64>;
        CurrentIndex: int64;
    }
    
    let getAt data idx mode =
        match mode with 
        | 0 -> data.IntCodes.[data.IntCodes.[idx]]
        | 1 -> data.IntCodes.[idx]
        | _ -> failwithf "nope"
        
    let calculateItem data operation =
        let (op, p1, p2, _) = operation

        let x = getAt data (data.CurrentIndex + 1L) p1
        let y = getAt data (data.CurrentIndex + 2L) p2
        let pos = getAt data (data.CurrentIndex + 3L) 1

        let result = op x y
        {data with
            IntCodes = data.IntCodes.Add(pos, result);
            CurrentIndex = data.CurrentIndex+4L }

    let setInput data =
        let setAt = data.IntCodes.[data.CurrentIndex + 1L]
        match data.Input with
        | Some(x) ->  {data with
                        IntCodes = data.IntCodes.Add(setAt, x);
                        CurrentIndex = data.CurrentIndex+2L
                        Input = None
                        State = Running }
        | None ->  {data with State = Input }

    let getOutput data p1  =
        {data with
                Output = getAt data (data.CurrentIndex + 1L) p1 |> Some;
                CurrentIndex = data.CurrentIndex+2L  }

    let getModesAndOp data =
        let fullCode = data.IntCodes.[data.CurrentIndex].ToString().PadLeft(5, '0')
        let op = charToInt fullCode.[4]                 
        let pos1 = charToInt fullCode.[2]
        let pos2 = charToInt fullCode.[1]
        let pos3 = charToInt fullCode.[0]
        (op,pos1,pos2,pos3)
        
    let jumpTrue data modes = 
        let (m1 ,m2) = modes
        if (getAt data (data.CurrentIndex+1L) m1) <> 0L
            then { data with CurrentIndex = (getAt data (data.CurrentIndex+2L) m2)}
            else { data with CurrentIndex = data.CurrentIndex+3L}

    let jumpFalse data modes  = 
        let (m1, m2) = modes
        if (getAt data (data.CurrentIndex+1L) m1) = 0L
            then { data with CurrentIndex = (getAt data (data.CurrentIndex+2L) m2)}
            else { data with CurrentIndex = data.CurrentIndex+3L}

    let Processor data =             
        let rec run data =
            
            let inputGen data =
                let d = setInput data
                match d.State with
                | Input | Halted -> d
                | Running -> run d 
            
            let (opType, m1,m2,m3) = getModesAndOp data
            match opType with
            | 1 -> run <| calculateItem data (plus, m1, m2 ,m3)
            | 2 -> run <| calculateItem data (multiply, m1, m2 ,m3)  
            | 3 -> inputGen data
            | 4 -> run <| getOutput data m1       
            | 5 -> run <| jumpTrue data (m1,m2) 
            | 6 -> run <| jumpFalse data (m1,m2)
            | 7 -> run <| calculateItem data (lessThan, m1, m2, m3) 
            | 8 -> run <| calculateItem data (equals, m1, m2, m3)
            | 9 -> { data with State=Halted }
            | _ -> failwithf "nope"

        run data
        
    let InitState map input =
        { IntCodes=map; Input=input; CurrentIndex=0L; State=Running; Output=None }

    let stringToMap (input: string) =
        input.Split ','
            |> Seq.map int64
            |> Seq.mapi (fun idx value -> (int64 idx, value))
            |> Map.ofSeq
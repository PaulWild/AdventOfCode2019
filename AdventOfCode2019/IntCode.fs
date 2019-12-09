namespace AdventOfCode2019

module IntCode =
    
    let charToInt c = int c - int '0'
    
    type state = Halted | Input | Running
    
    type Data = {
        State: state
        Input: int64 Option;
        Output: int64 List;
        IntCodes: Map<int64,int64>;
        CurrentIndex: int64;
        RelativeBase: int64;
    }
    
    let getInt data idx =
        let hasValue = data.IntCodes.TryFind idx 
        match hasValue with
        | Some(x) -> x
        | None -> 0L

    let getAt data idx mode =
        match mode with 
        | 0 -> getInt data (getInt data idx)
        | 1 -> getInt data idx
        | 2 -> getInt data (data.RelativeBase + getInt data idx)
        | _ -> failwithf "nope"

    let setAt data idx mode value = 
        match mode with 
        | 0 -> data.IntCodes.Add(getInt data idx, value)
        | 1 -> data.IntCodes.Add(getInt data idx, value)
        | 2 -> data.IntCodes.Add(data.RelativeBase + getInt data idx, value)
        | _ -> failwithf "nope"
        
    let calculateItem data operation =
        let (op, p1, p2, p3) = operation

        let x = getAt data (data.CurrentIndex + 1L) p1
        let y = getAt data (data.CurrentIndex + 2L) p2

        let result = op x y
        {data with
            IntCodes = setAt data (data.CurrentIndex + 3L) p3 result
            CurrentIndex = data.CurrentIndex+4L }

    let setInput data mode =
        match data.Input with
        | Some(x) ->  {data with
                        IntCodes = setAt data (data.CurrentIndex + 1L) mode x
                        CurrentIndex = data.CurrentIndex+2L
                        Input = None
                        State = Running }
        | None ->  {data with State = Input }

    let getOutput data p1  =
        let output = getAt data (data.CurrentIndex + 1L) p1
        {data with
                Output =  output :: data.Output;
                CurrentIndex = data.CurrentIndex+2L  }

    let getModesAndOp data =
        let fullCode = data.IntCodes.[data.CurrentIndex].ToString().PadLeft(5, '0')
        let op = fullCode.Substring(3) |> int            
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

    let updateRelativeBase data mode =
        let rel = getAt data (data.CurrentIndex+1L) mode
        { data with RelativeBase=data.RelativeBase+rel; CurrentIndex = data.CurrentIndex+2L}

    let RunCode data =             
        let (opType, m1,m2,m3) = getModesAndOp data
        match opType with
        | 1  -> calculateItem data ((fun x y -> x + y), m1, m2 ,m3)
        | 2  -> calculateItem data ((fun x y -> x * y), m1, m2 ,m3)  
        | 3  -> setInput data m1
        | 4  -> getOutput data m1       
        | 5  -> jumpTrue data (m1,m2) 
        | 6  -> jumpFalse data (m1,m2)
        | 7  -> calculateItem data ((fun x y -> if x < y then 1L else 0L), m1, m2, m3) 
        | 8  -> calculateItem data ((fun x y -> if x = y then 1L else 0L), m1, m2, m3)
        | 9  -> updateRelativeBase data m1
        | 99 -> { data with State=Halted }
        | _  -> failwithf "nope"
   
    let rec Processor data =
        let newData = RunCode data
        match newData.State with
        | Input | Halted -> newData
        | Running -> Processor newData
                
    let InitState map input =
        { IntCodes=map; Input=input; CurrentIndex=0L; State=Running; Output=List.empty; RelativeBase=0L }

    let stringToMap (input: string) =
        input.Split ','
            |> Seq.map int64
            |> Seq.mapi (fun idx value -> (int64 idx, value))
            |> Map.ofSeq
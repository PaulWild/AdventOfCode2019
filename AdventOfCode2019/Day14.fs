namespace AdventOfCode2019

open System
open FParsec

module Day14 =
    
    type El = { Num: int; Name: string }
    
    //going to have to break out my fparsec hammer for getting the input into a useable state    
    let sepChar = pstring ", "
    let el = manyChars letter   
    let element = pipe2 (pint32 .>> spaces1) el (fun x y -> {Num=x; Name=y})   
    let equalsSign = pstring " => "  
    let row = sepBy element sepChar .>> equalsSign .>>. element |>> (fun (els,el) -> (el,els))
    let rows = sepBy row newline
    let getInput input =
        let res = run rows input
        match res with
        | Success(x,_,_) -> x
        | _ -> failwithf "nope"
    
    let wasteManagement item (wmMap: Map<string,int>) =
        let wm = if (wmMap.ContainsKey item.Name) then wmMap else wmMap.Add(item.Name, 0) 
        (wm.Item item.Name - item.Num, wm.Add(item.Name, wm.Item item.Name - item.Num))

    let defaultAdd (map: Map<'a,int>) item value =
        let wm = if (map.ContainsKey item) then map else map.Add(item, 0) 
        wm.Add(item, wm.Item item + value)
    
    let defaultGet (map: Map<'a,int>) item =
         match map.TryFind item with | Some(x) -> x | None -> 0 
        
    let rec reduceElements (el: El) elList (haves: Map<string,int>) (haveNots: Map<string,int>) =
        if el.Name = "ORE" then
            ([el], haves, haveNots)
        else 
            let (item,items) = elList |> List.find (fun (x,_) -> x.Name = el.Name)
            let havesNots2 = defaultAdd haveNots el.Name el.Num 
                        
            let multiplier = int(Math.Ceiling((float)((defaultGet havesNots2 el.Name) - (defaultGet haves el.Name)) / (float)item.Num))
          
            let newItems = items |> List.map (fun x -> {x with Num = x.Num * multiplier})
            
            let (a,nh,nhn) = newItems |> List.fold (fun (xs,h,hn) curr ->
                                    let newxs, nh, nhn = reduceElements curr elList h hn
                                    (newxs |> List.append xs, nh, nhn)) (List.empty, haves, havesNots2)
            
            let nh2 = defaultAdd nh item.Name (item.Num * multiplier)
            (a,nh2,nhn)

                                    
    let  reduce (items: (El*El list) list) =
        let fuel = items |> List.find (fun (x,_) -> x.Name = "FUEL") |> fst
        let (els, nh, nhn) = reduceElements fuel items Map.empty Map.empty
        els |> List.sumBy (fun x -> x.Num) 
   
        
        
        
        
    
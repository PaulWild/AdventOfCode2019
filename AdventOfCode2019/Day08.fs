namespace AdventOfCode2019
open System

module Day8 =
    
    let getCount input char =
        let res = input |> Seq.countBy id
                        |> Seq.filter (fun (x,_) -> x=char)
                        |> Seq.map(fun (_,y) -> y)
                        |> Seq.tryExactlyOne
        match res with
        | Some(x) -> x
        | None -> 0
                  
    let part1 input layerSize =
        Seq.chunkBySize layerSize input
            |> Seq.map (fun x -> (getCount x '0', getCount x '1' * getCount x '2'))
            |> Seq.minBy (fun (x,_) -> x)
            |> snd 
    
    let choose lft rgt =
        if (lft='2') then rgt else lft
        
    let chooseSeq lft rgt =
        Array.zip lft rgt |> Array.map (fun (x,y) -> choose x y)
        
    let part2 input length width =
        Seq.chunkBySize (length * width) input
                    |> Seq.reduceBack (fun x y -> chooseSeq x y)
                    |> Seq.map (fun x -> if x = '0' then ' ' else '#')
                    |> Seq.toArray
                    |> System.String

        
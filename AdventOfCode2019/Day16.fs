namespace AdventOfCode2019

open System
open Xunit.Abstractions

module Day16 =
    
    let charToInt c = int c - int '0'
    
    let lastInt itm = Math.Abs (itm % 10) 
    
    let basePattern = [0; 1; 0; -1]
    
    let duplicateItems tms inputLength  =
        let repeat = (inputLength / (basePattern.Length * tms)) 
        let pattern = [0..repeat] |> List.map (fun _ -> basePattern) |> List.collect (fun x -> x)
        
        pattern |> List.map (fun x -> List.replicate tms x) |> List.collect (fun x -> x) |> List.tail 
    
    let multiply (input: int list) (multiplier: int list) =
        Seq.zip input multiplier |> Seq.map (fun (x,y) -> x * y) |> Seq.sum |> lastInt  
       
    let fft (input: int List) (patterns: int List List) =
        input
            |> List.mapi (fun idx _ ->  multiply input patterns.[idx])



    
    let part1 (input: string) phases (outputHelper: ITestOutputHelper) =
        let patterns = [0..input.Length] |> List.mapi (fun _ idx -> duplicateItems (idx+1) input.Length) |> List.map (fun x -> List.take input.Length x)
               
        let inputAsInts = input |> Seq.map (fun x -> charToInt x) |> Seq.toList
 
        let result = [1..phases] |> List.fold (fun acc x ->
            outputHelper.WriteLine(x.ToString())
            fft acc patterns) (inputAsInts)
        result |> Seq.map (fun x -> x.ToString()) |> String.Concat 


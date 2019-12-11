namespace AdventOfCode2019

module Day4 =     
    let hasSingleDoubleDigit chars =
        chars |> Seq.countBy id |> Seq.exists (fun (_,cnt) -> cnt = 2)
   
    let rec hasIncreasingNumbers chars =
        chars |> Seq.pairwise |> Seq.forall (fun (fst,snd) -> fst <= snd)
        
    let rec hasDoubleDigit chars =      
        chars |> Seq.countBy id |> Seq.exists (fun (_,cnt) -> cnt >= 2)

    let Part1 start stop = 
        [start..stop]
            |> Seq.map (fun x -> x.ToString())
            |> Seq.map Seq.toList
            |> Seq.filter hasIncreasingNumbers
            |> Seq.filter hasDoubleDigit
            |> Seq.length

    let Part2 start stop =  
        [start..stop]
            |> Seq.map (fun x -> x.ToString())
            |> Seq.map Seq.toList
            |> Seq.filter hasIncreasingNumbers
            |> Seq.filter hasDoubleDigit
            |> Seq.filter hasSingleDoubleDigit 
            |> Seq.length
namespace AdventOfCode2019

module Day4 =
    let isDoubleDigit first second =
        if first = second then true else false

    let isIncreasing first second =
        if first <= second then true else false

    let oddNumber number = number % 2 <> 0 && number > 0
    
    type digitType = Single | Double | Multi | ParDouble

    let isSingleDoubleDigit first second prev =
        let dd = if first = second then true else false

        match prev with 
        | Single -> if dd then ParDouble else Single
        | ParDouble -> if dd then Multi else Double
        | Double -> if dd then Multi else Double
        | Multi -> if dd then Multi else if not dd then Single else Double

    let rec hasSingleDoubleDigit currentDigit chars =       
        match chars with 
        | fst :: snd :: rest -> 
            let digit = isSingleDoubleDigit fst snd currentDigit 
            if digit = Double then true else hasSingleDoubleDigit digit (snd :: rest)  
        | [_] | [] -> if currentDigit = ParDouble then true else false
              
    let rec hasIncreasingNumbers chars =      
        match chars with 
            | fst :: snd :: rest -> if isIncreasing fst snd then hasIncreasingNumbers (snd :: rest) else false 
            | [_] | [] -> true

    let rec hasDoubleDigit chars =      
        match chars with 
            | fst :: snd :: rest -> if isDoubleDigit fst snd then true else hasDoubleDigit (snd :: rest) 
            | [_] | [] -> false

    let processNumber (number: int) =
        let chars = number.ToString() |> Seq.toList
        chars |> hasIncreasingNumbers && chars |> hasDoubleDigit 

    let processPart2 (number: int) =
        let chars = number.ToString() |> Seq.toList
        chars |> hasIncreasingNumbers && chars |> hasDoubleDigit && chars |> hasSingleDoubleDigit Single
         
    let Part1 start stop = 
        let result = [start..stop] |> Seq.filter processNumber
        result|> Seq.length

    let Part2 start stop = 
        let result = [start..stop] |> Seq.filter processPart2 |> Seq.toList
        result |> Seq.length
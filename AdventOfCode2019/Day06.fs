namespace AdventOfCode2019

module Day6 =
    type Tree = Map<string,string>

    let countParent (map: Tree) str =
        let rec countInt str tally =
            match map.TryFind str with 
            | Some x ->  countInt x (tally + 1)
            | None -> tally
        countInt str 0 
    
    let countParents (map: Tree) =
        map |> Map.toSeq |> Seq.map fst |> Seq.fold (fun acc el -> acc + countParent map el) 0 

    let getPath (map: Tree) str =
        let rec countInt str path =
            match map.TryFind str with 
            | Some x ->  countInt x (x :: path)
            | None -> path
        countInt str []

    let part2 (map: Tree) =
        let you = getPath map "YOU" |> set
        let san = getPath map "SAN" |> set

        let res = Set.intersect you san |> Set.count
        (you |> Set.count) + (san |> Set.count) - (res *2)



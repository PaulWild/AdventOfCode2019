namespace AdventOfCode2019

open System

module Day10 =
    type Vector = { X: int; Y: int}

    let dotProduct fst snd = 
        (fst.X * snd.X)  + (fst.Y * snd.Y)
        
    let relativeVecor fst snd =
        { X = (snd.X - fst.X); Y = (snd.Y - fst.Y) }

    let magnitude vector =
        Math.Sqrt(float ((vector.X*vector.X) + (vector.Y*vector.Y)))

    let norm fst snd =
        let sndRel = relativeVecor fst snd
        let fstRel = { X = 0; Y = -1}

        let mag = magnitude fstRel * magnitude sndRel
        let dp = (float) (dotProduct fstRel sndRel)
        let res = Math.Acos(dp/mag)

        let ang = if (sndRel.X < 0) then (Math.PI * 2.0) - res else res
        (int)(ang * 100000000.0)
     
    let rowToGrid x row  =
        row |> List.mapi (fun idx chr -> if chr = '#' then Some({X=idx; Y=x}) else None) |> List.choose id

    let rowsToGrid rows =
        rows |> List.mapi (fun idx row -> rowToGrid idx row) |> List.collect (fun x -> x)

    let manhattenDistance p1 p2 =
            let x = p1.X - p2.X
            let y = p1.Y - p2.Y
                      
            abs x + abs y 

    let getAngle vector vectors =
        let intermedita = vectors |> List.filter (fun x-> (x <>  vector)) 
        intermedita |> List.map (fun x-> (norm vector x, manhattenDistance x vector, x)) 

    let getAngles vectors =
        let results = vectors |> List.map (fun x -> (x, getAngle x vectors |> List.countBy (fun (ang,_,_) -> ang) |> List.length)) 
        results |> List.maxBy (fun (_,cnt) -> cnt)
            
    let part1 input =
        let rows = input |> List.map (fun x-> Seq.toList x)
        rowsToGrid rows |> getAngles

    let getAt (items: (int*int*Vector) list) spot =
        let rec getAtInt items currentAngle curr =
            let sorted = items|> List.sortBy (fun (ang,dist,_) -> ang,dist)
            let hmm = sorted |> List.filter (fun (ang,_,_) -> ang>currentAngle)

            if (hmm.IsEmpty) then getAtInt sorted -1 curr else
                if (curr = spot) then hmm.Head else
                    let (ang,_,_) = hmm.Head
                    getAtInt hmm.Tail ang (curr+1)
        
        getAtInt items -1 1


    let part2 input spot =
        let rows = input |> List.map (fun x-> Seq.toList x) |> rowsToGrid 
        let (station,_) = part1 input

        let items = getAngle station rows 
        let (ang,dis,vec) = getAt items spot
        (vec.X*100)+vec.Y

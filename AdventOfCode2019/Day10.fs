namespace AdventOfCode2019

open System

module Day10 =
    type Vector = { X: int; Y: int}

    let dotProduct fst snd = 
        (fst.X * snd.X)  + (fst.Y * snd.Y)
        
    let relativeVector fst snd =
        { X = (snd.X - fst.X); Y = (snd.Y - fst.Y) }

    let magnitude vector =
        Math.Sqrt(float ((vector.X*vector.X) + (vector.Y*vector.Y)))

    let clockAngle fst snd =
        let sndRel = relativeVector fst snd
        let fstRel = { X = 0; Y = -1}

        let mag = magnitude fstRel * magnitude sndRel
        let dp = (float) (dotProduct fstRel sndRel)
        let res = Math.Acos(dp/mag)

        let ang = if (sndRel.X < 0) then (Math.PI * 2.0) - res else res
        (int)(ang * 100000000.0) //god damn floating points
     
    let rowToGrid x row  =
        row |> List.mapi (fun idx chr -> if chr = '#' then Some({X=idx; Y=x}) else None)
            |> List.choose id

    let rowsToGrid rows =
        rows |> List.mapi (fun idx row -> rowToGrid idx row)
             |> List.collect (fun x -> x)

    let manhattenDistance p1 p2 =
            let x = p1.X - p2.X
            let y = p1.Y - p2.Y
                      
            abs x + abs y 

    let getAngle vector vectors =
        vectors |> List.filter (fun x-> (x <>  vector)) 
                |> List.map (fun x-> (clockAngle vector x, manhattenDistance x vector, x)) 

    let getAngles vectors =
        vectors
            |> List.map (fun x -> (x, getAngle x vectors |> List.countBy (fun (ang,_,_) -> ang) |> List.length)) 
            |> List.maxBy (fun (_,cnt) -> cnt)
            
    let part1 input =
        let rows = input |> List.map (fun x-> Seq.toList x)
        rowsToGrid rows |> getAngles

    let destroyAsteroids items spot =
        let rec destroyAsteroid items currentAngle curr =
            let sorted = items |> List.sortBy (fun (ang,dist,_) -> ang,dist)
            let next = sorted |> List.filter (fun (ang,_,_) -> ang>currentAngle)

            match next with
            | [] -> destroyAsteroid sorted -1 curr 
            | (ang,_,_) :: xs when curr <> spot ->  destroyAsteroid xs ang (curr+1)
            | x :: _ -> x
            
        destroyAsteroid items -1 1

    let part2 input destroyedNumber =
        let rows = input |> List.map (fun x-> Seq.toList x) |> rowsToGrid 
        let (station,_) = part1 input

        let items = getAngle station rows 
        let (_,_,vec) = destroyAsteroids items destroyedNumber
        (vec.X*100)+vec.Y
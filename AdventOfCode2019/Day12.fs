namespace AdventOfCode2019

open System



module Day12 = 
    type Pos = { X: int; Y: int;  Z:int }
    type Velocity ={ vX: int; vY: int;  vZ:int }
    type Planet = { Position: Pos; Velocity: Velocity  }
    
    let InitPlanet pos =
        { Position = pos; Velocity = {vX=0; vY=0; vZ=0} }
        
    let calculateNewVelocity y x =
        if y > x then 1 else
        if y < x then -1 else
        0
    
    let calculateVelocity (planet: Planet) (planets: Planet list) =               
        planets |> List.fold (fun agg curr ->
            {agg with X=agg.X + calculateNewVelocity curr.Position.X planet.Position.X
                        Y=agg.Y + calculateNewVelocity curr.Position.Y planet.Position.Y
                        Z=agg.Z + calculateNewVelocity curr.Position.Z planet.Position.Z}) {X=0; Y=0; Z=0}
    
    let calculateVelocities (planets: Planet List) =
        planets |> List.map (fun x ->
            let y = calculateVelocity x planets
            {x with  Velocity = {vX = x.Velocity.vX + y.X; vY =  x.Velocity.vY + y.Y; vZ =  x.Velocity.vZ + y.Z;  }})
        |> List.map (fun x -> {x with Position = {X = x.Position.X + x.Velocity.vX; Y = x.Position.Y + x.Velocity.vY; Z = x.Position.Z + x.Velocity.vZ; }})
        

    let rec runFor planets runCount =
        if runCount = 0 then planets else
            runFor (calculateVelocities planets) (runCount-1)
            
    let part1 planets runCount =
        runFor planets runCount
        |> List.map (fun x ->
            (Math.Abs(x.Position.X) + Math.Abs(x.Position.Y) + Math.Abs(x.Position.Z)) *
                (Math.Abs(x.Velocity.vX) + Math.Abs(x.Velocity.vY) + Math.Abs(x.Velocity.vZ)))
        |> List.sum
        
        
    let rec gcd fst  snd =
        if fst < snd then gcd snd fst
        else if fst % snd = 0 then snd
        else gcd snd (fst % snd)
        
    let lcd (numbers: int list)=
        let g = numbers |> List.reduce (fun agg curr -> gcd agg curr)
        let m = numbers |> List.reduce (fun agg curr -> agg * curr) 
        m/g
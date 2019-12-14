namespace AdventOfCode2019

open System



module Day12 = 
    type Pos = { X: int; Y: int;  Z:int }
    type Velocity ={ vX: int; vY: int;  vZ:int }
    type Planet = { Position: Pos; Velocity: Velocity  }
    type LoopResult = { StartPos: (int*int*int*int*int*int*int*int); HasLooped:bool; count:int; }
     
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

    let getPos planet =
        (planet.Position.X, planet.Position.Y, planet.Position.Z,planet.Velocity.vX,planet.Velocity.vY,planet.Velocity.vZ)
        
    let eurgh (planets: Planet list) xyz =
        let (x,y,z) = xyz
        let (X1,Y1,Z1,vX1,vY1,vZ1) = getPos (planets.[0])
        let (X2,Y2,Z2,vX2,vY2,vZ2) = getPos (planets.[1])
        let (X3,Y3,Z3,vX3,vY3,vZ3) = getPos (planets.[2])
        let (X4,Y4,Z4,vX4,vY4,vZ4) = getPos (planets.[3])
        let xn = if (not x.HasLooped) && x.StartPos = (X1,vX1,X2,vX2,X3,vX3,X4,vX4) then {x with HasLooped = true; count = x.count+1}
                    else if not x.HasLooped then { x with count = x.count+1;}
                    else x
        let yn = if (not y.HasLooped) && y.StartPos = (Y1,vY1,Y2,vY2,Y3,vY3,Y4,vY4) then {y with HasLooped = true; count = y.count+1}
                    else if not y.HasLooped then { y with count = y.count+1;}
                    else y
        let zn = if (not z.HasLooped) && z.StartPos = (Z1,vZ1,Z2,vZ2,Z3,vZ3,Z4,vZ4) then {z with HasLooped = true; count = z.count+1}
                    else if not z.HasLooped then { z with count = z.count+1;}
                    else z
        (xn,yn,zn)
        
    //fuck it there is four not going to make it generic, just want it done
    let rec runUntilLooped planets p1  =
        let pl = calculateVelocities planets
        
        let (p1nx,p1ny,p1nz) = eurgh pl p1
        
        if (p1nx.HasLooped && p1ny.HasLooped && p1nz.HasLooped) then
            (p1nx,p1ny,p1nz)
        else
            runUntilLooped pl (p1nx,p1ny,p1nz)
        
    let part1 planets runCount =
        runFor planets runCount
        |> List.map (fun x ->
            (Math.Abs(x.Position.X) + Math.Abs(x.Position.Y) + Math.Abs(x.Position.Z)) *
                (Math.Abs(x.Velocity.vX) + Math.Abs(x.Velocity.vY) + Math.Abs(x.Velocity.vZ)))
        |> List.sum
        
        
    let rec gcd (fst: int64)  (snd: int64) =
        if fst < snd then gcd snd fst
        else if fst % snd = (int64 0) then snd
        else gcd snd (fst % snd)
        
    let lcd (numbers: int64 list)=
        let lcdInt (n1:int64) (n2: int64) =
            (n1*n2)/(gcd n1 n2)
        numbers |> List.reduce (fun agg curr -> lcdInt agg curr)
        
    
    let initResult (planets: Planet list) =
        
        let (X1,Y1,Z1,vX1,vY1,vZ1) = getPos (planets.[0])
        let (X2,Y2,Z2,vX2,vY2,vZ2) = getPos (planets.[1])
        let (X3,Y3,Z3,vX3,vY3,vZ3) = getPos (planets.[2])
        let (X4,Y4,Z4,vX4,vY4,vZ4) = getPos (planets.[3])
        ({ StartPos=(X1,vX1,X2,vX2,X3,vX3,X4,vX4); HasLooped=false; count=0; },
         { StartPos=(Y1,vY1,Y2,vY2,Y3,vY3,Y4,vY4); HasLooped=false; count=0; },
         { StartPos=(Z1,vZ1,Z2,vZ2,Z3,vZ3,Z4,vZ4); HasLooped=false; count=0; })
        
    let part2 planets =
        let ((p1x,p1y,p1z)) = runUntilLooped planets (initResult planets)
        lcd [int64 p1x.count;int64 p1y.count;int64 p1z.count]
 

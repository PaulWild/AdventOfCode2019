module Day10Tests

open Xunit
open System.IO
open AdventOfCode2019.Day10

[<Fact>]
let ``Part1`` () =
    let input = File.ReadAllLines(@"Input/Day10.txt") |> Array.toList
    let (_,cnt) = part1 input
    let expected = 276
    Assert.Equal(expected, cnt) 

[<Fact>]
let ``Part2`` () =
    let input = File.ReadAllLines(@"Input/Day10.txt") |> Array.toList
    let res = part2 input 200
    let expected = 1321
    Assert.Equal(expected, res) 
 
[<Fact>]
let ``Example1`` () =
    let input = [".#..#";".....";"#####";"....#";"...##"]

    let (_,cnt) = part1 input
    let expected = 8
    Assert.Equal(expected, cnt) 

    
[<Fact>]
let ``Example2`` () =
    let input = ["......#.#.";"#..#.#....";"..#######.";".#.#.###..";".#..#.....";"..#....#.#";"#..#....#.";".##.#..###";"##...#..#.";    ".#....####"]
    
    let (_,cnt) = part1 input
    let expected = 33
    Assert.Equal(expected, cnt)

[<Fact>]
let ``Example3`` () =
    let input = [".#....#####...#..";"##...##.#####..##";"##...#...#.#####.";"..#.....#...###..";"..#.#.....#....##"]
        
    let res = part2 input 5
    let expected = 902
    Assert.Equal(expected, res)

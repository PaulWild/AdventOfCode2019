module Day8Tests

open Xunit
open AdventOfCode2019.Day8
open System.IO
  

[<Fact>]
let ``Example1`` () =
    let inputExample = "123456722012"
    let actual = part1 inputExample 6
    
    Assert.Equal(1,actual)

[<Fact>]
let ``Example2`` () =
    let inputExample = "0222112222120000"
    let actual = part2 inputExample 2 2
    
    Assert.Equal(" #" +
                 "# "
                  ,actual)

[<Fact>]
let ``Part2`` () =
    let inputExample = File.ReadAllText("Input/Day8.txt")
    let actual = part2 inputExample 25 6
    
    Assert.Equal("#  #  ##   ##  #### #### " +
                 "#  # #  # #  # #    #    " +
                 "#### #    #    ###  ###  " +
                 "#  # #    # ## #    #    " +
                 "#  # #  # #  # #    #    " +
                 "#  #  ##   ### #    #### ",actual)

[<Fact>]
let ``Part1`` () =
    let inputExample = File.ReadAllText("Input/Day8.txt")
    let actual = part1 inputExample (25 * 6)
    
    Assert.Equal(1703,actual)

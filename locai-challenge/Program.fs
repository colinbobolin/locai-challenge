open System
open LocaiChallenge
open LocaiChallenge.Benchmark

// Please write a program that generates a list of 10,000 numbers in random order each time it is
// run. Each number in the list must be unique and be between 1 and 10,000 (inclusive).
// The most important success factor is to produce the best solution you can to solve the problem.
// There are many aspects to consider within that context – efficiency, performance,
// documentation, etc.

let PositiveOrNone n =
    match n with
    | x when x > 0 -> Some n
    | _ -> None

[<EntryPoint>]
/// argv.[0] represents the size of the random list, defaults to 10,000
/// argv.[1] represents the number of times run benchmark, defaults to 100,000
let main argv =
    let n =
        Array.tryHead argv
        |> Option.map int
        |> Option.bind PositiveOrNone
        |> Option.defaultValue 10_000

    let nTimes =
        Array.tryItem 1 argv
        |> Option.map int
        |> Option.bind PositiveOrNone
        |> Option.defaultValue 100_000

    printfn "Beginning benchmark for n=%i and number of runs=%i" n nTimes

    //run benchmark
    n |> Array.initRandom |> Benchmark nTimes

    //create the random array
    let arr = Array.initRandom n
    printfn "%A" arr

    //print the tail
    Array.Reverse arr
    printfn "REVERSED"
    printfn "%A" arr

    0

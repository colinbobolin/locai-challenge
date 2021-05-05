module Tests

open System
open Xunit
open LocaiChallenge

let n = 10_000
let minBound = 1
let maxBound = 10_000

[<Fact>]
let ``test all values unique`` () =
    let actual =
        Array.initRandom n
        |> Array.distinct
        |> Array.length

    Assert.Equal(n, actual)

[<Fact>]
let ``test size is 10,000`` () =
    let actual = Array.initRandom n |> Array.length

    Assert.Equal(n, actual)

[<Fact>]
let ``test max <= 10_000`` () =
    let numbers = Array.initRandom n
    let actualMax = numbers |> Array.max
    Assert.True(actualMax <= maxBound)

[<Fact>]
let ``test min >= 1`` () =
    let numbers = Array.initRandom n
    let min = numbers |> Array.min
    Assert.True(min >= minBound)

[<Fact>]
let ``test sort algorithm is random - standard deviation of multiple runs is less than 5`` () =
    // create a sequence of our randomized arrays
    // calculate the average, then the standard deviation of the averages
    // if the arrays are truly randomized, this will have a very low standard deviation
    // 5 is an arbitrary upper-bound, but represents a significantly low standard deviation
    let nOfRandomArrays = 100
    let arraySize = 1_000

    let stdDevArr arr =
        let avg = Array.average arr

        Array.fold (fun acc elem -> acc + (float elem - avg) ** 2.0) 0.0 arr
        / float arr.Length
        |> sqrt

    let stdDev =
        seq { 1 .. nOfRandomArrays }
        |> Seq.map (fun _ -> Array.initRandom arraySize)
        |> Seq.fold (fun acc ele -> Array.map2 (+) acc ele) (Array.zeroCreate arraySize)
        |> Array.map (fun ele -> float ele / (float arraySize))
        |> stdDevArr

    Assert.True(stdDev < 5.)

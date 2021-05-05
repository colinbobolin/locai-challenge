namespace LocaiChallenge

module Array =

    /// Shuffles the array using the
    /// <a href="https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle">Fisher-Yates shuffle algorithm</a>
    let shuffle (arr: array<int>) =
        let rand = System.Random()

        for i in 0 .. (arr.Length - 2) do
            let j = rand.Next(i, arr.Length)
            let temp = arr.[i]
            arr.[i] <- arr.[j]
            arr.[j] <- temp

        arr

    /// Initialize an array of size n with values 1..n (inclusive)
    let initRandom n =
        Array.init n (fun i -> i + 1) |> shuffle

    let Generate10000 = initRandom 10000 |> Array.toList

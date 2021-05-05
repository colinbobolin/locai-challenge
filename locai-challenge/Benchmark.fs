namespace LocaiChallenge

module Benchmark =
    open System.Diagnostics

    let Benchmark n f =
        let sw = Stopwatch()

        { 1 .. n }
        |> Seq.map
            (fun i ->
                sw.Reset()
                sw.Start()
                f |> ignore
                sw.Stop()
                sw.ElapsedTicks)
        |> Seq.averageBy float
        |> printfn "Average elapsed ticks over %i runs: %.2f" n

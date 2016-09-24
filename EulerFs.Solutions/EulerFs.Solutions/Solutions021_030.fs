namespace EulerFs.Solutions

open EulerFs.Common

type Solutions021_030() =
    member this.Solution021 =
        let prime = Prime()
        let sumOfDivs i =
            i
            |> prime.Factors
            |> Array.sum
            |> fun n -> n - i
        [|1L..10000L|]
        |> Array.map (fun i -> i, sumOfDivs i)
        |> Array.filter (fun (i, d) -> d > i)
        |> Array.filter (fun (i, d) -> sumOfDivs d = i)
        |> Array.map (fun (x, y) -> x + y)
        |> Array.sum
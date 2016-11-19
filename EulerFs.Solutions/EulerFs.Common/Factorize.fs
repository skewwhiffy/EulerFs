namespace EulerFs.Common

type Factorize() =
    let prime = Prime()

    let sumOfDivs i =
        i
        |> prime.Factors
        |> Array.sum
        |> fun n -> n - i

    member this.IsAbundant number =
        match number with
        | n when n < 12L -> false
        | n -> n |> int64 |> sumOfDivs |> fun n -> n > number

    member this.GetAbundants =
        Seq.initInfinite (fun i -> int64(i + 1))
        |> Seq.filter this.IsAbundant

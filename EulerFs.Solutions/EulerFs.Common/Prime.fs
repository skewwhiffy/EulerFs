namespace EulerFs.Common

type Prime() =
    let nextPrime (primesSoFar : int64 list)=
        let rec findNext (soFar : int64 list) (start : int64) =
            if soFar |> List.forall (fun p -> start % p <> 0L) then start
            else findNext soFar (start + 1L)
        let start = if primesSoFar.Length = 0 then 2L else ((primesSoFar |> List.max) + 1L)
        findNext primesSoFar start

    let primes =
        []
        |> Seq.unfold (fun prev ->
            let next = nextPrime prev
            Some(next, next::prev))
        |> Seq.cache

    member this.Item
        with get(n : int) =
            primes |> Seq.item n

    member this.Factorize source =
        let rec factorize soFar source primeIndex =
            if source = 1L then soFar
            else
                let next =
                    Seq.initInfinite (fun i -> i + primeIndex)
                    |> Seq.find (fun i -> source % this.[i] = 0L)
                let nextPrime = this.[next]
                factorize (nextPrime::soFar) (source/nextPrime) next
        factorize [] source 0

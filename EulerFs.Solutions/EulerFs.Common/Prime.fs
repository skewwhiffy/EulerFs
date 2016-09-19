#if INTERACTIVE
#else
namespace EulerFs.Common
#endif

open System

type Prime() =
    let nextPrime (primesSoFar : int64 list)=
        let rec findNext (soFar : int64 list) (start : int64) =
            if (start % 2L = 0L && start > 2L) then findNext soFar (start + 1L)
            else if (start % 3L = 0L && start > 3L) then findNext soFar (start + 2L)
            else if soFar |> List.forall (fun p -> start % p <> 0L) then start
            else findNext soFar (start + 2L)
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

    member this.LCM ([<ParamArray>] source : int64 array) =
        let factorizations =
           source
           |> Array.Parallel.map this.Factorize
           |> Array.Parallel.map (fun f -> (f |> List.groupBy (fun g -> g)))
           |> Array.Parallel.map (fun f -> f |> List.map (fun g -> g |> fst, g |> snd |> List.length))
           |> Array.Parallel.map (fun f -> f |> dict)
        let factors =
           factorizations
           |> Array.Parallel.map (fun f -> f.Keys |> Set.ofSeq)
           |> Set.unionMany
        let lcmFactorization =
           factors
           |> Set.map (fun f ->
               let exponent =
                   factorizations
                   |> Array.filter (fun d -> d.ContainsKey(f))
                   |> Array.Parallel.map (fun d -> d.[f])
                   |> Array.max
               f, exponent)
        let rec power source exponent =
           match exponent with
           | 0 -> 1L
           | x when x < 0 -> failwith "Cannot be negative"
           | x -> source * (power source (x - 1))
        lcmFactorization
        |> Set.map (fun f -> power (f |> fst) (f |> snd))
        |> Set.fold (fun acc next -> acc * next) 1L
#if INTERACTIVE
#else
namespace EulerFs.Common
#endif

open System

type Prime() =
    let primes = ResizeArray<int64>()

    let seive start size =
        let bitArray = System.Collections.BitArray(size, false)
        primes
        |> Seq.iter (fun n ->
            let lower = if start % n = 0L then start/n else start/n + 1L
            let upper = ((start + int64(size) - 1L) / n)
            [|lower..upper|]
            |> Array.filter (fun m -> m > 1L)
            |> Array.iter (fun m ->
                bitArray.Set(int32(m * n - start), true))
            )
        [|0..size - 1|]
        |> Array.filter (fun n -> not (bitArray.Get(n)))
        |> Array.map (fun n -> start + int64(n))

    let nextSeive() =
        if primes.Count = 0 then primes.Add(2L)
        else
            let maxPrime = primes |> Seq.max
            let newPrimes = seive (maxPrime + 1L) (int32(maxPrime))
            primes.AddRange newPrimes

    let nextPrime (primesSoFar : int64 list)=
        let rec findNext (soFar : int64 list) (start : int64) =
            if (start % 2L = 0L && start > 2L) then findNext soFar (start + 1L)
            else if (start % 3L = 0L && start > 3L) then findNext soFar (start + 2L)
            else if soFar |> List.forall (fun p -> start % p <> 0L) then start
            else findNext soFar (start + 2L)
        let start = if primesSoFar.Length = 0 then 2L else ((primesSoFar |> List.max) + 1L)
        findNext primesSoFar start

    member this.Item
        with get(n : int) =
            let rec getPrime n =
                if primes.Count > n then primes.[n]
                else
                    nextSeive()
                    getPrime(n)
            getPrime n

    member this.Factorize source =
        let rec factorize soFar source primeIndex =
            if source < 1L then failwith "Needs to be strictly positive"
            else if source = 1L then soFar
            else
                let next =
                    Seq.initInfinite (fun i -> i + primeIndex)
                    |> Seq.find (fun i -> source % this.[i] = 0L)
                let nextPrime = this.[next]
                factorize (nextPrime::soFar) (source/nextPrime) next
        factorize [] source 0

    member this.NumberOfFactors source =
        source
        |> this.Factorize
        |> List.groupBy (fun n -> n)
        |> List.map (fun n -> fst n, (snd n).Length)
        |> List.fold (fun acc (f, n) -> acc * (n + 1)) 1


    member this.LCM ([<ParamArray>] source : int64 array) =
        let factorizations =
           source
           |> Array.map this.Factorize
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
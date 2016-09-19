

    let primes = ResizeArray()

    let seive start size =
        let bitArray = System.Collections.BitArray(size, false)
        primes
        |> Seq.iter (fun n ->
            let lower = if start % n = 0 then start/n else start/n + 1
            let upper = ((start + size - 1) / n)
            [|lower..upper|]
            |> Array.filter (fun m -> m > 1)
            |> Array.iter (fun m ->
                printfn "%i" (m * n - start)
                bitArray.Set(m * n - start, true))
            )
        [|0..size - 1|]
        |> Array.filter (fun n -> not (bitArray.Get(n)))
        |> Array.map (fun n -> start + n)

    let nextSeive() =
        if primes.Count = 0 then primes.Add(2)
        else
            let maxPrime = primes |> Seq.max
            let newPrimes = seive (maxPrime + 1) maxPrime
            primes.AddRange newPrimes

    nextSeive()
    primes |> Array.ofSeq;
    nextSeive()
    primes |> Array.ofSeq;
    nextSeive()
    primes |> Array.ofSeq;
    nextSeive()
    primes |> Array.ofSeq;
namespace EulerFs.Common

type PythagoreanTriple() =
    member this.UpTo limit =
        let squares = [|0..limit|] |> Array.Parallel.map (fun i -> i * i)
        [|1..limit|]
        |> Array.Parallel.map (fun a -> [|(a + 1)..limit|] |> Array.Parallel.map (fun b -> a, b))
        |> Array.Parallel.map Set.ofArray
        |> Set.unionMany
        |> Seq.choose (fun p ->
            match p with
            | a, b ->
                let sumOfSquares = squares.[a] + squares.[b]
                match squares |> Array.tryFindIndex (fun s -> sumOfSquares = s) with
                | Some c -> Some (a, b, c)
                | None -> None)
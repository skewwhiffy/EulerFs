namespace EulerFs.Solutions

open EulerFs.Common
open System.IO

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

    member this.Solution022 =
        let worth (name:string) =
            name.ToCharArray()
            |> Array.map int32
            |> Array.map (fun n -> n - int32('A') + 1)
            |> Array.sum
        use sr = new StreamReader("names.txt")
        sr.ReadToEnd()
        |> fun s -> s.Split(',')
        |> Array.map (fun s -> s.Trim('"'))
        |> Array.sort
        |> Array.mapi (fun i s -> s, i + 1, worth(s))
        |> Array.map (fun (s, i, worth) -> i * worth)
        |> Array.sum
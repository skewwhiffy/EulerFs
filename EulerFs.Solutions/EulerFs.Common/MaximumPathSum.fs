namespace EulerFs.Common

open System

type MaximumPathSum(source : string) =
    let sourceArray =
        source.Split([|Environment.NewLine|], StringSplitOptions.RemoveEmptyEntries)
        |> Array.map (fun s -> s.Split ' ')
        |> Array.map (fun s -> s |> Array.map (fun n -> n |> Int32.Parse))

    member this.Item
        with get n =
            sourceArray.[n]

    member this.SubPathAt x y =
        sourceArray
        |> fun a -> Array.sub a x (sourceArray.Length - x)
        |> Array.mapi (fun i row -> Array.sub row y (i + 1))
        |> Array.map (fun row -> String.Join(" ", row))
        |> fun r -> String.Join(Environment.NewLine, r)
        |> MaximumPathSum

    member this.Value =
        match sourceArray.Length with
        | 1 -> sourceArray.[0].[0]
        | n -> sourceArray.[0].[0] + Math.Max((this.SubPathAt 1 0).Value, (this.SubPathAt 1 1).Value)
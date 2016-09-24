namespace EulerFs.Common
open System.Collections.Generic

type Fibonacci() =

    let items =
        (0, 1)
        |> Seq.unfold(fun prev -> match prev with | x, y -> Some(x, (y, x + y)))
        |> Seq.cache

    member this.Item
        with get n =
            items |> Seq.item n
#if INTERACTIVE
#else
namespace EulerFs.Common
#endif

type Triangle() =
    let triangles =
        (0, 0)
        |> Seq.unfold (fun (acc, state) -> Some (acc, (state + acc + 1, state + 1)))
        |> Seq.cache

    member this.Item
        with get n =
            triangles |> Seq.item n
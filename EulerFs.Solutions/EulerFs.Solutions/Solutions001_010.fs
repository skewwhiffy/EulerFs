namespace EulerFs.Solutions
open EulerFs.Common

type Solutions001_010() = 
    member this.Solution001 =
        let upper = 1000
        [1..upper-1]
        |> List.filter (fun x -> x % 3 = 0 || x % 5 = 0)
        |> List.sum

    member this.Solution002 =
        let fib = Fibonacci()
        Seq.initInfinite (fun n -> fib.[n])
        |> Seq.takeWhile (fun n -> n < 4000000)
        |> Seq.filter (fun n -> n % 2 = 0)
        |> Seq.sum
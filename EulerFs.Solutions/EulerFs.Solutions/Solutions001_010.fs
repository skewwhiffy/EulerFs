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

    member this.Solution003 =
        let prime = Prime()
        prime.Factorize 600851475143L
        |> List.max

    member this.Solution004 =
        let largestPalindrome bottom top =
            [bottom..top]
            |> List.collect (fun i -> [i..top] |> List.map (fun j -> i * j))
            |> List.map (fun i -> i.ToString())
            |> List.filter (fun i -> (i.ToCharArray() |> Array.rev |> System.String.Concat) = i)
            |> List.map System.Int32.Parse
            |> List.max
        largestPalindrome 100 999
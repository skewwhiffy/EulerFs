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
            [|bottom..top|]
            |> Array.collect (fun i -> [|i..top|] |> Array.Parallel.map (fun j -> i * j))
            |> Array.Parallel.map (fun i -> i.ToString())
            |> Array.filter (fun i -> (i.ToCharArray() |> Array.rev |> System.String.Concat) = i)
            |> Array.Parallel.map System.Int32.Parse
            |> Array.max
        largestPalindrome 100 999

    member this.Solution005 =
        let prime = Prime()
        prime.LCM([|1L..20L|])

    member this.Solution006 =
        let upper = 100
        let sumOfSquares =
            [|1..upper|]
            |> Array.Parallel.map (fun i -> i * i)
            |> Array.sum
        let squareOfSum =
            [|1..upper|]
            |> Array.sum
            |> (fun x -> x * x)
        squareOfSum - sumOfSquares

    member this.Solution007 =
        let count = 10001
        let prime = Prime()
        prime.[count - 1]

    member this.Solution008 =
        let numberOfAdjacentDigits = 13
        let lines = [|
            "73167176531330624919225119674426574742355349194934"
            "96983520312774506326239578318016984801869478851843"
            "85861560789112949495459501737958331952853208805511"
            "12540698747158523863050715693290963295227443043557"
            "66896648950445244523161731856403098711121722383113"
            "62229893423380308135336276614282806444486645238749"
            "30358907296290491560440772390713810515859307960866"
            "70172427121883998797908792274921901699720888093776"
            "65727333001053367881220235421809751254540594752243"
            "52584907711670556013604839586446706324415722155397"
            "53697817977846174064955149290862569321978468622482"
            "83972241375657056057490261407972968652414535100474"
            "82166370484403199890008895243450658541227588666881"
            "16427171479924442928230863465674813919123162824586"
            "17866458359124566529476545682848912883142607690042"
            "24219022671055626321111109370544217506941658960408"
            "07198403850962455444362981230987879927244284909188"
            "84580156166097919133875499200524063689912560717606"
            "05886116467109405077541002256983155200055935729725"
            "71636269561882670428252483600823257530420752963450"|]

        let digits =
            lines
            |> Array.reduce (fun acc next -> acc + next)
            |> (fun s -> s.ToCharArray())
            |> Array.Parallel.map (fun c -> System.Int64.Parse(c.ToString()))

        [|0..(digits.Length - numberOfAdjacentDigits - 1)|]
        |> Array.Parallel.map (fun i -> [|0..numberOfAdjacentDigits - 1|] |> Array.Parallel.map (fun j -> i + j))
        |> Array.Parallel.map (fun i -> i |> Array.Parallel.map (fun j -> digits.[j]))
        |> Array.Parallel.map (fun i -> i |> Array.fold (fun acc next -> acc * next) 1L)
        |> Array.max

    member this.Solution009 =
            PythagoreanTriple().UpTo 1000
            |> Seq.find (fun i ->
                match i with
                | a, b, c -> a + b + c = 1000)
            |> (fun i ->
                match i with
                | a, b, c -> a * b * c)

    member this.Solution010 =
        let limit = 2000000L
        let prime = Prime()
        0
        |> Seq.unfold (fun i ->
            match prime.[i] with
            | n when n > limit -> None
            | n -> Some(n, i + 1))
        |> Seq.sum
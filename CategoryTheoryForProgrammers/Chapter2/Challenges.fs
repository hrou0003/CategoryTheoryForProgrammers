module Chapter2.Challenges

open System
open System.Collections.Generic
open System.Diagnostics

// 1.
let memoize (f:('a -> 'b)) : ('a -> 'b) =
    
    let memoization_dictionary = Dictionary<'a , 'b>()
    
    let memoized_function (x: 'a) : 'b  =
        
        if memoization_dictionary.ContainsKey(x) then
            memoization_dictionary.[x]
        else
            let result = f x
            memoization_dictionary.Add(x, result)
            result
            
    memoized_function
let run() = 
        
    let rec fib n =
        match n with
        | 0 -> 0
        | 1 -> 1
        | _ -> fib (n - 1) + fib (n - 2)
            

    let timeFunction f arg =
        let stopwatch = Stopwatch.StartNew()
        let _ = f arg  // Call the function and ignore the result
        stopwatch.Stop()
        stopwatch.Elapsed

    let unmemoizedFib = fib  // Assume fib is your unmemoized Fibonacci function
    let memoizedFib = memoize fib  // Assume memoize is your memoization function

    let n = 35  // Or some other large number

    let unmemoizedTime = timeFunction unmemoizedFib n
    printfn "Unmemoized time: %A" unmemoizedTime

    let firstMemoizedTime = timeFunction memoizedFib n
    let secondMemoizedTime = timeFunction memoizedFib n
    printfn "Memoized time: %A" firstMemoizedTime
    printfn "Memoized time: %A" secondMemoizedTime


    // 2.
    let seed = 12345
    let random = Random(seed)
    
    let memoized_random = memoize (fun (_) -> random.Next())
    
    let number = memoized_random 1
    let number_two = memoized_random 2
    printfn "Memoized time: %A" number
    printfn "Memoized time: %A" number_two
    
    // 3.
    let seeder x =
        let random = Random(x)
        random.Next()
        
    let memoized_seeder = memoize seeder
    
    let seed_one = memoized_seeder 1
    
    let seed_two = memoized_seeder 1

    printfn "Seed one: %A" seed_one
    printfn "Seed two: %A" seed_two

    // 4.1
    let read_char x = 
        let ch = Console.Read() |> char
        ch
        
    let memoized_read_char = memoize read_char
    let memoized_read_char_result = memoized_read_char 1
    let memoized_read_char_result_two = memoized_read_char 1
    
    printfn "Seed one: %A" memoized_read_char_result
    printfn "Seed two: %A" memoized_read_char_result_two
    
    // 4.2
        
    let string_true _ =
        printfn "Hello!"
        true
    
    let memoized_string_true = memoize string_true
    
    let result = memoized_string_true 1
    let result_two = memoized_string_true 1
    
    printfn "Seed one: %A" result
    printfn "Seed two: %A" result_two
    

    
    
    

module CategoryTheoryForProgrammers
[<EntryPoint>]
let main argv = 
    match argv with
    | [| "Chapter1" |] -> 
        // Run the code for Chapter 1
        printfn "Running Chapter 1"
    | [| "Chapter2" |] -> 
        // Run the code for Chapter 2
        printfn "Running Chapter 2"
        Chapter2.Challenges.run()
    | _ -> 
        // If no chapter is specified, or if the specified chapter is not recognized,
        // print an error message
        printfn "Please specify a chapter to run, e.g., 'Chapter1' or 'Chapter2'"

    0 // return an integer exit code

module Chapter1.Challenges
open NUnit.Framework

// 1. Create an identity function
let id x = x

// 2. Create a composition function
let compose f g x = f (g x)

// 3. Composition respects identity
[<Test>]
let ``Identity Composes on the Left`` () =
    let f x = x + 1
    let result = compose id f
    Assert.AreEqual(f 2, result 2)
    
[<Test>]
let ``Identity Composes on the Right`` () =
    let f x = x + 1
    let result = compose f id
    Assert.AreEqual(f 2, result 2)


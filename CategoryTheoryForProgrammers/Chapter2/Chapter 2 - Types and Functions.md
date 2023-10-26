## Who needs types?
- Types give us granularity to understand mappings
- They give us information about the structure of the data without specifying the data itself
- They strengthen the syntax of the language
## Types are about composability
- The target of one arrow must be the same as the source object of the next arrow
- Strong static typing give compile time errors instead of runtime errors
- Strong static typing can be used to give a stronger semantic meaning to the code
- Unit testing can't cover all errors
## What are types?
- Types are just sets of values
- The type Bool is a two-element set of *True* and *False* and the type *Char* is a set of all Unicode characters
- When we declare a variable to be of a certain type - we are simply saying that it is a member of a set
- *Set* is a special category because we can peak inside of it and extract lots of information - its objects are sets and its arrows are functions
- We can almost say that Haskell types are sets and Haskell functions are mathematical functions between sets
- The problem is that a mathematical function does not execute any code - it just knows the answer
- The root of the problem is that programs can decidedly loop - the halting problem
- We then introduce a special value: ⊥ to denote a non-terminating computation
- The return type of a function can then become `f::Bool -> Bool` where `f` may return `True, False or ⊥`
- Functions that may return bottom are called partial as opposed to total functions
## Why do we need a mathematical model?
- It is very hard to reason about programs using an operational semantic model
- Operational semantics describe how a valid program is interpreted ass a sequence of computational steps
- Computers are good at running programs - humans are not and operational semantics is an extension of this computational way of thinking
- The alternative is *denotational semantics* where every programming construct is given its mathematical interpretation where simply have to prove a mathematical theorem
- A big breakthrough in denotational semantics was viewing computational effect as a monad (which we develop later)
- All functions and algorithms in the Haskell standard library come with proofs of correctness
## Pure and dirty functions
- What we call functions in C++ or any other imperative language are **not** the same things mathematicians call functions - a mathematical function is just a mapping of values to values
- A function which has a side-effect cannot be modelled as a mathematical function
- A function which always produces the same result given the same input and has no side effects is called a *pure function*
- In pure functional languages it's easier to give these languages denotational semantics and model them using category theory
## Examples of types
- The type corresponding to empty set in Haskell is `Void`, it's a type that's not inhabited by any values and it cannot be created and so the empty set looks like `absurd :: Void -> a`
- The type `Void` represents falsity and the type of the function `absurd` corresponds to the statement that from falsity follows anything
- An example of a type that corresponds to a single set is `f44 :: () -> Integer` and the definition `f44 () = 44` and can then be called with `f44 ()`
- Functions with return type `()` are used for side effects but do not correspond to real functions in a mathematical sense. A pure function that returns unit does nothing, a function from a set $A$ to a singleton set maps every element of $A$ to the single element of the singleton.
- The type looks like `fInt :: Integer -> ()`, the definition `fInt x = ()` and can be called by `fInt 2`
- In the topology of types, next comes the two-element set which in Haskell would be `Bool` and can be defined `data Bool = True | False` and functions to bool are called predicates with some Haskell examples being `isDigit` or `isAlpha`
## Challenges

1. Define a higher-order function (or a function object) memoize in your favorite language. This function takes a pure function f as an argument and returns a function that behaves almost exactly like f, except that it only calls the original function once for every argument, stores the result internally, and subsequently returns this stored result every time it’s called with the same argument. You can tell the memoized function from the original by watching its performance. For instance, try to memoize a function that takes a long time to evaluate. You’ll have to wait for the result the first time you call it, but on subsequent calls, with the same argument, you should get the result immediately.
2. Try to memoize a function from your standard library that you normally use to produce random numbers. Does it work?
3. Most random number generators can be initialized with a seed. Implement a function that takes a seed, calls the random number generator with that seed, and returns the result. Memoize that function. Does it work?
4. Which of these C++ functions are pure? Try to memoize them and observe what happens when you call them multiple times: memoized and not. 
   1. The factorial function from the example in the text.
   2. std::getchar()
   3. ``` 
      bool f() {
          std::cout << "Hello!" << std::endl;
          return true;
      }
  4. 
     ```
	int f(int x)
	25
	{
	static int y = 0;
		y += x;
		return y;
		}
       ```
5. How many different functions are there from Bool to Bool? Can you implement them all?
![[Pasted image 20231026210216.png]]
6. Draw a picture of a category whose only objects are the types `Void`, `()`, and `Bool`; with arrows corresponding to all of the possible functions between these types. Label the arrows with the names of the functions.
![[Pasted image 20231026210151.png]]
   
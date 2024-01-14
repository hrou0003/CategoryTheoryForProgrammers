## Composition of Logs
- Having global state modified in a function is not memoizable and therefore it's not a pure function
- How can we then make this a "pure" process via composition? We introduce a string argument which is modified directly like so - this **is** memoizable
```
pair<bool, string> negate(bool b, string logger) {
     return make_pair(!b, logger + "Not so! ");
}
```
- There is still an issue with this - it doesn't separate concerns, it's trying to both handle the negation of the bool and writing to logs
- The compromise is to remove the the new string argument and instead just return the string which should be appended to the log
```
let negate (b: bool) =
	(not b, "Not so! ")
```
- The aggregation of the log is no longer the concern of the individual functions. They produce their own messages, which are then, externally, concatenated into a larger log.
## Embellishments - The Writer Category
- We start off with our regular category of types and functions, the adjustment we make is that the embellished functions become our arrows instead
- The steps for composition in this category are:
	- Execute the first embellished morphism
	- Extract the first component and pass it to the second embellished function
	- Concatenate the strings from the first and second result
	- Return the second result and the concatenated strings
### Writer in F\#
We can define the `Writer` type as follows

```f#
type Writer<'a> = 'a * string
```

then we will define a composition operator
```f#
let (>=>) (f: 'a -> Writer<'b>) (g: 'b -> Writer<'c>) (x: 'a) : Writer<'c> =
    let (result, log1) = f x
    let (result2, log2) = g result
    (result2, log1 + log2)

```

and example of its usage
```f#
let addOne (x: int) : Writer<int> =
    (x + 1, "Added one. ")

let square (x: int) : Writer<int> =
    (x * x, "Squared. ")

let addOneAndSquare = addOne >=> square

let (result, log) = addOneAndSquare 3
```
## Kleisli Categories
- We have just given an example of what is called a *Keleisli* category - a category based on a monad
- Each Kleisli category defines its own way of composing morphisms, as well as the identity morphism with respect to that composition
- We have shown specifically the Writer monad
- We have added another degree of freedom in the form of the composition itself
- It turns out that this is the degree of freedom which makes it possible to give simple denotational semantics to programs that in imperative languages are traditionally implemented using side effects

## Challenges
A function that is not defined for all possible values of its argument is called a partial function. It’s not really a function in the mathematical sense, so it doesn’t fit the standard categorical mould. It can, however, be represented by a function that returns an embellished type `Option`.

As an example, here’s the implementation of the embellished function `safe_root`:
```f#
let safeRoot (x: float) : Option<float> =
    if x >= 0.0 then Some(sqrt x)
    else None
```

Here’s the challenge:
- **Construct the Kleisli category for partial functions (define composition and identity).** 
```f#
let (=*) (f: 'a -> Option<'b>) (g: 'b -> Option<'c>) (x: 'a) : Option<'c> =
	match f x with
		| Some(value) -> g value
		| None -> None

let identity (x: 'a) = Some x
	
```
- I**mplement the embellished function `safe_reciprocal` that returns a valid reciprocal of its argument, if it’s different from zero.**
```f#
let safe_reciprocal (x: float) : Option<float> = 
	if x <> 0 then Some(1/x)
	else None
```
- **Compose `safe_root` and safe_reciprocal to implement `safe_root_reciprocal` that calculates $sqrt(1/x)$ whenever possible.**
```f#
let safe_reciprocal_root = safe_reciprocal =* safe_root
```
## Follow the arrows
- If we want to single out a particular object in a category - we can only do this by describing its pattern of relationships with other objects (and itself).
- A common construction in category theory is the *universal construction* for defining objects in terms of their relationships
- We do this by picking a pattern in the form a shape constructed from objects and morphisms and look for all occurrences in the category
## Initial Object
- This is the object that has one and only one morphism going to any object in the category
- There is no guarantee that this object exists
- This object is unique up to isomorphism
- In the category of sets and functions, the initial object is the empty set
## Terminal Object
- The terminal object is the object with one and only one morphism coming to it from any object in the category
- This again is unique up to isomorphism
- In a poset, the terminal object, if it exists, is the biggest object
- In the category of sets it is a singleton
- The uniqueness property gives just the right precision to narrow down the definition of the terminal object to just one type
## Duality
- For any category $C$ we can define the opposite category $C^{op}$ just by reversing all of the arrows
- Duality is an important property because you get an extra category for every other category
- The terminal object is the initial object in the opposite category
## Isomorphisms
- The intuition is that isomorphic objects look the same -- they have the same shape
- Every part of one object corresponds to some part of another object in a one-to-one mapping - It means that every part of one object corresponds to some part of another object in a one-to-one mapping
## Products
- A **product** of two object $a$ and $b$ is the object $c$ equipped with two projects such that for any other object $c'$ equipped with two projections there is a unique morphism $m$ from $c' \to c$ that factorises those projections.
- For **Set** the product is the cartesian product
## Coproduct
 - A coproduct of two objects a and b is the object c equipped with two injections such that for any other object c’ equipped with two injections there is a unique morphism m from c to c’ that factorizes those injections
 - In the category of sets, the coproduct is the disjoint union of two sets
## Asymmetry
- The definition of a terminal object can be obtained from the definition of the intial object by reversing the direction of the arrows
- Similarly, the coproduct can be derived from the product
- However, in the category of sets, the initial object is very different from the final obect and the coproduct is very different from the product
- We will later see that the product behaves like multiplication, with the terminal object playing the role of one
- On the other hand the coproduct behaves more like the sum, with the initial object playing the role of 0.

## Challenges
1. Show that the terminal object is unique up to unique isomorphism.
Given terminal objects $t$ and $t'$, we can show that they are unique up to isomorphism by taking the unique morphism $m$ from $t$ to $t'$ and the unique isomorphism $m'$ from $t'$ to $t$. If we then compose $m \circ m'$ there is only one possible morphism this can be and that's $id_{t}$ implying that $m$ is a morphism. Note: we would also need to show $m' \circ m = id_{t'}$ but this follows trivially. We can see that this isomorphism is unique since there is only one possible $m$ by the definition of the terminal object.
2. What is a product of two objects in a poset? Hint: Use the universal construction.
![[Pasted image 20240114160254.png]]
On the left we have the universal construction of the product, and on the right we have an example of a poset. We can see that the product in a poset is the least upper bound, as 
highlighted here:
![[Pasted image 20240114163553.png]] 
we can see that 10 "factorises" 30 into 2 and 5, we also notice that it is the LCM (least common multiple).
3. What is a coproduct of two objects in a poset?
The coproduct looks like 
![[Pasted image 20240114164101.png]]
And so we are looking for an example of this pattern in the example poset from above, highlighted here:
![[Pasted image 20240114164409.png]]
or a simplified version: 

5. Implement the equivalent of Haskell Either as a generic type in your favorite language (other than Haskell).

6. Show that Either is a “better” coproduct than int equipped with two injections:
```f#
int i(int n) { return n; }
int j(bool b) { return b? 0: 1; }
```
Hint: Define a function
```f#
int m(Either const & e);
```
that factorizes i and j.
6. Continuing the previous problem: How would you argue that int with the two injections i and j cannot be “better” than Either?
7. Still continuing: What about these injections?
```f#
int i(int n) { 
    if (n < 0) return n; 
    return n + 2;
}
int j(bool b) { return b? 0: 1; }
```
8. Come up with an inferior candidate for a coproduct of int and bool that cannot be better than Either because it allows multiple acceptable morphisms from it to Either.

## Questions
- **Why is associativity important? Maybe this is best illustrated with a counter example.**
	Associativity is an important property of categories as it simplifies their structure, if a category didn't have associativity then it would be much harder to reason about as we would have to keep track of the order in which the arrows were applied.
 
- **Why is the commutivity of the identity element not trivial? Maybe another counter example.**
	The main thing to highlight is that the left identity is equal to the right identity. This is crucial as it ensures that the identity morphism doesn't change the behaviour of any other morphism regardless of whether it's composed from the left or the right.
	
- **Explain this quote more** "Their surface area has to increase slower than their volume. (I like this analogy because of the intuition that the surface area of a geometric object grows with the square of its size — slower than the volume, which grows with the cube of its size.) The surface area is the information we need in order to compose chunks. The volume is the information we need in order to implement them. The idea is that, once a chunk is implemented, we can forget about the details of its implementation and concentrate on how it interacts with other chunks."
	

## Category: The Essence of Composition
A category is a very simple concept. It consists of *objects* and *arrows* that go between the objects. 

A simple category may look like this
![[Pasted image 20231008164018.png]]

## Arrows as Functions
- Think of arrows as functions between types
- These arrows can be composed to create new functions
- Things become easy to express when we can easily compose these arrows with programming syntax

## Properties of Composition
- There are two properties that composition in a category must satisfy
  - Composition is associative: the order which the arrows are applied to each other doesn't matter
  - For every object there is an identity arrow

## Composition is the Essence of Programming
- We break big pieces of code into smaller pieces and then compose these smaller pieces back together to get the whole solution
- We want to forget about the details of an implementation be able to only think of the abstraction and how it can be composed
- Category theory discourages us from "looking inside" the objects and only observing the interactions between objects

## Challenges
The first three questions have been answered in Challenges.fs

1. Implement, as best as you can, the identity function in your fa-
   vorite language (or the second favorite, if your favorite language
   happens to be Haskell).
2. Implement the composition function in your favorite language.
   It takes two functions as arguments and returns a function that
   is their composition.
3. Write a program that tries to test that your composition function
   respects identity.
4. Is the world-wide web a category in any sense? Are links mor-
   phisms? 
5. Is Facebook a category, with people as objects and friendships as
   morphisms?
6. When is a directed graph a category?
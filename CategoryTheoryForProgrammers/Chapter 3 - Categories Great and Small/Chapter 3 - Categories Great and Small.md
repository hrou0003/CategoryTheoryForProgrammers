## No Objects

## Simple Graphs
- Categories can be made by just drawing dots and arrows
- There is a process for generating a category by satisfying the laws
	- Add identity arrows
	- For any two arrows with matching end and tip, add a new arrow for their composition
	- Every time an arrow is added, we have to consider the composition
- This is then called a *free category*
## Orders
- An order is a relation where the relation is defined by $a \leq b$.
- A preorder is a category due to the following:
	- Every object is less than or equal to itself
	- If $a \leq b$ and $b \leq c$ then $a \leq c$ so we have composition
	- Composition is associative
- There are also partial orders and total orders
	- A partial order adds the condition that $a \leq b$ and $b \leq a$ then $a = b$
	- A total order has the condition that any two objects are related in some way
- Categorisation as categories:
	- A preorder has at most one morphism between any two objects, this is called a thing category
	- The set of morphisms from $a$ to $b$ is written as $C(a, b)$ or $Hom_{c}(a,b)$ and it is called the homset. In a preorder all homsets are singletons.
	- Preorders can have cycles, partial orders cannot
- [[Topological Sort]]

## Monoid as Set
- It's a very simple but powerful concept
- Addition and multiplication are monoids
- A monoid is traditionally defined as a set with a binary operation which is associative and has a unit
- F# example
```f#
type Monoid<'a> = {
    Identity: 'a
    Operation: 'a -> 'a -> 'a
}

let integerAdditionMonoid = {
	Identity = 0
	Operation = (+)
}
```

## Monoid as Category
- We can also frame a monoid from the perspective of objects and arrows
- A monoid as a category can be thought of as a single object with a set of morphisms that follow appropriate rules of composition
- We can always extract a set from a single-object category, this is the set of morphisms or the homset
- Then we can define a binary operator in this set: the monoid product of two set-element is the element corresponding to the composition of these two elements
- Not all homsets are sets, a category in which morphisms between any two objects form a set is called locally small
- The hom-set can be seen as both rules of composition and points in a set

## Challenges
1. Generate a free category from:
	1. A graph with one node and no edges
	2. A graph with one node and one (directed) edge (hint: this edge can be composed with itself)
	3. A graph with two nodes and a single arrow between them
	4. A graph with a single node and 26 arrows marked with the letters of the alphabet: a, b, c … z.
2. What kind of order is this?
	1. A set of sets with the inclusion relation: A is included in B if every element of A is also an element of B.
	2. C++ types with the following subtyping relation: T1 is asubtype of T2 if a pointer to T1 can be passed to a function that expects a pointer to T2 without triggering a compilation error.
2. Considering that Bool is a set of two values True and False, show that it forms two (set-theoretical) monoids with respect to, re-spectively, operator && (AND) and || (OR). 
3. Represent the Bool monoid with the AND operator as a category: List the morphisms and their rules of composition.
4. Represent addition modulo 3 as a monoid category.
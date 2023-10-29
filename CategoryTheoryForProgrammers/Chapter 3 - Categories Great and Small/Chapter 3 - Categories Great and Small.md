# No Objects

# Simple Graphs
- Categories can be made by just drawing dots and arrows
- There is a process for generating a category by satisfying the laws
	- Add identity arrows
	- For any two arrows with matching end and tip, add a new arrow for their composition
	- Every time an arrow is added, we have to consider the composition
- This is then called a *free category*
# Orders
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

# Monoid as Category
- We can also frame a monoid from the perspective of objects and arrows
- A monoid as a category can be thought of as a single object with a set of morphisms that follow appropriate rules of composition
- We can always extract a set from a single-object category, this is the set of morphisms or the homset
- Then we can define a binary operator in this set: the monoid product of two set-element is the element corresponding to the composition of these two elements
- Not all homsets are sets, a category in which morphisms between any two objects form a set is called locally small
- The hom-set can be seen as both rules of composition and points in a set

# Challenges
1. **Generate a free category from:**
	1. **A graph with one node and no edges**
	   ![[Challenge3.1.1.png]]
	2. **A graph with one node and one (directed) edge (hint: this edge can be composed with itself)** 
	   ![[Challenge3.1.1.png]]
	3. **A graph with two nodes and a single arrow between them**
	   ![[Pasted image 20231029203741.png]]	
	4. **A graph with a single node and 26 arrows marked with the letters of the alphabet: a, b, c … z.**
	   That's just a monoid
2. **What kind of order is this?**
	1. **A set of sets with the inclusion relation: A is included in B if every element of A is also an element of B.**
	   It can't be a total order since not every set is related. It would be a partial order since if both sets are included in each other, then they are equal.
	1. **C++ types with the following subtyping relation: T1 is a subtype of T2 if a pointer to T1 can be passed to a function that expects a pointer to T2 without triggering a compilation error.**
	   I'm not quite sure about this one, but trying to understand what would trigger a compilation error is my starting point. Having asked ChatGPT for a hint, I get the following: If there is a class hierarchy where class `T2` is a base class  and `T1` is a derived class, you can pass a pointer to `T1` to a function that expects `T2`. This actually isn't specific to C++ and could happen in many OO languages. This would be a partial order since not every type is related but if `T1 : T2` and `T2 : T1` then `T1 = T2`.
3. **Considering that Bool is a set of two values True and False, show that it forms two (set-theoretical) monoids with respect to, re-spectively, operator && (AND) and || (OR).**
	- A set theoretical monoid is a set which is endowed with a binary operator that is associative and has a unit
		- && 
			- Associative: `(a && b) && c = a && b && c = a && (b && c)`
			- Has a unit:  if `a = true` then `true && true = true` and if `a = false` then `false && true = false`
		- ||
			- Associative: `(a || b) || c = a || b || c = a || (b || c)`
			- Has a unit:  if `a = true` then `a || false = true` and if `a = false` then `a && false = false
4. **Represent the Bool monoid with the AND operator as a category: List the morphisms and their rules of composition.**
   ![[Challenge3.4.png]]
5. **Represent addition modulo 3 as a monoid category.**
   ![[Challenge3.5.png]]
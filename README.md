# PegSolitaire

## About the game

[Peg solitaire on Wikipedia](https://en.wikipedia.org/wiki/Peg_solitaire)

![Peg solitaire](https://upload.wikimedia.org/wikipedia/commons/d/df/Solitaire.JPG)

## The motivation
I currently rediscovered one of my favourite games of my childhood. The idea behind this project was to find all possible solutions using brute force.
There are two implementations, synchronous and asynchronous, with modern CPUs the asynchronous approach is much faster.

## Simplification
There are four possible moves at the beginning, but they are basically all the same when you rotate the board!
Therefore I have predefined the first move (6,4)=>(4,4)

## The calculation
I stopped the program after 1,500,330,494 finished games and got 223,354 solutions, at a rate of 240,000 finished games per second. 
Feel free to complete the calculations on your machine!

One calculated solution is as follows:

```
 1. move: (6,4)=>(4,4)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○  ○  ○       │
5│ ○  ○  ○  ○  ○  ○  ○ │
4│ ○  ○  ○  ●        ○ │
3│ ○  ○  ○  ○  ○  ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 2. move: (5,6)=>(5,4)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○  ○          │
5│ ○  ○  ○  ○     ○  ○ │
4│ ○  ○  ○  ○  ●     ○ │
3│ ○  ○  ○  ○  ○  ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 3. move: (4,4)=>(6,4)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○  ○          │
5│ ○  ○  ○  ○     ○  ○ │
4│ ○  ○  ○        ●  ○ │
3│ ○  ○  ○  ○  ○  ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 4. move: (5,2)=>(5,4)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○  ○          │
5│ ○  ○  ○  ○     ○  ○ │
4│ ○  ○  ○     ●  ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 5. move: (3,6)=>(5,6)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│             ●       │
5│ ○  ○  ○  ○     ○  ○ │
4│ ○  ○  ○     ○  ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 6. move: (7,5)=>(5,5)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│             ○       │
5│ ○  ○  ○  ○  ●       │
4│ ○  ○  ○     ○  ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 7. move: (3,4)=>(3,6)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ●     ○       │
5│ ○  ○     ○  ○       │
4│ ○  ○        ○  ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 8. move: (1,4)=>(3,4)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○     ○       │
5│ ○  ○     ○  ○       │
4│       ●     ○  ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 9. move: (1,5)=>(3,5)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○     ○       │
5│       ●  ○  ○       │
4│       ○     ○  ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 10. move: (5,5)=>(5,3)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○     ○       │
5│       ○  ○          │
4│       ○        ○  ○ │
3│ ○  ○  ○  ○  ●  ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 11. move: (3,5)=>(5,5)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○     ○       │
5│             ●       │
4│       ○        ○  ○ │
3│ ○  ○  ○  ○  ○  ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 12. move: (5,6)=>(5,4)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○             │
5│                     │
4│       ○     ●  ○  ○ │
3│ ○  ○  ○  ○  ○  ○  ○ │
2│       ○  ○          │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 13. move: (5,4)=>(5,2)
 ┌─────────────────────┐
7│       ○  ○  ○       │
6│       ○             │
5│                     │
4│       ○        ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○  ●       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 14. move: (3,7)=>(3,5)
 ┌─────────────────────┐
7│          ○  ○       │
6│                     │
5│       ●             │
4│       ○        ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 15. move: (3,4)=>(3,6)
 ┌─────────────────────┐
7│          ○  ○       │
6│       ●             │
5│                     │
4│                ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 16. move: (5,7)=>(3,7)
 ┌─────────────────────┐
7│       ●             │
6│       ○             │
5│                     │
4│                ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 17. move: (3,7)=>(3,5)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ●             │
4│                ○  ○ │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 18. move: (7,4)=>(5,4)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│             ●       │
3│ ○  ○  ○  ○     ○  ○ │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 19. move: (7,3)=>(5,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│             ○       │
3│ ○  ○  ○  ○  ●       │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 20. move: (4,3)=>(6,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│             ○       │
3│ ○  ○  ○        ●    │
2│       ○  ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 21. move: (3,2)=>(3,4)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ●     ○       │
3│ ○  ○           ○    │
2│          ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 22. move: (1,3)=>(3,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○     ○       │
3│       ●        ○    │
2│          ○  ○       │
1│       ○  ○  ○       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 23. move: (5,1)=>(5,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○     ○       │
3│       ○     ●  ○    │
2│          ○          │
1│       ○  ○          │
 └─────────────────────┘
   1  2  3  4  5  6  7

 24. move: (5,4)=>(5,2)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○             │
3│       ○        ○    │
2│          ○  ●       │
1│       ○  ○          │
 └─────────────────────┘
   1  2  3  4  5  6  7

 25. move: (3,1)=>(5,1)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○             │
3│       ○        ○    │
2│          ○  ○       │
1│             ●       │
 └─────────────────────┘
   1  2  3  4  5  6  7

 26. move: (5,1)=>(5,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○             │
3│       ○     ●  ○    │
2│          ○          │
1│                     │
 └─────────────────────┘
   1  2  3  4  5  6  7

 27. move: (6,3)=>(4,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○             │
3│       ○  ●          │
2│          ○          │
1│                     │
 └─────────────────────┘
   1  2  3  4  5  6  7

 28. move: (4,3)=>(2,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│       ○             │
4│       ○             │
3│    ●                │
2│          ○          │
1│                     │
 └─────────────────────┘
   1  2  3  4  5  6  7

 29. move: (3,5)=>(3,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│                     │
4│                     │
3│    ○  ●             │
2│          ○          │
1│                     │
 └─────────────────────┘
   1  2  3  4  5  6  7

 30. move: (2,3)=>(4,3)
 ┌─────────────────────┐
7│                     │
6│                     │
5│                     │
4│                     │
3│          ●          │
2│          ○          │
1│                     │
 └─────────────────────┘
   1  2  3  4  5  6  7

 31. move: (4,2)=>(4,4)
 ┌─────────────────────┐
7│                     │
6│                     │
5│                     │
4│          ●          │
3│                     │
2│                     │
1│                     │
 └─────────────────────┘
   1  2  3  4  5  6  7

```
 
[Source of Image file](https://commons.wikimedia.org/wiki/File:Solitaire.JPG)

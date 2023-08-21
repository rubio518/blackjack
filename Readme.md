# Blackjack

This is a blackjack game. it is intended to showcase the programming skills of the author.

## Getting Started
this project was created without any external libraries, so it should be a standard solution that can be build and run in visual studio.

you can download the files from the release and run the program or you can clone this repository and build the project yourself.

### Prerequisites
- visual studio
- git

## Functionality
- The game is played with a standard deck of 52 cards.
- The game can support up to 10 players
- The game asks for the number of players and deals their hands
- The game asks each player if they want to hit or stand
- The game determines the winner and displays the results

## Improvements
- The game does not support splitting or doubling down
- There is a lot of invalidations that could be done to make the game more robust
- In order to not spend so much time with this project there is a lot of edge cases that are not dealt with
- We can add unit tests to make sure the game is working as expected
- the game does not support restarting the game maintaining the current player balance

## Design Decisions
- The game is designed to be as simple as possible, so there is no UI
- The programming language chosen for this project is C#, I am somewhat familiar with the langague and the .net framework, C# it is a good fit for this kind of projects because it handles the console I\O very well, it is relatively fast, thinking about a game of blackjack it made sense to use an Object Oriented approach, and C# is a good fit for that.
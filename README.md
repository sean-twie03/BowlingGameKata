# BowlingGameKata
Bowling Game Kata from https://github.com/ardalis/kata-catalog/blob/master/katas/Bowling%20Game.md

I went a little overboard on this one.  When I tried to use the Roll() method as described in the kata, I ran into a lot of issues.
I searched around online and noticed many other people who have written this kata didn't account for the bugs I was encountering.

The bugs were to do with the number of rolls per frame.  Most solutions to this kata I see online assume each frame is two rolls.
Some solutions do take into account the third possible roll in the 10th frame, but none take into account that a Strike is a frame with only one roll.

This leads to a solution where frameIndex = frameIndex + 2 will skip a valid roll, unless the User knows to call Roll twice for each frame (even on a strike). </br>
// Strike </br>
Roll(10) </br>
Roll(0) // Not Intuitive </br>

So I decided to fix that issue by changing the design of the kata.  Call it cheating or being thurough.

Instead of having the user call Roll() I changed the Game class to take a IEnumerable\<Frame\> in the constructor.
So prior to creating a new game, the user will create a List of 10 Frames and pass that into the Game object's constructor.

The Frame constructor takes 1, 2, or 3 ints as its argument. 1 for Strike, 2 for normal rolls or a spare, or 3 for an extended 10th frame.

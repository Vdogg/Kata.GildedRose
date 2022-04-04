# Testing the "GildedRose" Kata

### First look

First, my choice was to develop it in C# simply because i wanted to improve my skills in that language. Or, at least, getting used to it's syntax.

I started first to read the directives which seemed ok.
Secondly, i ran the CsharpFramework example which has a main with example. Just to print it's behaviour. 
The example is simply update each items after 30 days and print them. This is the best example i can have, so i kept it. (except the conjured one which needs an update of its behaviour).

### My solution without irritate the goblin

Now the actual code.
Technicaly, it's a mess. A big if-else to process the items. Nothing else.

First thing to remain is to dissociate each item's process from it.

Second, how can i organize it to make it humanly readable and clean?
First point in my mind : "Okay, its a shop with items. We need objects, we need inheritance".
After thinking of that, I realized that inheritance doesn't fit because it leads to a problem. We cannot change the Item class for just one reason. The upgrade() behaviour.
We could create polyphormed sub-items (cheeses, invokeds, legendaries,etc). But the "upgrade()" function has to be in the Item class possesses. But we cannot.
(We still could cheat with creating a direct and unique inherited sub-item which implements upgrade() and the polyphormed sub-items could inherit from it. But it's wrong, ugly, bad, whatever.) 
At this time, i was stuck. I was wondering "how can i treat/process these items depending what they are? I told to myself "there is a trick, this exercice is not that easy, this goblin is a pain in the ***".
I searched on the internet for the main design patterns. After some readings, i found the strategy pattern.
A part of the idea of the strategy pattern is to prevent a massive a complicated inheritence in some cases. It wasn't what i was looking for but it got close to one point:
It does not touch the object's behaviour, It is decoupled. And that was what i was looking for.
Plus, the situation doesn't really need inheritance because the data structure never changes. It haves a name, a sellin value, and a quality value. That's it.
The only thing which change is it's behaviour. How the quality changes over time.
So the idea is that is the shop itself who changes the items quality (quality can be replaced with gold value in my opinion, which makes more sense on this situation)
Each item have to be processed independently with different available strategies. Also, it's meaningful to say "Which strategy do we use to sell these items?".

With this pattern, the point concerning the invoked food was easy. We just need to create a new Strategy to process them. That's it.

### On which approach

The discussion before the test led to consider developping with the Test Driven Development approach. The idea is simple. It's test based. For each feature we have to create a test first. A failing test.
When it's done, i do what's needed to make it pass. Next step is a new failing test. I make it pass so as the previous one. Etc.
I made the project in that way. Every feature was firstly based on a failing test. Now, the program done. There is 10 tests  functions with 39 test cases. All working and usefull for an eventual change in the future.


### How to test it

You can execute the compiled program or use the test class to test each feature.
Ai Companion summer project.

---
# The base idea

The original idea for this project was a simple ai companion like the old toys people had back in the day with some homemade machine learning thrown in. 
But sadly I let it run a bit out of scope, and ended up focusing too much on the machine learning part.

But at least I have made some progress on that, of which I will not explain to you.

The main idea was to make a text based ai that would "understand" and learn based on what the user told them about. I spent most of the time on this project thinking about how to deal with the problem of making the program "learn".
So I started by trying to figure out how our memory works, how do we learn things?

Now of course I do not have the ability to simulate a brain, but I can cheat. After spending lots of time thinking, I have come to the conclusion that the way we remember things are usually not too far from a class implementing other classes and interfaces.
Lets say a car. We know what a car is. And we know what it has. So based on that we can create a small memory structure that looks something like this.

```cs
{
  string title
  string[] isMemories
  string[] hasMemories
  string[] childMemories
}
```

With a system of storing these memory objects and getting them from the long term memory by title, we can have a good way of storing learned information.
If we go back to the car example, then it could look something like this (in json format)

```json
{"title":"car","isMemories":["vehicle","rectangular"],"hasMemories":["wheels","windows","lights","doors","seats"],"childMemories":["volvo v70","tesla model x","toyota prius"]}
```

---
# The start of the project

One of the main priorities of this project has always been code quality, so first step for me was to create two projects. One "viewer" or "user" of the ai (Console app), and then the ai itself as a class library.
Then I created the basic interface owned and implemented by the class library to enable development of ui before the program was done. This also allows me to later rewrite the ui part to possibly let the user communicate with the ai over a network instead.

The ai part also had one important design principle, and that is to make sure not to do something that will prevent multiple instances of the ai running. (Mainly avoiding statics, and making sure any saved file or similar can be linked to a specific instance.
Together these things enable me to later create a raspberry pi server that contains a few of these ai's, that can then be reached and interacted with through a desktop or mobile application.

---
Everything after this has been re-written due to me forgetting to commit my changes, losing more than one hour of documentation. I was really happy with the earlier documentation I did, but I also do not remember how I wrote it. So this should still cover everything, but formatting and writing will be way worse. But it is what it is. Lesson learned, do not write documentation using githubs web editor without commiting every 10 minutes or something. :/

---
# Change of scope

After finishing the basic interfaces and the ui application I decided to start with the machine learning part. But due to me not having a concrete plan for what the machine learning would actually do, I ended up with a blank canvas. For good, and bad. Good, I could make the goal whatever I wanted. Bad? I wouldn't have a set plan that I could follow, which could cause me to set a goal too big. And that is sadly what happened. Now after it is super clear how many things I did wrong in this stage.

First of all, I didn't have a set plan. I ended up spending quite a lot of time trying to figure out what I want to do. And second, I decided to focus on the machine learning first, and leave the smaller parts for later. This is *very* bad, since I was not focusing on the important core of the project, but instead a side thing that was supposed to be a cool extra on the side.

Sadly though, I didn't realise this at that time, and continued work. I ended up going for a text based machine learning algorithm that I want to be able to learn information, and then guess objects and similar based on what it knows, and what clues the user gives.

---
# Machine learning planning













Ai Companion summer project.

---
# The base idea

The original idea for this project was a simple ai companion like the old toys people had back in the day with some homemade machine learning thrown in. 
But sadly I let it run a bit out of scope, and ended up focusing too much on the machine learning part.

But at least I have made some progress on that, of which I will now explain to you.

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
## Lost documentation
Everything after this has been re-written due to me forgetting to commit my changes, losing more than one hour of documentation. I was really happy with the earlier documentation I did, but I also do not remember how I wrote it. So this should still cover everything, but formatting and writing will be way worse. But it is what it is. Lesson learned, do not write documentation using githubs web editor without commiting every 10 minutes or something. :/

---
# Change of scope

After finishing up the interfaces and ui application, I moved on to start on the companion part. I made the base class, connected it up with the ui app, and started thinking about the next step. I could create some basic companion logic, like energy, food, or similar. Not big tasks really. The biggest challenge was of course the machine learning part. I had no plan. I never tried something like it before. So clearly, it would take the most time, so why not start with that?

I started by trying to decide on a goal, and quite quickly came to the conclusion that something with appropriate difficulty would be a text based ai that would learn from user input, and then use the knowledge to try and guess objects based on clues. This is where the project changed scope. I didn't realise it then, but now I can clearly see two large issues with these decisions. First, this machine learning thing is not impossible, but would be quite troublesome in the timeframe I had while also doing the other parts needed. And second, I did things in the completely wrong order. I should not do the hardest thing first, but rather get the easy parts done so I have something in case of the large thing taking too much time.

So basically, the project went from being a companion program, with some machine learning thrown into it. To a machine learning program that might in the end be a part of a ai companion.

---
# Machine learning plans

Now that I had changed the goal, and knew what I wanted, I could get to work. And the first question of course is, how do I make a program learn?

This is where the majority of the time was spent. Because I wanted to have a good data structure to handle the knowledge. So I started trying to figure out if I could somehow make a data structure that mimics how our brains remember objects. These are some of my notes written about the subject.
```
	In us humans, it to me feels like our object-memories are actually just associations of one thing with another.
	So for example, the word car to us is associated with a mental image of a car. Which we then can link with the
	word 4 wheels. Or any other car identification wording. So what I think I need to do is to come up with something
	similar. I need a storage medium representing kind of a mind map. One main subject, and many sub-subjects. 
	If the subject is car, we want it the ai to be able to add information about cars when given, and if the user
	presents similar information, but a bit different, then we want the ai to express doubt and ask if the user is 
	certain.

	"is a" can be a special word used to link two things together. For example, a user input of "Hello is a greeting"
	would tell the program to create a new memory for "greeting", and add "hello" to the list of "implemnters"

	"has a" or "have a" would be similar but instead of adding the word to the list, it would add it as a criteria
	for implementers in the list. Kind of like a interface.

	Seeing this, it more feels like object-memory is actually just a lot of interfaces. When we think of a object,
	we already have a preset "interface" that defines what we expect that type of oject will have or contain.
```

Based on this I decided on the following data structure.

```cs
public class Memory
{
  public string Title;
  public List<Memory> ChildMemories;
  public List<Memory> IsMemories;
  public List<Memory> HasMemories;
}
```

Each instance of the memory class would contain all the information about one object, and possible connections with other objects.\
`Title` would be the name of the object.\
`ChildMemories` would contain all memories that is this object. For example, the object `car` could have a child memory with title `toyota prius`.\
`IsMemories` would in turn contain all memories that this object is. Kind of the reverse of the above example. \
`HasMemories` instead contains all things the object has. Things that define it kind of. If we keep using the `car` as a example, it could here have `wheels`.


---
# Development part 1

As I started implementing the Memory class and surrounding systems, I needed to also have some way to handle user input. For this, I used a command based system of `thought` interfaces. The idea was to make all computation done by the ai be done in a brain loop together with a short term memory. (Again, *very* out of scope here.)
The start of this was to simply make a `hear` thought, that would be created for a users input. This thought in turn would split up the words and call a `analyzeWord` thought. This is kind of where my momentum stopped, because I didn't really want to hard code in certain actions based on specific words. I still kept going a bit but didn't really get much further than this when it comes to the thoughts.

---
# A side branch

The original plan was to have the data structure shown above, but it had one flaw. I wanted to store it in RAM, and while not impossible, it would limit what I could do. So I started thinking about a better way to do it. (Realising as I am writing this that this again is just horrible dicipline towards the project goal. If it is not a problem, do NOT waste time fixing it.)

One way would be to store everything on disk. A lot slower yes, but speed is not the important thing here, but rather the capacity and ease of use for me. After some thinking and prototyping, I changed the data structure to this instead:

```cs
public class Memory
{
  public string Title;
  public List<string> ChildMemories;
  public List<string> IsMemories;
  public List<string> HasMemories;
}
```

Together with a save and loading system I could have a memory struture that not only has a much higher capacity, but also editable by me outside of the program running due to it being stored in easy to understand json. One example would be something like this:

```json
{
	"title":"car",
	"isMemories":["vehicle","rectangular"],
	"hasMemories":["wheels","windows","lights","doors","seats"],
	"childMemories":["volvo v70","tesla model x","toyota prius"]
}
```


I don't know what I expected, but making your own machine learning algorithm is not just a walk in the park, especially when you don't have a set goal. So I ended up spending way to much time planning that feature. I decided on making it a text based ai, that would be able to learn based on user input, and then use that knowledge to match clues with objects. 





After finishing the basic interfaces and the ui application I decided to start with the machine learning part. But due to me not having a concrete plan for what the machine learning would actually do, I ended up with a blank canvas. For good, and bad. Good, I could make the goal whatever I wanted. Bad? I wouldn't have a set plan that I could follow, which could cause me to set a goal too big. And that is sadly what happened. Now after it is super clear how many things I did wrong in this stage.

First of all, I didn't have a set plan. I ended up spending quite a lot of time trying to figure out what I want to do. And second, I decided to focus on the machine learning first, and leave the smaller parts for later. This is *very* bad, since I was not focusing on the important core of the project, but instead a side thing that was supposed to be a cool extra on the side.

Sadly though, I didn't realise this at that time, and continued work. I ended up going for a text based machine learning algorithm that I want to be able to learn information, and then guess objects based on what it knows, and what clues the user gives.

---
# Machine learning planning













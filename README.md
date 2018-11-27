# Code Review - 2018

ProjectL is the codename of a small game that I wrote for a friend's birthday two years ago. It took about 2 and a half months of development and some of it was very rushed due to needing to spend most of my time on my actual full-time job.

This README is going to serve as a personal code review of my own code (because two years of learning does a lot)

* <b>Singleton Hell</b><br>
I really seemed to enjoy abusing the Singleton pattern back then and it makes me cringe. Maybe I was trying to develop things quick but this is not typically something I encourage doing in my architecture. Typically, I try and keep my components as centralized as possible, and not really known to the outside, and instead I use something like a notification center to delegate information in between systems. This allows for better encapsulated code and typically just makes things a lot easier to track.

* <b>Lack of RequireComponent</b><br>
I'm surprised I see this a lot in my code as well: the lack of the RequireComponent tag. For instance, in ParallaxScroller, there's a private Renderer variable and I do a GetComponent<Renderer> in the Awake call. There is no ensuring that the ParallaxScroller is paired up with a Renderer. Bleh. Another pattern would be to see if GetComponent returns a Renderer, and if not, just add one.

* <b>Lack of Proper Data</b><br>
So this is definitely due to the lack of time on the project. You can see, especially in PoolManager, that I manually type in the names of the prefabs I want to pool. I mean, I'm impressed with the fact that I'm using the pool concept for such a small game, but this is just really not easy to expand on and if a prefab changes name, I'm doomed. This is the kind of thing I could potentially put in a ScriptableObject with a link to the actual GameObject: it's expandable, and very clear, and it's protects from rename problems.

* <b>PoolManager is Too Specific</b><br>
The ReturnGameObject function makes me want to barf. It's WAY too specific. I should have had the individual components have like an OnRecycle or OnDeSpawn function that would handle these things (like cutting audio and other things needing stopping). The pool creation and GetGameObject functions aren't too bad though.

* <b>Error Handling is Weak</b><br>
I'm looking at my PrefabSpawner script and screaming at myself for not putting a Debug.LogError when returning if the path to the prefab is empty. If the prefab doesn't spawn, my system says nothing and thus the programmer (me) will get lost and not really know what happened. 

* <b>PrefabSpawner Path</b><br>
Path shouldn't be a string. This is very error-prone. This should be a GameObject link directly that we just instantiate a copy of when loading the prefab.

* <b>PopupManager Isn't Needed</b><br>
I don't like how I handled popups in this game. I could have simply used the Scene system and layered scenes, but it's possible I was not used to this pattern in this version of Unity (?) I'm not really sure.

* <b>So Many Colliders. Why?</b><br>
If you check in MovableObjects, you'll notice a plethora of Collider scripts that ESSENTIALLY check for the same thing but they do specific things. Instead, I would have a global Collision dispatcher that an object can listen to and it will simply dispatch an event when something collides. This way, the specificity of the collision detection can go in another class. This would allow for less Collider scripts 

* <b>My UI Code</b><br>
If you want to see how much I rushed this project, just look at my UI code. It's pretty horrendous.

<b> Final Notes </b><br>
While I'm not entirely displeased with this codebase, it's clear that I grew a lot in the past two years as I can easy go through this code and endlessly tear it apart. Its architecture is very flimsy and there's a general lack of usability for content. I can assure that I am a lot better than this now.

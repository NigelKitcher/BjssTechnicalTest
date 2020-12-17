Task:

Write a game where a single user can play this game against two computer opponents, one computer opponent should play without skill, the other should be more skilful.

Include a simple CLI or GUI.

Solution:

The solution is complete and working with some caveats. 

The solution could do with further work especially in refactoring to provide more testing capability most notably around the consumption of the service,
especially in the UI. The test coverage should be high on the core services (I don't have Enterprise Edition to confirm levels). 

The user control and forms have been written towards the MVP pattern, however the necessary project ("Bjss.Library.UI.Adapters") to provide the interfaces
and adapters to provide mocking of the standard Winforms controls had not been included. 
This would come in part from a library that I have built up over many years.

As the MainForm is not fully refactored to MVP it contains more business logic that I would have liked and I have started moving the game control to a "GameManager" class 
to handle the "player turn" management. This refactoring I have no yet completed so there is some duplication of code. Note that "GameManager" remains unused how has
been left in to show the direction I was taking.

I am a little unhappy about the managing of the move by the human player as that should just be polymorphic from the "TakeTurn" method on the player. Had I progressed the
GameManager class further then I would have developed further along that line of code. What that code would be like from the developers experience as 
it would need to block and be unblocked by manual intervention I am not 100% sure yet and would need some feeling around (maybe a WaitOne and the Player being signaled?)

Have added CA rule sets however I have turned them off for the build. Normally I would run with them on and zero warnings. Seems theres some issues running in VS2019 
and the new build process/roslyn rules so I've not investigated that further (out of scope for this tech task).

Have added the ability in the UI to sneak at other players cards. 

Note that the Advanced game play strategy could really do with having the IRandomGenerator injected into
it to provide some randomise when there is more than one card which provides equal benefit to the player. This is an addition and unit tests would need to be added 
along the lines of the card shuffling unit tests as of course the testing needs to be deterministic - hence the IRandomGenerator.





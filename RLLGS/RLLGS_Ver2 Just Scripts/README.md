
# Rapid LootLocker Guest Setup (RLLGS / RGLL)
RGLLS is a module/asset for setting up a leaderboard system in Unity using LootLocker Guest mode as quickly as possible,
 which I had firstly started to code for my first game 'Simply Dodge'
 that I decided to make more modular and share it afterwards for public usage
 which braught me and technically you here.

This is almost the code which what I've used in my game 'Simply Dodge'
 (Check it out here, it is playable on browser too so no excuses) (https://samethope.itch.io/simply-dodge)
which you can check out to have a picture in your mind. The sample included is very similiar to my game code too.

Because this asset/module was at first was designed for private usage
and it being my first open source and modular code,
 it may suck, so beware of that. However I have commented and wrote it as 
 good as I can, so it isn't really bad. At least I have seen much worse ones lol.

Btw for the license, also see https://choosealicense.com/licenses/gpl-3.0/ 



## Sample
Forenote: Also read the README on the sample.

There is optional sample scene and some scripts provided that should help one a lot
to start rolling if someone ever really uses this. 

It contains a scene with a very basic 'game' and implementation of the RLLGS.

The game is a GUI with 3 pages
- Start page
- Game page
- Leaderboard page
The start and game pages are what your app would have and the
Leaderboard page is where the actual implementation resides.
  
Start page only has one button which takes you into the game page.

Game page has 2 buttons. 
One of them generates a random number and stores It.
This is later used as a 'score' and updates GUI.
 The other button changes the page 
to Leaderboard page. This change is what would be equivalent to game over.

1. In the Leaderboard page, there is 'LeaderboardUpdater' which gets triggered when it is enabled. 
When triggered it fetchs the leaderboard and calls the methods from given 'ILeaderBoardUpdateBehaviour' interface. The leaderboard id etc are also provided in the interface.

2. The implementation of the interface, 'LeaderboardUpdater', Updates the UI of the page with custom logic using the data from 'LeaderBoardUpdater'.

3. In the UI a button and input field is given. When the submit button is clicked, the 'SubmitterExample' 
calls methods from the 'RLLManager' to submit the name and then the score, and then updates the leaderboard.







# Usage
Also see 'Sample' title above.
- Add 'RLLManager.cs' to any of your gameObject.
- Add 'LeaderBoardLoader.cs' to any of your gameObject.
- Implement 'ILeaderBoardUpdateBehaviour' in one of your scripts.
- Configure and add the relevant objects from the inspector.
- Call 'SetName()' or 'SubmitScore()' on the RLLManager, and 'FetchHighscores()' on the LeaderboardUpdater when needed.
- Enjoy.

I am tired of explaining stuff that most likely no one even read and might change so I am cutting here. If one really wants to implement this just check out the sample. It is simple AF. Thanks.
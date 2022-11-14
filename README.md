
# Rapid LootLocker Guest Setup (RLLGS / RGLL / RLL)

RGLLS is a module for setting up a leaderboard system in Unity using LootLocker Guest mode as rapidly.
I had started to code this as non-module for my first game 'Simply Dodge'
but then decided to modularise to use it in my future projects and share it for 2 persons that might randomly come across it.

This is almost exactly the same code which what I've used in my game 'Simply Dodge': https://samethope.itch.io/simply-dodge

I also published the 'Sample' provided here on itch too so you can check it out real fast: https://samethope.itch.io/rllgs-sample.

Notice: Because this module was at first was designed for private usage
and because of it being my first open source and first repo, it is not perfect in these manners.
But I documented and commented and explained it as much as I can anyway so you should be fine.



# Sample (.unitypackage and/or itch sample)

Forenote: If you really want to see and learn about/from the sample, just
check out https://samethope.itch.io/rllgs-sample and download the '.unitypackage', 
file provided here and import it. Taking some peeks at the code and 
project structure should be enough for one to get rolling
 and not read some wall of text below.

Also notice this whole repo is technically the '.unitypackage' without meta files.

## Sample game
The sample contains a single scene with a very basic game and implementation of the RLLGS.

The game is a GUI with 3 pages
- Start page
- Game page
- Leaderboard page
The start and game pages are what your app would be and
the leaderboard page is where the actual implementation
of the module resides.

1. In the Leaderboard page, there is 'LeaderboardUpdater'
 which gets triggered when it gets enabled. In this case 
 when the game 'ends'.
When triggered, it fetchs the leaderboard and calls the
 methods from given 'ILeaderBoardUpdateBehaviour' interface.
  The leaderboard id etc are also provided in the interface.

2. The implementation of the interface, 'LeaderboardUpdater',
 Updates the UI of the page with custom logic using the data
  fetched from from 'LeaderBoardUpdater'.

3. In the UI a button and input field is given.
 When the submit button is clicked, the 'SubmitterExample' 
calls methods from the 'RLLManager' to submit
 the name and then the score, and then updates the leaderboard.

Also see README of the Sample.



# Usage
Not a total guide but rather how I use it.
- Import .unityAsset package with the sample.
- Create a gameObject called 'RLLManager' and add 'RLLManager.cs' script
     to it. Have it as a parent gameObject and set useSingletonMode to true.
- Add 'LeaderBoardLoader.cs' to any of your gameObject and set
     its options accordingly for your purposes.
- Implement 'ILeaderBoardUpdateBehaviour' in one of your scripts.
     Or just copy the implementation from the Sample and modify it.
- Configure/modify/set the project and leaderboard ids and UI for usage.
- Call 'SetName()' or 'SubmitScore()' on the RLLManager,
     and 'FetchHighscores()' on the LeaderboardUpdater when needed.
- Enjoy.

## Extra

For the license, also see https://choosealicense.com/licenses/gpl-3.0/ 

Also see the README file in the sample.
Obviously you need LootLocker SDK itself too.

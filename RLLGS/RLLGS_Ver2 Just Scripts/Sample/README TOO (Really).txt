The License on parent folder does also apply for files in this folder including this text file.

For the sample to work, YOU MUST:
- Have LootLocker installed and configured (see https://docs.lootlocker.com/the-basics/unity-quick-start)
- Set LeaderBoard ID from LeaderBoardUpdateBehaviour gameObjects inspector

Also notice:
- Scores get updated the way you set them on the web console, such as getting overrided or getting updated only if the new score is higher.
- If the new score is not higher, the name will get updated anyway if it is different (Which is intended behaviour in the context, as it can be seen on the code).
- Unique ID is stored on PlayerPrefs and generated on the first run. So to have multiple scores on the board, you must clear the relevant PlayerPrefs.
- Also see https://docs.lootlocker.com/the-basics/core-concepts/stage-and-live-environments (especially the development mode part, which may or may not be the whole content lol) 

If you have any questions/suggestions/problems related, contact me. (Use discord if possible btw)
- Discord: SametHope#3079
- Github: https://github.com/SametHope
- Itch: https://samethope.itch.io/

Btw, this sample is almost same as my implementation on my first game 'Simply Dodge',
You can check it out to have an idea and realise how similiar the sample project and the implementation in my game are.
Link: https://samethope.itch.io/simply-dodge 
(it is playable on browser and mobile etc, so if you are reading this you can probably check it out right away without doing any download)

Thank you for reading.

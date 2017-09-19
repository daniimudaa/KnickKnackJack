# Branching
Always ensure you're working on your own branch, as it won't let you push if you aren't in sync (if somebody else makes a change), and it won't let you pull if you have made your own changes that aren't pushed yet

The below guide mentions the fetch origin, the push origin and the publish branch buttons, they are the same button, the text just changes based on what will be done when you click it.
Since I don't know what GitHub for Desktop calls the remote when it clones the repository, the word origin in said buttons might be a different word that is semi-related to origin.  

Creating a new branch
-----
1. Make sure that your current branch is the one you want to start from (usually master), that dropdown is in top middle of the screen (if you have any uncommitted changes, I'd advise against switching branches)
2. Push whatever changes you've made by clicking thte "push origin" button
3. Make sure you have the latest version of that branch by clicking on the top-middle-left button (usually Pull, or fetch origin or something along the lines)
4. On the top menu, click branch -> New Branch.
5. Name it accordingly with dashes ( - ) instead of spaces, start with your name, then dash, and then the name of the branch. For example arthur-new-animations. That name cannot be the same as another currently active branch.  
(I recommend creating a new branch for each new feature)
6. Click create branch
7. To ensure everybody sees your branch, click "publish branch" (same place as the fetch origin button).

Things to keep in mind
------
If anyone ever commits anything to master, don't fret, as long as nobody else does, you'll be able to just push the changes. (although don't risk it)
Ensure you commit regularly, and leave helpful descriptions of what you changed, that way if you mess up, you can easily go back.

Merging into master when done
-----
Next thing is, after you're done working on said new feature, you'd want to merge it to master so that everyone is updated when they pull master and have your changes to play with as well, to do this, do the following:

1. Make sure that all your changes are committed in your current branch.
2. Switch to the master branch
3. Ensure you pull the current state of master using the aforementioned "fetch origin" button (the text changes based on what should be done, but it is always in the same place)
4. In the top menu, click Branch -> Merge to current branch
5. Select your branch (please ensure that you don't mess up and select somebody else's branch, or else, that'll make them very ?? and not want to be your friends anymore)
6. Click on "Merge into master" on the bottom
7. Click on the "push origin" button

Rinse and repeat from the top for any new features.
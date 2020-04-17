# zeus-game

#### Branch Structure

##### Master Branch
 - Purpose is to be the most stable branch that ideally has no bugs. Content should be tested well enough and possibly code-reviewed (if we feel like it) to have new code merged in. Only the Beta branch should be merged into master and for now requires approval from 4 members.

##### Test Branch
 - Purpose is to be the most recent branch that has features from each member merged into it for testing. Serves as the branch that is eventually merged into master. Individual test branches are merged into beta and required 2 approvals from members.
 
##### Personal Branches
 - Purpose is to give each member a branch to test and development their changes on and to safely stash their changes on. Only the member who shares the branch name can write and merge into their personal branch.
 
#### GIT actions
#####
 - GIT is used for version control. It is compromised of remote branches that are stored remotely as well as local branches that are stored locally on the machine.
##### Commit
 - Commits the changes you have made to your local branch. Requires a branch to first be checked out.
##### Pull
 - Pulls the changes that are stored on a remote branch.
##### Push
 - Pushes your changes to the remote version of a branch that is checked out locally.
##### Fetch
 - Fetches the latest branches of the repository. Needed to get the latest versions of remote branches so it is suggested before every pull.
##### Branch
 - Creates a new sub-branch from a parent-branch (Might want to branch off your test branch for a specific issue that you are tackling, helps keeps your stuff organized and isolated).
##### Merge
 - Merges a remote branch into another remote branch. Ideally is used to push changes from a sub-branch into a parent-branch in order to update said parent-branch with the child's changes.

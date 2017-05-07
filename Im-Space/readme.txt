

# merge to branshes 

git checkout <target_branch_name>
git pull origin <target_branch_name>
git merge <source_branch_name>
git push origin <target_branch_name>


# Delete Remote Branch
git push origin --delete <branch_name>
git push origin :<branch_name>

# Delete Local Branch
git branch -d <branch_name>
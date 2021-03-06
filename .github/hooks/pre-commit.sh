#!/bin/bash
# Stops accidental commits to master/main/develop. https://gist.github.com/stefansundin/9059706
# Install:
# cd path/to/git/repo
# curl -fL -o .git/hooks/pre-commit https://gist.githubusercontent.com/stefansundin/9059706/raw/pre-commit
# chmod +x .git/hooks/pre-commit

BRANCH=`git rev-parse --abbrev-ref HEAD`

if [[ "$BRANCH" =~ ^(main)$ ]]; then
  echo "You are on branch $BRANCH. Are you sure you want to commit to this branch?"
  echo "If so, commit with -n to bypass this pre-commit hook."
  exit 1
fi

exit 0
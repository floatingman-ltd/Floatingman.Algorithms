dotnet watch \
  --project $1 \
  test \
  /p:CollectCoverage=true \
  /p:CoverletOutput="./lcov.info" \
  /p:CoverletOutputFormat=\"lcov\" 
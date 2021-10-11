#!/bin/bash

# NOTE: In order to contain XML docs (documentation for the C# code), THERE IS NO CLI ARG FOR THIS COMMAND TO GENERATE IT!
#       It MUST BE SET in the .csproj file, and may look like the following for example:
# 
# <PropertyGroup>
#    <GenerateDocumentationFile>true</GenerateDocumentationFile>
# </PropertyGroup>

# NOTE: How to check if string variable exists (is not null ("null" is just an empty string in Bash)):
#   https://stackoverflow.com/questions/51440450/bash-operators-vs-z
if [ ! "$GITHUB_CPG_PACKAGE_API_KEY" ]; then
    echo "The \"\$GITHUB_CPG_PACKAGE_API_KEY\" environment variable is required to push the NuGet package to Github."
    echo "The key must be set to a Github PAT (Personal Access Token) with package read/write access rights."
    exit 1
fi

projects=(
    "CometPeak.AssertionExceptions"
)
version="0.1.2"
configuration="Debug" # Must be DEBUG! (See README.md)
packageURL="https://nuget.pkg.github.com/cometpeakgames/index.json"

dotnet build --configuration $configuration

# --- --- --- --- ---
# --no-build
#       - DOES NOT mean it doesn't include the build output
#       - It just means it doesn't do an additional build (saves processing time)
# --include-source
#       - This will generate:
#           1. ExampleProject.0.1.0.nupkg               (The regular NuGet Package with built DLLs)
#           2. ExampleProject.0.1.0.symbols.nupkg       (The NuGet Package with built DLLs AND SOURCE CODE (C#))
dotnet pack --configuration $configuration --no-build --include-source


# --- --- --- --- ---

for project in ${projects[@]}; do
    echo "Pushing NuGet package for $project..."

    # Not sure why this delete command doesn't work..
    # dotnet nuget delete --source "$packageURL" --api-key $GITHUB_CPG_PACKAGE_API_KEY $project $version --non-interactive

    dotnet nuget push --skip-duplicate "$project/bin/$configuration/$project.$version.symbols.nupkg" --source "$packageURL" --api-key $GITHUB_CPG_PACKAGE_API_KEY
done



@echo off

msbuild /t:pack /p:Configuration=Release src/BetterLinq/BetterLinq.csproj

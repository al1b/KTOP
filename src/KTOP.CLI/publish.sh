#!/bin/sh

dotnet restore
dotnet publish -r debian.8-x64
dotnet publish -r ubuntu.14.04-x64
dotnet publish -r ubuntu.16.04-x64
dotnet publish -r win7-x64
dotnet publish -r osx.10.10-x64
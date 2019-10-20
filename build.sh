#!/bin/bash
if test "$OS" = "Windows_NT"
then
    cmd /C build.cmd
else
    dotnet build
fi
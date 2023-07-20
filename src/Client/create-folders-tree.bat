@echo off

REM Define the folder to copy
set "sourceFolder=D:\Samak\share-safe\share-safe-blazor-wasm\src\Client"

REM Define the list of folders to exclude
set "excludeFolders=dll"

REM Create a new text file
set "notepadFile=D:\Samak\share-safe\share-safe-blazor-wasm\src\Client\tree.txt"

REM Generate the tree structure using PowerShell command
powershell.exe -Command "tree /F '%sourceFolder%' | Where-Object { $_ -notmatch '%excludeFolders%' } | Out-File -FilePath '%notepadFile%' -Encoding UTF8"

REM End of script
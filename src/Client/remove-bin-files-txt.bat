@echo off
setlocal enabledelayedexpansion

set "input_file=D:\Samak\share-safe\share-safe-blazor-wasm\src\Client\tree.txt"
set "temp_file=%input_file%.tmp"

REM Set a flag to indicate if we are between the target lines
set "inside_section="

REM Create or empty the temporary file
type nul > "%temp_file%"

REM Loop through the lines of the input file
for /f "usebackq delims=" %%a in ("%input_file%") do (
    REM Check if the line contains the start marker
    echo %%a | findstr /c:"+---bin" >nul
    if not errorlevel 1 (
        REM If we find the start marker, set the flag
        set "inside_section=true"
    )

    REM If the flag is set, we are between the target lines
    if defined inside_section (
        REM Check if the line contains the end marker
        echo %%a | findstr /c:"+---Components" >nul
        if not errorlevel 1 (
            REM If we find the end marker, reset the flag
            set "inside_section="
        )
    )

    REM If the flag is not set, write the line to the temporary file
    if not defined inside_section (
        echo %%a>>"%temp_file%"
    )
)

REM Replace the original file with the modified content
move /y "%temp_file%" "%input_file%"

echo Deletion complete.
pause

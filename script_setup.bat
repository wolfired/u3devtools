@call .\script_const.bat

if exist %SLN_PATH%\%SLN_NAME%.sln (
    exit /B 0
)
dotnet new sln -o %SLN_PATH%


dotnet new classlib -o %PRJ_PATH_UTILS%
del %PRJ_PATH_UTILS%\*.cs
if exist %PATH_U3D% (
    if exist %PRJ_PATH_UTILS%\%PRJ_NAME_UTILS%.csproj.bak (
        xcopy /Y /R %PRJ_PATH_UTILS%\%PRJ_NAME_UTILS%.csproj.bak %PRJ_PATH_UTILS%\%PRJ_NAME_UTILS%.csproj
    )
)
dotnet sln %SLN_PATH% add %PRJ_PATH_UTILS%

dotnet new xunit -o %PRJ_NAME_UTILS%.tests
del %PRJ_NAME_UTILS%.tests\*.cs
dotnet add %PRJ_NAME_UTILS%.tests reference %PRJ_PATH_UTILS%
dotnet sln add %PRJ_NAME_UTILS%.tests


dotnet new classlib -o %PRJ_PATH_ARTIST%
del %PRJ_PATH_ARTIST%\*.cs
if exist %PATH_U3D% (
    if exist %PRJ_PATH_ARTIST%\%PRJ_NAME_ARTIST%.csproj.bak (
        xcopy /Y /R %PRJ_PATH_ARTIST%\%PRJ_NAME_ARTIST%.csproj.bak %PRJ_PATH_ARTIST%\%PRJ_NAME_ARTIST%.csproj
    )
)
dotnet add %PRJ_PATH_ARTIST% reference %PRJ_PATH_UTILS%
dotnet sln %SLN_PATH% add %PRJ_PATH_ARTIST%


dotnet new classlib -o %PRJ_PATH_SAMPLE%
del %PRJ_PATH_SAMPLE%\*.cs
if exist %PATH_U3D% (
    if exist %PRJ_PATH_SAMPLE%\%PRJ_NAME_SAMPLE%.csproj.bak (
        xcopy /Y /R %PRJ_PATH_SAMPLE%\%PRJ_NAME_SAMPLE%.csproj.bak %PRJ_PATH_SAMPLE%\%PRJ_NAME_SAMPLE%.csproj
    )
)
dotnet add %PRJ_PATH_SAMPLE% reference %PRJ_PATH_UTILS%
dotnet sln %SLN_PATH% add %PRJ_PATH_SAMPLE%


dotnet new console -o %PRJ_PATH_XLS2LUA%
del %PRJ_PATH_XLS2LUA%\*.cs
dotnet add %PRJ_PATH_XLS2LUA% package ExcelDataReader
dotnet add %PRJ_PATH_XLS2LUA% package ExcelNumberFormat
dotnet add %PRJ_PATH_XLS2LUA% package ExcelDataReader.DataSet
dotnet add %PRJ_PATH_XLS2LUA% package System.Text.Encoding.CodePages
dotnet add %PRJ_PATH_XLS2LUA% package Mono.Options
dotnet sln %SLN_PATH% add %PRJ_PATH_XLS2LUA%

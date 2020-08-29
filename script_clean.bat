@call .\script_const.bat

::
if not exist %SLN_PATH%\%SLN_NAME%.sln (
    exit /B 0
)
if exist %SLN_BIN% rmdir /S /Q %SLN_BIN%
if exist %SLN_PATH%\%SLN_NAME%.sln del %SLN_PATH%\%SLN_NAME%.sln


::
if exist %PRJ_PATH_UTILS%\bin rmdir /S /Q %PRJ_PATH_UTILS%\bin
if exist %PRJ_PATH_UTILS%\obj rmdir /S /Q %PRJ_PATH_UTILS%\obj
if exist %PRJ_PATH_UTILS%\%PRJ_NAME_UTILS%.csproj del %PRJ_PATH_UTILS%\%PRJ_NAME_UTILS%.csproj

if exist %PRJ_NAME_UTILS%.tests\bin rmdir /S /Q %PRJ_NAME_UTILS%.tests\bin
if exist %PRJ_NAME_UTILS%.tests\obj rmdir /S /Q %PRJ_NAME_UTILS%.tests\obj
if exist %PRJ_NAME_UTILS%.tests\%PRJ_NAME_UTILS%.tests.csproj del %PRJ_NAME_UTILS%.tests\%PRJ_NAME_UTILS%.tests.csproj

::
if exist %PRJ_PATH_ARTIST%\bin rmdir /S /Q %PRJ_PATH_ARTIST%\bin
if exist %PRJ_PATH_ARTIST%\obj rmdir /S /Q %PRJ_PATH_ARTIST%\obj
if exist %PRJ_PATH_ARTIST%\%PRJ_NAME_ARTIST%.csproj del %PRJ_PATH_ARTIST%\%PRJ_NAME_ARTIST%.csproj


::
if exist %PRJ_PATH_SAMPLE%\bin rmdir /S /Q %PRJ_PATH_SAMPLE%\bin
if exist %PRJ_PATH_SAMPLE%\obj rmdir /S /Q %PRJ_PATH_SAMPLE%\obj
if exist %PRJ_PATH_SAMPLE%\%PRJ_NAME_SAMPLE%.csproj del %PRJ_PATH_SAMPLE%\%PRJ_NAME_SAMPLE%.csproj


::
if exist %PRJ_PATH_XLS2LUA%\bin rmdir /S /Q %PRJ_PATH_XLS2LUA%\bin
if exist %PRJ_PATH_XLS2LUA%\obj rmdir /S /Q %PRJ_PATH_XLS2LUA%\obj
if exist %PRJ_PATH_XLS2LUA%\%PRJ_NAME_XLS2LUA%.csproj del %PRJ_PATH_XLS2LUA%\%PRJ_NAME_XLS2LUA%.csproj

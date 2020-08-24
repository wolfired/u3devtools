@call .\script_const.bat

if not exist %SLN_PATH%\%SLN_NAME%.sln (
    exit /B 0
)

if exist %SLN_BIN% rmdir /S /Q %SLN_BIN%
if exist %SLN_PATH%\%SLN_NAME%.sln del %SLN_PATH%\%SLN_NAME%.sln

call .\scripts\script_cln_prj.bat %PRJ_PATH_UTILS% %PRJ_NAME_UTILS%
if exist %PRJ_NAME_UTILS%.tests\bin rmdir /S /Q %PRJ_NAME_UTILS%.tests\bin
if exist %PRJ_NAME_UTILS%.tests\obj rmdir /S /Q %PRJ_NAME_UTILS%.tests\obj
if exist %PRJ_NAME_UTILS%.tests\%PRJ_NAME_UTILS%.tests.csproj del %PRJ_NAME_UTILS%.tests\%PRJ_NAME_UTILS%.tests.csproj

call .\scripts\script_cln_prj.bat %PRJ_PATH_ARTIST% %PRJ_NAME_ARTIST%

call .\scripts\script_cln_prj.bat %PRJ_PATH_SAMPLE% %PRJ_NAME_SAMPLE%

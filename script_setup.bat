@call .\script_const.bat

if exist %SLN_PATH%\%SLN_NAME%.sln (
    exit /B 0
)

call .\scripts\script_new_sln.bat %SLN_PATH%

call .\scripts\script_new_prj.bat %SLN_PATH% %PRJ_PATH_UTILS% %PRJ_NAME_UTILS% %PATH_U3D%
dotnet new xunit -o %PRJ_NAME_UTILS%.tests
del %PRJ_NAME_UTILS%.tests\*.cs
dotnet add %PRJ_NAME_UTILS%.tests reference %PRJ_NAME_UTILS%
dotnet sln add %PRJ_NAME_UTILS%.tests

call .\scripts\script_new_prj.bat %SLN_PATH% %PRJ_PATH_ARTIST% %PRJ_NAME_ARTIST% %PATH_U3D%
dotnet add %PRJ_PATH_ARTIST% reference %PRJ_PATH_UTILS%

call .\scripts\script_new_prj.bat %SLN_PATH% %PRJ_NAME_SAMPLE% %PRJ_NAME_SAMPLE% %PATH_U3D%
dotnet add %PRJ_PATH_ARTIST% reference %PRJ_PATH_UTILS%

@call .\script_const.bat

::
if not exist %SLN_PATH%\%SLN_NAME%.sln (
    exit /B 0
)

dotnet run --project %PRJ_PATH_XLS2LUA% -c %SLN_CONFIGURATION% %SLN_PATH% -- --search_path=E:\workspace_pg\slg_config\source --file_out=C:\workspace_pg\slg\Assets\Lua\Config\Client\xls.d.lua

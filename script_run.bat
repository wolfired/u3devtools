@call .\script_const.bat

::
if not exist %SLN_PATH%\%SLN_NAME%.sln (
    exit /B 0
)

dotnet run -p %PRJ_PATH_XLS2LUA% -c %SLN_CONFIGURATION% %SLN_PATH% -- --search_path=E:\workspace_pg\slg_dev_tools\gen_config\source --blacklist=f_time_task --file_out=E:\workspace_pg\slg-trunk-client\Assets\Lua\Config\Xls\xls.d.lua

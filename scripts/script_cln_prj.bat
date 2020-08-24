:: 清空dotnet项目
:: Usage
:: call path\to\script_cln_prj prj_path prj_name

set prj_path=%~1
set prj_name=%~2

if exist %prj_path%\bin rmdir /S /Q %prj_path%\bin
if exist %prj_path%\obj rmdir /S /Q %prj_path%\obj
if exist %prj_path%\%prj_name%.csproj del %prj_path%\%prj_name%.csproj

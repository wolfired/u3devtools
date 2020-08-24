:: 新建dotnet项目
:: Usage
:: call path\to\script_new_prj sln_path prj_path prj_name u3d_path

set sln_path=%~1
set prj_path=%~2
set prj_name=%~3
set u3d_path=%~4

dotnet new classlib -o %prj_path%
del %prj_path%\*.cs
if exist %u3d_path% (
    if exist %prj_path%\%prj_name%.csproj.bak (
        xcopy /Y /R %prj_path%\%prj_name%.csproj.bak %prj_path%\%prj_name%.csproj
    )
)
dotnet sln %sln_path% add %prj_path%

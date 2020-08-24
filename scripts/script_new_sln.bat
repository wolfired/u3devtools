:: 新建dotnet解决方案
:: Usage
:: call path\to\script_new_sln sln_path

set sln_path=%~1

dotnet new sln -o %sln_path%

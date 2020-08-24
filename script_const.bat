@echo off

:: U3D安装目录
set PATH_U3D=D:\Unity.2019.4.6f1

:: 解决方案名称
for /f %%q in ("%~dp0.") do set SLN_NAME=%%~nxq
:: 解决方案目录
for /f %%q in ("%~dp0.") do set SLN_PATH=%%~dpnxq

:: 解决方案输出目录
set SLN_BIN=%SLN_PATH%\bin
:: 解决方案编译模式
set SLN_CONFIGURATION=Debug

:: 辅助工具项目
set PRJ_NAME_UTILS=utils
set PRJ_PATH_UTILS=%SLN_PATH%\%PRJ_NAME_UTILS%
:: 编译完成后自动部署目录
set PRJ_PATH_COPYTO_UTILS=E:\workspace_u3d\u3devtools\Assets\Plugins

:: 美术资源导入自动化处理项目
set PRJ_NAME_ARTIST=artist
set PRJ_PATH_ARTIST=%SLN_PATH%\%PRJ_NAME_ARTIST%
:: 编译完成后自动部署目录
set PRJ_PATH_COPYTO_ARTIST=E:\workspace_u3d\u3devtools\Assets\Editor\Plugins

:: 示例项目
set PRJ_NAME_SAMPLE=sample
set PRJ_PATH_SAMPLE=%SLN_PATH%\%PRJ_NAME_SAMPLE%
:: 编译完成后自动部署目录
set PRJ_PATH_COPYTO_SAMPLE=

# u3devtools

## artist

库, 导入图片到U3D自动设置导入参数

## sample

库, U3D各种例子

## utils

库, 常用工具API

## xls2lua

应用程序, 按一定规则把xlsx配置表生成对应的lua类型定义, 这是一个项目限定的小工具

```bat
rem 估计是用到了反射功能，不能使用以下参数
rem  -p:PublishTrimmed=true
dotnet publish xls2lua --configuration Release --self-contained --runtime win-x64 -p:PublishReadyToRun=true -p:PublishSingleFile=true
```

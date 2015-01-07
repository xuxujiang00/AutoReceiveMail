@echo off
path %path%;%windir%\Microsoft.NET\Framework\v4.0.30319
@echo on
@echo 请按任意键开始安装云中心消息推送服务程序...
@pause
@echo 正在清理原有服务程序...
InstallUtil River.ReceiveMail.WinService.exe /U > InstallService.log
@echo 清理完毕，正在开始安装服务程序...
InstallUtil River.ReceiveMail.WinService.exe >> InstallService.log
@echo 服务安装完毕，请在 InstallService.log 中查看具体的操作结果。
@echo.
@pause
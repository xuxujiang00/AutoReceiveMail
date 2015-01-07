path %path%;%windir%\Microsoft.NET\Framework\v4.0.30319
@echo 请按任意键开始卸载服务程序...
@echo .
@pause
@echo 正在清理原有服务程序...
InstallUtil River.ReceiveMail.WinService.exe /U > InstallService.log
@echo .
@echo 清理完毕，请在 InstallService.log 中查看具体的操作结果。
@pause
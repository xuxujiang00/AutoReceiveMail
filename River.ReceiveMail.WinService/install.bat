@echo off
path %path%;%windir%\Microsoft.NET\Framework\v4.0.30319
@echo on
@echo �밴�������ʼ��װ��������Ϣ���ͷ������...
@pause
@echo ��������ԭ�з������...
InstallUtil River.ReceiveMail.WinService.exe /U > InstallService.log
@echo ������ϣ����ڿ�ʼ��װ�������...
InstallUtil River.ReceiveMail.WinService.exe >> InstallService.log
@echo ����װ��ϣ����� InstallService.log �в鿴����Ĳ��������
@echo.
@pause
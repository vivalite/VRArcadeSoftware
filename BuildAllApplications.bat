set startTime=%time%
del /q .\BuildTemp\*
for /d %%x in (.\BuildTemp\*) do @rd /s /q "%%x"
call BuildVS
call BuildUnity
@echo off
echo Start Time: %startTime%
echo Finish Time: %time%
pause
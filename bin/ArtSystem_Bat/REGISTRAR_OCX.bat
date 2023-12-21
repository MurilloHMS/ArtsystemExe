@echo off

CD\ARTSYSTEM
COPY *.ocx %TEMP% 
COPY *.bat %TEMP% 
regsvr32 "mschrt20.ocx"
regsvr32 "comctl32.ocx"
regsvr32 "mscomct2.ocx"
regsvr32 "mscomctl.ocx"
regsvr32 "mscomm32.ocx"
regsvr32 "comctl32.ocx"
registraw10DLL_NFe_2G.bat 


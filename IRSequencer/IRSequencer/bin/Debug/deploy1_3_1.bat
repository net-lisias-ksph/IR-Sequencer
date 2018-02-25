call "C:\Program Files\Unity 5.4\Editor\Data\MonoBleedingEdge\bin\cli.bat" "C:\Program Files\Unity 5.4\Editor\Data\MonoBleedingEdge\lib\mono\4.5\pdb2mdb.exe" "D:\Software Entwicklung\Kerbal\GitHub\IR-Sequencer\IRSequencer\IRSequencer\bin\Debug\IRSequencer_v3.dll"

@echo on

copy "D:\Software Entwicklung\Kerbal\GitHub\IR-Sequencer\IRSequencer\IRSequencer\bin\Debug\IRSequencer_v3.dll" "C:\Kerbal Space Program 1.3.1 Dev\GameData\MagicSmokeIndustries\Plugins\IRSequencer_v3.dll"
copy "D:\Software Entwicklung\Kerbal\GitHub\IR-Sequencer\IRSequencer\IRSequencer\bin\Debug\IRSequencer_v3.dll.mdb" "C:\Kerbal Space Program 1.3.1 Dev\GameData\MagicSmokeIndustries\Plugins\IRSequencer_v3.dll.mdb"
copy "D:\Software Entwicklung\Kerbal\GitHub\IR-Sequencer\IRSequencer\IRSequencer\bin\Debug\IRSequencer_v3.pdb" "C:\Kerbal Space Program 1.3.1 Dev\GameData\MagicSmokeIndustries\Plugins\IRSequencer_v3.pdb"

@pause

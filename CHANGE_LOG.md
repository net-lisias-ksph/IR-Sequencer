# IR Sequencer :: Change Log

* 2015-0623: 0.4 (Ziw) for KSP 1.0.4
	+ Requires IR version 0.21.3 and higher
		- Works in KSP 1.0.4
			- Major: You can now create and edit sequences in editor (VAB, SPH). But there are several limitations:
			- It is best to leave it as a last part of your craft building as adding or removing parts may create problems and reset your sequences.
			- You still need the probe core to create/edit/save sequences
			- For obvious reasons testing sequences in editor is not very accurate as all the robotic parts move to the designated positions instantly and Action Groups do not fire as well.
			- Experimental: Added the "Wait for ActionGroup" command, but please remember that it checks only if AG is enabled, not the toggle. So for example if you have "Wait for AG Lights" in your sequence then the sequencer will wait until the lights are on, BUT if they are already on it will not pause, so design your sequences accordingly (good practice would be to add "Wait for commands" after your "Wait for ActionGroup" to ensure that all previous servo commands have finished).
			- Minor: a number of bug fixes and QoL improvements in UI.
* 2015-0602: 0.4-pre (Ziw) for KSP 1.0.2 + new feature. PRE-RELEASE
	+ Requires 0.21.3-pre version of IR or better.
* 2015-0507: 0.3 (Ziw) for KSP 1.0.2 + new feature.
	+ Changelog
		- Some minor launcher button code refactoring
		- Added the ability to insert new commands anywhere in the sequence.
			- [Like so](http://i.imgur.com/H82ucmx.jpg)
* 2015-0428: 0.2 (Ziw) for KSP 0.9
	+ Nothing new, just recompile/fix for 1.0
* 2015-0420: 0.1 (Ziw) for KSP 0.9
	+ Sequencer
	+ Initial Release of the first official add-on to [Infernal Robotics v0.20](http://forum.kerbalspaceprogram.com/threads/116064)
	+ This mod will NOT work without the latest version of Infernal Robotics.
	+ What it does?
	+ This add-on serves as a first example of using IR's new [API](https://github.com/MagicSmokeIndustries/InfernalRobotics/wiki/Using-the-IR-API). With this mod you can create and play sequences made of servo movement commands and special commands, like Goto, Toggle ActionGroup, Delay and Wait.
	+ For some more examples inspiration see the forum post.
	+ This mod would not have been possible without invaluable help from Zodius & erendrake.

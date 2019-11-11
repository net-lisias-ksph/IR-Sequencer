# IR Sequencer :: Change Log

* 2016-0422: 1.0-beta3 (Ziw) for KSP 1.0.4 PRE-RELEASE
	+ Also added option to settings to always start control window in edit mode
* 2016-0421: 1.0-beta2 (Ziw) for KSP 1.0.4 PRE-RELEASE
	+ Requires IR 2.0-RC1 or later
	+ Requires clean install (delete any previous version from GameData/MagicSmokeIndustries/IRSequencer)
	+ New features:
		- State machine functionality (can be optional, just having 1 state will replicate previous version behaviour)
		- New awesome UI
			- To select servo for Move command just Ctrl-Click it on your craft while Edit Sequence window is open
			- You can drag and drop States, Sequences between States (this will change Sequence's starting State) and Commands in Edit Sequence window.
			- Goto command now places an indicator where it points to, but please avoid using more than one GoTO command per sequence for now.
			- Cool looking progress indicators for commands in Edit Sequence window
		- You can have multiple Sequencers per craft and let them control different servos. Each Sequencer has it's own set of States.
	+ Known issues:
		- AGX support is temporarily disabled (will be re-enables on release, given that AGX will be updated).
		- Multiple IR capable crafts in physics range was not tested properly, please report any issues.
* 2016-0303: 1.0-beta1.2 (Ziw) for KSP 1.0.4 PRE-RELEASE
	+ Fix the Revert to Hangar not saving the sequences
	+ Fix the keyboard shortcuts not working for multiple sequences in different states.
* 2016-0302: 1.0-beta1.1 (Ziw) for KSP 1.0.4 PRE-RELEASE
	+ Save-Breaking update - your existing crafts will lose all sequences on them, you will have to rebuild them
	+ This update brings implementation of Finite State Machine to Sequencer.
	+ Sequencer will allow you to create Finite State Machines, with all Sequences having a Start State and End State (could be the same state). If a sequence that changes the current state of the machine finishes successfully, then state is changed to the sequence's End State and if there are any sequences, that are set to auto-trigger on machine entering their Start State - they will be started.
		- You can now have more than 1 sequencer per vessel, so you can have a sequencer for Legs separate from sequencer for Arms for example. It is achieved by moving all sequencer logic to PartModule and is for now attached to probe-cores. This sequencer stores its States and corresponding Sequences and manages their proper execution.
		- For each sequencer module only one state-changing sequence can be executed at any given time, although if you have non-statechanging sequences, any number of them can be ran simultaneously as long your sequencer's current state matches their start state and they don't lock each other's servos
		- Although you can have multiple sequencers, keyboard shortcuts are shared between them, so you can use one shortcut key to start/stop multiple sequences across multiple sequencers, but only sequences with proper Start State will be started, depending on the current state of each of the sequencers on your vessel.
* 2015-1229: 0.6 (Ziw) for KSP 1.0.4
	+ Changes:
		- Some Commands (servo movement, delay, go to line) are now editable. Unfortunately UI restrictions interfere with making ActionGroups commands to be editable as well.
		- Added Action Groups Extended support, _version 1.34d or later is required_. Your custom ActionGroups should appear in the list after the stock ActionGroups and behave identically. This feature is still experimental, so please report any bugs you encounter on the forum thread.
* 2015-1111: 0.5 (Ziw) for KSP 1.0.4
	+ Mostly maintenance release, just one experimental feature added - you can now add keyboard shortcuts to sequences.
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

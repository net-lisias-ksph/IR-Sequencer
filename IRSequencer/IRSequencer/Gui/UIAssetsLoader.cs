using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace IRSequencer_v3.Gui
{
	[KSPAddon(KSPAddon.Startup.MainMenu, false)]
	public class UIAssetsLoader : MonoBehaviour
	{
		private AssetBundle IRAssetBundle;
		private AssetBundle IRSeqAssetBundle;

		internal static GameObject controlWindowPrefab;
		internal static GameObject sequencerLinePrefab;
		internal static GameObject stateLinePrefab;
		internal static GameObject sequenceLinePrefab;

		internal static GameObject uiSettingsWindowPrefab;

		internal static GameObject editorWindowPrefab;
		internal static GameObject sequenceCommandLinePrefab;
		
		internal static GameObject basicTooltipPrefab;

		internal static List<Texture2D> iconAssets;
		internal static List<UnityEngine.Sprite> spriteAssets;
		
		public static bool allPrefabsReady = false;

		public IEnumerator LoadBundle(string location)
		{
			while(!Caching.ready)
				yield return null;

			using (WWW www = WWW.LoadFromCacheOrDownload(location, 1))
			{
				yield return www;
				IRSeqAssetBundle = www.assetBundle;

				LoadBundleAssets();
			}
		}

		private void LoadBundleAssets()
		{
			var prefabs = IRSeqAssetBundle.LoadAllAssets<GameObject>();
			int prefabsLoadedCount = 0;
			for(int i = 0; i < prefabs.Length; i++)
			{
				if(prefabs[i].name == "SequencerMainWindowPrefab")
				{
					controlWindowPrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "SequencerLinePrefab")
				{
					sequencerLinePrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "SequencerStateLinePrefab")
				{
					stateLinePrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "SequenceLinePrefab")
				{
					sequenceLinePrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "SequencerUISettingsWindowPrefab")
				{
					uiSettingsWindowPrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "SequencerEditorWindowPrefab")
				{
					editorWindowPrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "SequenceCommandLine")
				{
					sequenceCommandLinePrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}

				if(prefabs[i].name == "BasicTooltipPrefab")
				{
					basicTooltipPrefab = prefabs[i] as GameObject;
					prefabsLoadedCount++;
				}
			}

			allPrefabsReady = (prefabsLoadedCount > 7);

			spriteAssets = new List<UnityEngine.Sprite>();
			var sprites = IRSeqAssetBundle.LoadAllAssets<UnityEngine.Sprite>();

			for(int i = 0; i < sprites.Length; i++)
			{
				if(sprites[i] != null)
				{
					spriteAssets.Add(sprites[i]);
					Logger.Log("Successfully loaded Sprite " + sprites[i].name, Logger.Level.Debug);
				}
			}

			iconAssets = new List<Texture2D>();
			var icons = IRSeqAssetBundle.LoadAllAssets<Texture2D>();

			for(int i = 0; i < icons.Length; i++)
			{
				if(icons[i] != null)
				{
					iconAssets.Add(icons[i]);
					Logger.Log("Successfully loaded texture " + icons[i].name, Logger.Level.Debug);
				}
			}

/*	das hier wär wieder aus IR statt die eigenen... nun... eben...
			spriteAssets = new List<UnityEngine.Sprite>();
			var sprites = IRAssetBundle.LoadAllAssets<UnityEngine.Sprite>();

			for(int i = 0; i < sprites.Length; i++)
			{
				if(sprites[i] != null)
				{
					spriteAssets.Add(sprites[i]);
				}
			}

			iconAssets = new List<Texture2D>();
			var icons = IRAssetBundle.LoadAllAssets<Texture2D>();

			for(int i = 0; i < icons.Length; i++)
			{
				if(icons[i] != null)
				{
					iconAssets.Add(icons[i]);
				}
			}
			*/
			if(allPrefabsReady)
				Logger.Log("Successfully loaded all prefabs from AssetBundle");
			else
				Logger.Log("Some prefabs failed to load, bundle = " + IRSeqAssetBundle.name);
		}

		public void Start()
		{
			if(allPrefabsReady)
				return; //there is no need to reload the prefabs or any other assets.

bool bLoadGeklaute = false; // die vom IR... wieso lade ich das Zeug nicht aus den eigenen Assets? was soll das? ist das so viel? wegen den paar KB?
		if(bLoadGeklaute)
		{

			//need to clean cache
			Caching.CleanCache();
			
			Type IRAssetsLoaderType = null;

			AssemblyLoader.loadedAssemblies.TypeOperation (t => {
				if(t.FullName == "InfernalRobotics_v3.Gui.UIAssetsLoader") { IRAssetsLoaderType = t; } });

			var fieldInfo = IRAssetsLoaderType.GetField("IRAssetBundle", BindingFlags.NonPublic | BindingFlags.Static);
			IRAssetBundle = (AssetBundle)fieldInfo.GetValue(null);

			if(!allPrefabsReady)
			{
				if(IRAssetBundle != null)
					LoadBundleAssets();
			}
// FEHLER, kommt später, wenn ich meine eigene Sache geladen habe...

			fieldInfo = IRAssetsLoaderType.GetField("iconAssets", BindingFlags.NonPublic | BindingFlags.Static);
			iconAssets = (List<Texture2D>)fieldInfo.GetValue(null);

			fieldInfo = IRAssetsLoaderType.GetField("spriteAssets", BindingFlags.NonPublic | BindingFlags.Static);
			spriteAssets = (List<Sprite>)fieldInfo.GetValue(null);

//meine assets noch laden, nicht nur die geklauten... Himmel Arsch und Zwirn

		}
	

			var assemblyFile = Assembly.GetExecutingAssembly().Location;
			var bundlePath = "file://" + assemblyFile.Replace(new FileInfo(assemblyFile).Name, "").Replace("\\","/") + "../AssetBundles/";

			Logger.Log("Loading bundles from BundlePath: " + bundlePath, Logger.Level.Debug);

			Caching.CleanCache();

			StartCoroutine(LoadBundle(bundlePath + "ir_seq_ui_objects_v3.ksp"));
		}

		public void Update()
		{
			if(!allPrefabsReady)
			{
bool bLoadGeklaute = false; // die vom IR... wieso lade ich das Zeug nicht aus den eigenen Assets? was soll das? ist das so viel? wegen den paar KB?
		if(bLoadGeklaute)
		{
				Type IRAssetsLoaderType = null;

				AssemblyLoader.loadedAssemblies.TypeOperation(t => {
					if(t.FullName == "InfernalRobotics_v3.Gui.UIAssetsLoader") { IRAssetsLoaderType = t; } });

				var fieldInfo = IRAssetsLoaderType.GetField("IRAssetBundle", BindingFlags.NonPublic | BindingFlags.Static);
				IRAssetBundle = (AssetBundle)fieldInfo.GetValue(null);

				if(IRAssetBundle != null)
					LoadBundleAssets();
				
				fieldInfo = IRAssetsLoaderType.GetField("iconAssets", BindingFlags.NonPublic | BindingFlags.Static);
				iconAssets = (List<Texture2D>)fieldInfo.GetValue(null);

				fieldInfo = IRAssetsLoaderType.GetField("spriteAssets", BindingFlags.NonPublic | BindingFlags.Static);
				spriteAssets = (List<Sprite>)fieldInfo.GetValue(null);
		}

// FEHLER, wozu Update?

			}
		}

		public void OnDestroy()
		{
			/*if(IRAssetBundle)
			{
				Logger.Log("Unloading bundle", Logger.Level.Debug);
				IRAssetBundle.Unload(false);
			}*/
		}
	}
}


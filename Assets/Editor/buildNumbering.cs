using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private static void IncrementBuildNumber(int 1)
    {
        // Load the PlayerSettings asset.
        var playerSettings = Resources.FindObjectsOfTypeAll<PlayerSettings>().FirstOrDefault();
 
        if (playerSettings != null)
        {
            SerializedObject so = new SerializedObject(playerSettings);
 
            // Find the build number property.
            var sp = so.FindProperty("AndroidBundleVersionCode");
 
            var currentValue = sp.longValue;
 
            sp.longValue = currentValue + amount;
 
            // Save player settings.
            so.ApplyModifiedProperties();
            AssetDatabase.SaveAssets();
        }
    }

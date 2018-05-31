using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	[Tooltip("Choose which GameSettings asset to use")]
    public PARSSettings _settings; // drag GameSettings asset here in inspector

	public static PARSSettings s;
	public static Settings instance;

    void Awake(){
        if(Settings.instance==null){
            Settings.instance=this;
        } else if(Settings.instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        if(Settings.s==null){
            Settings.s=_settings;
        }
    }
}

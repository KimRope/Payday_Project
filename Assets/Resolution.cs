using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public static Resolution instance = null;
    
    void Awake()
    {
        // SoundManager 인스턴스가 이미 있는지 확인, 이 상태로 설정
        if (instance == null)
        {
            instance = this;
            Screen.SetResolution(540, 960, false);
        }

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (instance != this)
            Destroy(gameObject);

        // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(540, 960, false);
        }
    }
}

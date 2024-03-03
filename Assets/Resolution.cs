using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public static Resolution instance = null;
    
    void Awake()
    {
        // SoundManager �ν��Ͻ��� �̹� �ִ��� Ȯ��, �� ���·� ����
        if (instance == null)
        {
            instance = this;
            Screen.SetResolution(540, 960, false);
        }

        // �ν��Ͻ��� �̹� �ִ� ��� ������Ʈ ����
        else if (instance != this)
            Destroy(gameObject);

        // �̷��� �ϸ� ���� scene���� �Ѿ�� ������Ʈ�� ������� �ʽ��ϴ�.
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

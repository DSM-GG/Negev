using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    //Prefeb 같은 거
    public static int killedenemy;
    //시간
    float time;

    //현재 불러온 스테이지
    StageData current_Stage;

	// Use this for initialization
	void Start () {
        current_Stage = DataManager.Instance.LoadStageData(0);
        Debug.Log(current_Stage.no);

        InitMap();
        StartCoroutine("Routine");
	}

    //맵 불러오고 초기화
    void InitMap()
    {
        killedenemy = 0;
    }

    IEnumerator Routine()
    {
        int i = 0;
        while(true)
        {
            //시간 업데이트
            time += Time.deltaTime;
            //커맨드 처리
            if (time >= current_Stage.commands[i].time)
            {
                switch (current_Stage.commands[i].kind)
                {
                    case CommandKind.Dialog:
                        {
                            Debug.Log("대화당");
                            break;
                        }
                    case CommandKind.Enemy:
                        {
                            Debug.Log("적이당");
                            break;
                        }
                }
                i++;
            }
            //종료 조건 검사
            if(current_Stage.kind == StageKind.Destroy)
            {
                if(time >= current_Stage.stagetime)
                {
                    //게임오버 (시간초과)
                }
                if(current_Stage.targetamount == killedenemy)
                {
                    //게임 클리어
                }
            }
        }
    }
}

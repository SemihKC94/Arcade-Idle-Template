using System.Collections.Generic;
[System.Serializable]
public class Territory
{
    public List<ZoneInfo> Zone;

    public Territory()
    {
        Zone = new List<ZoneInfo>();

        for (int i = 0; i < 4; i++)
        {
            Zone.Add(new ZoneInfo());
            Zone[i].ZoneOwnStatus = 0;
            if(i == 0) Zone[i].ZoneOwnStatus = 1;
            Zone[i].Plane = new List<int>();
            Zone[i].PlaneInfoInc = new List<PlaneInfo>();
            for (int j = 0; j < 9; j++)
            {
                if(i == 0) Zone[i].Plane.Add(1);
                else Zone[i].Plane.Add(0);
                Zone[i].PlaneInfoInc.Add(new PlaneInfo());
                Zone[i].PlaneInfoInc[j].topBarCollect = 0;
                Zone[i].PlaneInfoInc[j].leftBarCollect = 0;
                Zone[i].PlaneInfoInc[j].rightBarCollect = 0;
            }
        }
    }
}

[System.Serializable]
public class ZoneInfo
{
    public int ZoneOwnStatus;
    public List<int> Plane;
    public List<PlaneInfo> PlaneInfoInc;
}

[System.Serializable]
public class PlaneInfo
{
    public int topBarCollect = 0;
    public int leftBarCollect = 0;
    public int rightBarCollect = 0;
}

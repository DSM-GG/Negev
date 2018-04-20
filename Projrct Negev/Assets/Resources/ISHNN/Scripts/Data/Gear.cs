using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class Gear {
    public readonly int number;
    public readonly string name;
    public Gear(int gear_no, string gear_name)
    {
        this.number = gear_no;
        this.name = gear_name;
        //가능하면 겹치는 기어가 없는지 확인
    }
}

[Serializable]
public class Barrier : Gear
{
    public enum Type { Energy, Solid };
    public readonly Type type;
    public readonly float DEF;
    private readonly float capacity;

    public Barrier(int gear_no, string gear_name, float Def, float capacity, Type type) : base(gear_no, gear_name)
    {
        this.DEF = Def;
        this.capacity = capacity;
        this.type = type;
    }
}

[Serializable]
public class Weapon : Gear
{
    public readonly float ATK;
    public readonly float speed;
    public Weapon(int gear_no, string gear_name) : base(gear_no, gear_name)
    {

    }
}

[Serializable]
public class AutoWeapon : Weapon
{
    enum Type { Guided, Unguided };
    public AutoWeapon(int gear_no, string gear_name) : base(gear_no, gear_name)
    {

    }
}

[Serializable]
public class ManualWeapon : Weapon
{
    enum Type { FireArm, Boom, LockOn };
    public readonly float clip;
    public ManualWeapon(int gear_no, string gear_name) : base(gear_no, gear_name)
    {

    }
}
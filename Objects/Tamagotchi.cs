using System;
using System.Collections.Generic;

namespace TamagotchiApp.Objects
{
  public class Tamagotchi
  {
    private int    _id;
    private string _name;
    private int    _food; //0-10. Where 0 is empty and 10 is full.
    private int    _sleep; //0-10. Where 0 is empty and 10 is full.
    private int    _attention; //0-10. Where 0 is empty and 10 is full.
    private bool   _dead;
    private bool   _verbed;
    private static List<Tamagotchi> _instances = new List<Tamagotchi>{};

    public Tamagotchi(string name)
    {
      Random rnd = new Random();

      _id        = _instances.Count;
      _name      = name;
      _food      = rnd.Next(1,10);
      _sleep     = rnd.Next(1,10);
      _attention = rnd.Next(1,10);
      _dead      = false;
      _verbed    = false;

      _instances.Add(this);
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetFood()
    {
      return _food;
    }
    public void SetFood(int newFood)
    {
      if (newFood > 10) {
        _food = 10;
      } else {
        _food = newFood;
      }
      this.SetVerbed(true);
    }
    public int GetSleep()
    {
      return _sleep;
    }
    public void SetSleep(int newSleep)
    {
      if (newSleep > 10) {
      _sleep = 10;
      } else {
      _sleep = newSleep;
      }
      this.SetVerbed(true);
    }
    public int GetAttention()
    {
      return _attention;
    }
    public void SetAttention(int newAttention)
    {
      if (newAttention > 10) {
      _attention = 10;
      } else {
      _attention = newAttention;
      }
      this.SetVerbed(true);
    }
    public bool GetVerbed()
    {
      return _verbed;
    }
    public void SetVerbed(bool newVerbed)
    {
      _verbed = newVerbed;
    }

    public bool isDead()
    {
      if(this._food == 0 || this._sleep == 0 || this._attention == 0)
      {
        this._dead = true;
      }
      return _dead;
    }

    public static List<Tamagotchi> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Tamagotchi Find(int searchId)
    {
      return _instances[searchId];
    }
    public static void PassTime()
    {
      foreach(Tamagotchi creature in _instances)
      {
        creature._food--;
        creature._sleep--;
        creature._attention--;
      }
    }
  }
}

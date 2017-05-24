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
      _food = newFood;
    }
    public int GetSleep()
    {
      return _sleep;
    }
    public void SetSleep(int newSleep)
    {
      _sleep = newSleep;
    }
    public int GetAttention()
    {
      return _attention;
    }
    public void SetAttention(int newAttention)
    {
      _attention = newAttention;
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

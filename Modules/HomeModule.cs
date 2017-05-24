using System;
using Nancy;
using TamagotchiApp.Objects;
using System.Collections.Generic;

namespace TamagotchiApp
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml", Tamagotchi.GetAll()];
      };
      Post["/tamagotchi/new"] = _ => {
        Tamagotchi newTama = new Tamagotchi(Request.Form["tama-name"]);
        return View["index.cshtml", Tamagotchi.GetAll()];
      };
      Post["/tamagotchi/pass-time"] = _ => {
        Tamagotchi.PassTime();
        foreach(Tamagotchi creature in Tamagotchi.GetAll())
        {
          creature.isDead();
          creature.SetVerbed(false);
        }
        return View["index.cshtml", Tamagotchi.GetAll()];
      };
      Post["/tamagotchi/{id}/increment/{property}"] = parameters => {
        Tamagotchi targetCreature = Tamagotchi.Find(parameters.id);
        if (parameters.property == "food") {
          targetCreature.SetFood(targetCreature.GetFood() + 3);
        }
        if (parameters.property == "sleep") {
          targetCreature.SetSleep(targetCreature.GetSleep() + 3);
        }
        if (parameters.property == "attention") {
          targetCreature.SetAttention(targetCreature.GetAttention() + 3);
        }
        return View["index.cshtml", Tamagotchi.GetAll()];
      };
    }
  }
}

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
      Post["tamagotchi/pass-time"] = _ => {
        Tamagotchi.PassTime();
        foreach(Tamagotchi creature in Tamagotchi.GetAll())
        {
          creature.isDead();
        }
        return View["index.cshtml", Tamagotchi.GetAll()];
      };
    }
  }
}

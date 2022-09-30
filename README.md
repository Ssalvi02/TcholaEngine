# TcholaEngine

## Como rodar programas C#

---

1. Baixar o [Mono](https://www.mono-project.com/download/stable/)
2. Rodar o comando `csc .\pong.cs ./Modules/Collision/collision.cs ./Modules/Control/control.cs ./Modules/Geometry/geometry.cs` para compilar
3. Rodar o comando `mono.\pong.exe` para executar o programa

---

`public class WhoAmI()
{
     public string GetName()
     {
          return "TcholaEngine";
     }
    public string GetPronouns()
    {
          return "C/#";
    }
    public string GetCurrentCity()
    {
          return "Campo Mourão - PR";
    }
    public string[] GetHobbies()
    {
          return "Watching anime, playing games";
    }
}`

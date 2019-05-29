using System;

namespace PencilKata
{
  public class Pencil
  {

    private Int32 durability;

    public Int32 Durability
    {
      get
      {
        return durability;
      }
    }

    public Pencil(Int32 durability)
    {
      this.durability = durability;
    }

    public String Write(String paper, String text)
    {
      String textWithOutWhiteSpace = text.Replace(" ", "").Replace("/n", "");

      foreach (char c in textWithOutWhiteSpace)
      {
        if (char.IsUpper(c))
        {
          durability -= 2;
        }
        else
        {
          durability -= 1;
        }
      }

      return paper += text;
    }
  }
}

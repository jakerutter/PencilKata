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

      foreach (char character in text)
      {
        int cost = PencilUtilities.getCharacterCost(character);

        if (cost <= durability)
        {
          paper += character;
          durability -= cost;
        }
        else
        {
          paper += " ";
        }
      }

      return paper;
    }
  }
}

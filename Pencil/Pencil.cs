using System;

namespace PencilKata
{
  public class Pencil
  {

    private Int32 durability;
    private Int32 intitalDurability;

    public Int32 Durability
    {
      get
      {
        return durability;
      }
    }

    public Int32 InitialDurability
    {
      get
      {
        return intitalDurability;
      }
    }

    public Pencil(Int32 durability, Int32 length)
    {
      this.durability = durability;
      this.intitalDurability = durability;
    }

    public String Write(String paper, String text)
    {

      foreach (Char character in text)
      {
        Int32 cost = PencilUtilities.getCharacterCost(character);

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

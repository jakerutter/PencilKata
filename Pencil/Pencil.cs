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

    public string Write(String paper, String text)
    {
      Int32 textlength = text.Replace(" ", "").Replace("/n", "").Length;

      durability -= textlength;
      return paper += text;
    }
  }
}

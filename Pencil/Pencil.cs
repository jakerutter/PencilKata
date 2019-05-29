using System;

namespace PencilKata
{
  public class Pencil
  {

    private Int32 durability;
    private Int32 intitalDurability;
    private Int32 length;
    private Int32 eraserDurability;

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

    public Int32 Length
    {
      get
      {
        return length;
      }
    }

    public Int32 EraserDurability
    {
      get
      {
        return eraserDurability;
      }
    }

    public Pencil(Int32 durability, Int32 length, Int32 eraserDurability)
    {
      this.durability = durability;
      this.intitalDurability = durability;
      this.length = length;
      this.eraserDurability = eraserDurability;
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

    public Int32 Sharpen(Int32 length)
    {
      if (length > 0)
      {
        length -= 1;
        durability = InitialDurability;
      }

      return length;
    }

    public String Erase(String paper, String wordToErase)
    {
      Int32 place = paper.LastIndexOf(wordToErase);

      if (place == -1)
      {
        return paper;
      }

      Boolean canEraseEntireWord = PencilUtilities.CanEraseEntirePhrase(EraserDurability, wordToErase);

      if (canEraseEntireWord)
      {
        String replacementString = new String(' ', wordToErase.Length);
        paper = paper.Remove(place, wordToErase.Length).Insert(place, replacementString);
      }

      eraserDurability = PencilUtilities.CalculateEraserDurability(eraserDurability, wordToErase);

      return paper;
    }
  }
}

using System;

namespace PencilKata
{
  public class Pencil
  {

    private Int32 durability;
    private Int32 intitalDurability;
    private Int32 length;
    private Int32 eraserDurability;
    private Int32 editIndex = -1;

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

    public Int32 EditIndex
    {
      get
      {
        return editIndex;
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
        Int32 cost = PencilUtilities.GetCharacterCost(character);

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

        editIndex = place;
        eraserDurability = PencilUtilities.CalculateEraserDurability(EraserDurability, wordToErase);

        return paper;
      }
      else
      {
        String newWord = paper.Substring(paper.LastIndexOf(wordToErase), wordToErase.Length);

        for (Int32 i = newWord.Length; i-- > 0;)
        {
          if (EraserDurability > 0)
          {
            if (!Char.IsWhiteSpace(newWord[i]))
            {
              eraserDurability -= 1;
              newWord = newWord.Remove(i, 1).Insert(i, " ");

              if (EraserDurability == 0)
              {
                editIndex = (paper.LastIndexOf(wordToErase) + i);
                break;
              }
            }
          }
        }  
        paper = paper.Remove(place, wordToErase.Length).Insert(place, newWord);
        return paper;
      }
    }

    public String Edit(String paper, String wordToEnter, Int32 EditIndex)
    {
      Int32 place = EditIndex;

      if (place == -1)
      {
        return paper;
      }

      foreach (Char c in wordToEnter)
      {
        Int32 cost = PencilUtilities.GetCharacterCost(c);

        if (Durability >= cost)
        {
          if (!Char.IsWhiteSpace(paper[place]))
          {
            paper = paper.Remove(place, 1).Insert(place, "@");
          }
          else
          {
            paper = paper.Remove(place, 1).Insert(place, c.ToString());
          }
          durability -= cost;
        }
        else
        {
          paper = paper.Remove(place, 1).Insert(place, " ");
        }
        
        place += 1;
      }
      return paper;
    }
  }
}

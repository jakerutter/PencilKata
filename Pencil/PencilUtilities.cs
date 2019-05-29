using System;

namespace PencilKata
{
  public class PencilUtilities
  {
    public static Int32 getCharacterCost(char character)
    {
      Int32 cost;

      if (char.IsWhiteSpace(character))
      {
        cost = 0;
      }
      else if (char.IsLower(character))
      {
        cost = 1;
      }
      else if (char.IsUpper(character))
      {
        cost = 2;
      }
      else
      {
        cost = 0;
      }

      return cost;
    }

    public static Boolean CanEraseEntirePhrase(Int32 eraserDurability, String phraseToErase)
    {
      String trimmedPhrase = phraseToErase.Replace(" ", "");

      return (eraserDurability >= trimmedPhrase.Length) ? true : false;
    }
  }
}

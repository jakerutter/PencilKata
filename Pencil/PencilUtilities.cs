using System;

namespace PencilKata
{
  public class PencilUtilities
  {
    public static Int32 getCharacterCost(Char character)
    {
      Int32 cost;

      if (Char.IsWhiteSpace(character))
      {
        cost = 0;
      }
      else if (Char.IsLower(character))
      {
        cost = 1;
      }
      else if (Char.IsUpper(character))
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

    public static Int32 CalculateEraserDurability(Int32 eraserDurability, String phraseToErase)
    {
      String trimmedPhrase = phraseToErase.Replace(" ", "");

      if (eraserDurability > trimmedPhrase.Length)
      {
        return eraserDurability -= trimmedPhrase.Length;
      }
      else
      {
        return 0;
      }
    }
  }
}

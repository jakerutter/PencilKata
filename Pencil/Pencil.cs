using System;

namespace PencilKata
{
  public class Pencil
  {

    public Pencil() { }

    public string Write(String paper, String text)
    {
      return paper += text;
    }
  }
}

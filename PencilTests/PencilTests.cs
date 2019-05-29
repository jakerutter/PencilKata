using System;
using PencilKata;
using Xunit;

namespace PencilKataTests
{
    public class PencilTests
    {

    Pencil pencil = new Pencil(20);

    [Fact]
    public void whenGivenAnEmptyPaperAndTextToWriteThePencilWritesTheText()
    {
      Assert.Equal("Mary had a little lamb", pencil.Write("", "Mary had a little lamb"));
    }

    [Fact]
    public void whenGivenAPaperWithExistingTextThePencilAppendsTheText()
    {
      Assert.Equal("Mary had a little lamb, little lamb", pencil.Write("Mary had a little lamb", ", little lamb"));
    }

    [Fact]
    public void pencilExperiencesPointDegradationWhenItWrites()
    {
      pencil.Write("", "little lamb");
      Assert.Equal(10, pencil.Durability);
    }

    [Fact]
    public void pencilSuffersTwoPointsOfDegredationWhenItWritesUpperCaseLetters()
    {
      pencil.Write("", "Mary had");
      Assert.Equal(12, pencil.Durability);
    }

    [Fact]
    public void whenPencilPointIsCompletelyExhaustedItWritesWhiteSpaces()
    {
      Assert.Equal("Mary had a little lamb l          ", pencil.Write("", "Mary had a little lamb little lamb"));
    }
  }
}

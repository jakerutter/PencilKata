using System;
using PencilKata;
using Xunit;

namespace PencilKataTests
{
    public class PencilTests
    {

    Pencil pencil = new Pencil(20, 5, 20);

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

    [Fact]
    public void whenPencilIsCreatedInitialDurabilityIsSet()
    {
      Assert.Equal(20, pencil.InitialDurability);
    }

    [Fact]
    public void whenPencilIsSharpenedItsLengthIsReducedByOne()
    {
      Assert.Equal(4, pencil.Sharpen(pencil.Length));
    }

    [Fact]
    public void whenPencilLengthIsZeroThePencilDurabilityIsNotChangedIfSharpened()
    {
      pencil = new Pencil(10, 0, 10);
      pencil.Write("", "little ");
      pencil.Sharpen(pencil.Length);
      Assert.Equal(4, pencil.Durability);
    }

    [Fact]
    public void whenPencilWithLengthGreaterThanZeroIsSharpenedDurabilityIsRestored()
    {
      pencil = new Pencil(20, 5, 10);
      pencil.Write("", "Mary had");
      pencil.Sharpen(pencil.Length);
      Assert.Equal(20, pencil.Durability);
    }

    [Fact]
    public void whenPencilLengthIsZeroThePencilLengthRemainsZeroIfSharpened()
    {
      pencil = new Pencil(10, 0, 10);
      Assert.Equal(0, pencil.Sharpen(pencil.Length));
    }

    [Fact]
    public void whenAPencilErasesItRemovesTheLastInstanceOfAWordFromThePaper()
    {
      String paper = "Mary had a little lamb little lamb";
      Assert.Equal("Mary had a little lamb        lamb", pencil.Erase(paper, "little"));
    }

    [Fact]
    public void whenAPencilIsInstructedToEraseAWordThatDoesNotExistItReturnsTheUnchangedPaper()
    {
      String paper = "Mary had a little lamb little lamb";
      Assert.Equal("Mary had a little lamb little lamb", pencil.Erase(paper, "wolf"));
    }

    [Fact]
    public void whenAPencilErasesMoreThanOnceItErasesTheLastOccurrenceFirstEachTime()
    {
      String paper = "Mary had a little lamb little lamb little lamb";
      Assert.Equal("Mary had a little lamb little lamb        lamb", pencil.Erase(paper, "little"));

      paper = pencil.Erase(paper, "little");
      Assert.Equal("Mary had a little lamb        lamb        lamb", pencil.Erase(paper, "little"));
    }

    [Fact]
    public void canEraseEntirePhraseReturnsTrueIfPencilCanEraseEntirePhrase()
    {
      Boolean doesEraseEntire = PencilUtilities.CanEraseEntirePhrase(pencil.EraserDurability, "little lamb");
      Assert.True(doesEraseEntire);
    }

    [Fact]
    public void canEraseEntirePhraseReturnsFalseIfPencilCannotEraseEntirePhrase()
    {
      Boolean doesEraseEntire = PencilUtilities.CanEraseEntirePhrase(pencil.EraserDurability, "Mary had a little lamb little lamb");
      Assert.False(doesEraseEntire);
    }

    [Fact]
    public void calculateEraserDurabilityProvidesExpectOutput()
    {
      Assert.Equal(6, PencilUtilities.CalculateEraserDurability(10, "lamb"));
      Assert.Equal(0, PencilUtilities.CalculateEraserDurability(10, "Mary had a little lamb"));
    }

    [Fact]
    public void whenAPencilErasesTheEraserDurabilityIsLessenedPerCharacterErased()
    {
      pencil.Erase("Mary had a little lamb", "lamb");
      Assert.Equal(16, pencil.EraserDurability);

      pencil.Erase("Mary had a little lamb little lamb", "had");
      Assert.Equal(13, pencil.EraserDurability);
    }
  }
}

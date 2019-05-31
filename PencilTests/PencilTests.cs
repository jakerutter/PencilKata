using System;
using PencilKata;
using Xunit;

namespace PencilKataTests
{
  public class PencilTests
  {

    Pencil pencil = new Pencil(20, 5, 20);

    [Fact]
    public void WhenGivenAnEmptyPaperAndTextToWriteThePencilWritesTheText()
    {
      Assert.Equal("Mary had a little lamb", pencil.Write("", "Mary had a little lamb"));
    }

    [Fact]
    public void WhenGivenAPaperWithExistingTextThePencilAppendsTheText()
    {
      Assert.Equal("Mary had a little lamb, little lamb", pencil.Write("Mary had a little lamb", ", little lamb"));
    }

    [Fact]
    public void PencilExperiencesPointDegradationWhenItWrites()
    {
      pencil.Write("", "little lamb");
      Assert.Equal(10, pencil.Durability);
    }

    [Fact]
    public void PencilSuffersTwoPointsOfDegredationWhenItWritesUpperCaseLetters()
    {
      pencil.Write("", "Mary had");
      Assert.Equal(12, pencil.Durability);
    }

    [Fact]
    public void WhenPencilPointIsCompletelyExhaustedItWritesWhiteSpaces()
    {
      Assert.Equal("Mary had a little lamb l          ", pencil.Write("", "Mary had a little lamb little lamb"));
    }

    [Fact]
    public void WhenPencilIsCreatedInitialDurabilityIsSet()
    {
      Assert.Equal(20, pencil.InitialDurability);
    }

    [Fact]
    public void WhenPencilIsSharpenedItsLengthIsReducedByOne()
    {
      Assert.Equal(4, pencil.Sharpen(pencil.Length));
    }

    [Fact]
    public void WhenPencilLengthIsZeroThePencilDurabilityIsNotChangedIfSharpened()
    {
      pencil = new Pencil(10, 0, 10);
      pencil.Write("", "little ");
      pencil.Sharpen(pencil.Length);
      Assert.Equal(4, pencil.Durability);
    }

    [Fact]
    public void WhenPencilWithLengthGreaterThanZeroIsSharpenedDurabilityIsRestored()
    {
      pencil = new Pencil(20, 5, 10);
      pencil.Write("", "Mary had");
      pencil.Sharpen(pencil.Length);
      Assert.Equal(20, pencil.Durability);
    }

    [Fact]
    public void WhenPencilLengthIsZeroThePencilLengthRemainsZeroIfSharpened()
    {
      pencil = new Pencil(10, 0, 10);
      Assert.Equal(0, pencil.Sharpen(pencil.Length));
    }

    [Fact]
    public void WhenAPencilErasesItRemovesTheLastInstanceOfAWordFromThePaper()
    {
      String paper = "Mary had a little lamb little lamb";
      Assert.Equal("Mary had a little lamb        lamb", pencil.Erase(paper, "little"));
    }

    [Fact]
    public void WhenAPencilIsInstructedToEraseAWordThatDoesNotExistItReturnsTheUnchangedPaper()
    {
      String paper = "Mary had a little lamb little lamb";
      Assert.Equal("Mary had a little lamb little lamb", pencil.Erase(paper, "wolf"));
    }

    [Fact]
    public void WhenAPencilErasesMoreThanOnceItErasesTheLastOccurrenceFirstEachTime()
    {
      String paper = "Mary had a little lamb little lamb little lamb";
      Assert.Equal("Mary had a little lamb little lamb        lamb", pencil.Erase(paper, "little"));

      paper = pencil.Erase(paper, "little");
      Assert.Equal("Mary had a little lamb        lamb        lamb", pencil.Erase(paper, "little"));
    }

    [Fact]
    public void CanEraseEntirePhraseReturnsTrueIfPencilCanEraseEntirePhrase()
    {
      Boolean doesEraseEntire = PencilUtilities.CanEraseEntirePhrase(pencil.EraserDurability, "little lamb");
      Assert.True(doesEraseEntire);
    }

    [Fact]
    public void CanEraseEntirePhraseReturnsFalseIfPencilCannotEraseEntirePhrase()
    {
      Boolean doesEraseEntire = PencilUtilities.CanEraseEntirePhrase(pencil.EraserDurability, "Mary had a little lamb little lamb");
      Assert.False(doesEraseEntire);
    }

    [Fact]
    public void CalculateEraserDurabilityProvidesExpectOutput()
    {
      Assert.Equal(6, PencilUtilities.CalculateEraserDurability(10, "lamb"));
      Assert.Equal(0, PencilUtilities.CalculateEraserDurability(10, "Mary had a little lamb"));
    }

    [Fact]
    public void WhenAPencilErasesTheEraserDurabilityIsLessenedPerCharacterErased()
    {
      pencil.Erase("Mary had a little lamb", "lamb");
      Assert.Equal(16, pencil.EraserDurability);

      pencil.Erase("Mary had a little lamb little lamb", "had");
      Assert.Equal(13, pencil.EraserDurability);
    }

    [Fact]
    public void WhenAPencilHasInsufficientEraserDurabilityItErasesAsManyCharactersAsItHasDurability()
    {
      Pencil pencil = new Pencil(10, 5, 5);
      String paper = "Mary had a little lamb";
      Assert.Equal("Mary had a l      lamb", pencil.Erase(paper, "little"));
    }

    [Fact]
    public void EraserDoesNotLoseDurabilityForWhitespaceBetweenWords()
    {
      String paper = "Mary had a";
      pencil.Erase(paper, "had a");
      Assert.Equal(16, pencil.EraserDurability);
    }

    [Fact]
    public void AfterErasingEntireWordTheEditIndexPropertyIsSet()
    {
      Pencil pencil = new Pencil(5, 5, 5);
      String paper = pencil.Erase("Mary had a little lamb", "lamb");
      Assert.Equal(18, pencil.EditIndex);
    }

    [Fact]
    public void AfterErasingWholePhraseWithWhitespacesTheEditIndexPropertyIsSet()
    {
      Pencil pencil = new Pencil(20, 20, 10);
      String paper = pencil.Erase("Mary had a little lamb", "had a little");
      Assert.Equal(5, pencil.EditIndex);
    }

    [Fact]
    public void AfterErasingPartialWordTheEditIndexPropertyIsSet()
    {
      Pencil pencil = new Pencil(10, 10, 9);
      String paper = pencil.Erase("Mary had a little lamb", "had a little");
      Assert.Equal(6, pencil.EditIndex);
    }

    [Fact]
    public void AfterErasingPartialWordWordTheEditIndexPropertyIsSetTwo()
    {
      Pencil pencil = new Pencil(10, 10, 3);
      String paper = pencil.Erase("Mary had a little lamb", "Mary");
      Assert.Equal(1, pencil.EditIndex);
    }

    [Fact]
    public void EditCanReplaceErasedWordWithANewWord()
    {
      String paper = pencil.Erase("Mary had a little lamb", "lamb");
      Assert.Equal("Mary had a little bird", pencil.Edit(paper, "bird", pencil.EditIndex));
    }

    [Fact]
    public void EditOverwritesWhitespaceWhenTheEditWordIsLongerThanTheErasedWord()
    {
      String paper = pencil.Erase("Mary had a little lamb", "had");
      Assert.Equal("Mary rodea little lamb", pencil.Edit(paper, "rode", pencil.EditIndex));
    }

    [Fact]
    public void EditPlacesAtSymbolsWhereThereAreCharacterConflicts()
    {
      String paper = pencil.Erase("Mary had a little lamb", "had");
      Assert.Equal("Mary boug@tlittle lamb", pencil.Edit(paper, "bought", pencil.EditIndex));
    }

    [Fact]
    public void PaperLengthIsSameBeforeAndAfterEditOccurs()
    {
      String paper = pencil.Erase("Mary had a little lamb", "little");
      Assert.Equal(paper.Length, pencil.Edit(paper, "bobtail", pencil.EditIndex).Length);
    }

    [Fact]
    public void WhenEditingIfPointDurabilityIsExhaustedPencilWritesWhitespaces()
    {
      Pencil pencil = new Pencil(3, 10, 10);
      String paper = pencil.Erase("Mary had a little lamb", "had a");
      Assert.Equal("Mary kic   little lamb", pencil.Edit(paper, "kicked", pencil.EditIndex));
    }

    [Fact]
    public void WhenEditingPencilDurabilityIsImpactedByCharacterCase()
    {
      Pencil pencil = new Pencil(4, 10, 10);
      String paper = pencil.Erase("Mary had a little lamb", "Mary had");
      Assert.Equal("Joh      a little lamb", pencil.Edit(paper, "John", pencil.EditIndex));
    }
  }
}

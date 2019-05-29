using PencilKata;
using Xunit;

namespace PencilKataTests
{
    public class PencilTests
    {

    Pencil pencil = new Pencil();

    [Fact]
    public void whenGivenTextToWriteThePencilWritesTheText()
    {
      Assert.Equal("Mary had a little lamb", pencil.Write("Mary had a little lamb"));
    }
  }
}
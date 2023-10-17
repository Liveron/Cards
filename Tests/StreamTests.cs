using MAUI.CardsClient.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.FakeFileSystem;

namespace Tests
{
    public class StreamTests
    {
        public static IEnumerable<object[]> GetStreams()
        {
            yield return new object[]
            {
                new FileStream(FakeFileSystemHelper.GetScrubEmptyFilePath(), FileMode.OpenOrCreate, FileAccess.ReadWrite),
            };
        }

        [Theory]
        [MemberData(nameof(GetStreams))]
        public void Normalize_Stream_PositionEqualsZero(Stream stream)
        {
            stream.Normalize();

            Assert.Equal(0, stream.Position);
        }
    }
}

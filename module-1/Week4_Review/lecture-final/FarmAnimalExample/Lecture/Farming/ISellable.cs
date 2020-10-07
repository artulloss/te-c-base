using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    public interface ISellable
    {
        decimal Price { get; }

        string Type { get; }
    }
}

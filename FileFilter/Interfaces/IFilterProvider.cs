using System;
using System.Collections.Generic;
using System.Text;

namespace FileFilter.Interfaces
{
    public interface IFilterProvider
    {
        string[] FilterData(string[] linest);
    }
}

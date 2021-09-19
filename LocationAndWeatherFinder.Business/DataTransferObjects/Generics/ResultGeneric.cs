using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAndWeatherFinder.Business.DataTransferObjects.Generics
{
    public class ResultGeneric<T> 
    {
        public T Data { get; set; }
    }
}

using System;
namespace TestWork.lib
{
    public class CustomException:Exception
    {
         public CustomException()
        {

        }

        public CustomException(string name): base(String.Format("{0}", name))
        {

        }
    }
}
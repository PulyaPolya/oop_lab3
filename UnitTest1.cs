using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ApplicationGuard app = new ApplicationGuard();
            var thread1 = new Thread(First);
            thread1.Start();
            bool temp2=false;
            bool temp1=false;
            void First()
            {

                temp1 = app.TryStart();             
            }
            var thread2 = new Thread(Second);
            thread2.Start();
            void Second()
            {
              
                temp2 = app.TryStart();
                app.Release();
            }
            var expected = true;
            var actual = temp1 && !temp2;
            
            Assert.AreEqual(expected, actual);
        }
    }
}

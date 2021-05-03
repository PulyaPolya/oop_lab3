using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class ApplicationGuard
{
    private static Mutex _mutex= new Mutex(false, "oop");
  
  public bool TryStart()
    {
          return _mutex.WaitOne(10);
    }
   public void Release()
    {
        _mutex.ReleaseMutex();
        _mutex.Dispose();
     

    }
    private static void FirstThreadEntryPoint()
    {
        Thread.Sleep(100);
     
    }
}

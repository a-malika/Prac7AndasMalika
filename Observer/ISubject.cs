using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer, Share share);
        void UnegisterObserver(IObserver observer, Share share);
        Task NotifyObserverAsync(Share share);
    }
}

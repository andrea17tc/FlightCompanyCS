using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanieZborGUI.utils;

public interface IObservable
{
    void addObserver(IObserver obs);
    void removeObserver(IObserver obs);
    void notifyObservers();


}

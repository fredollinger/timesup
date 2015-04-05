// Special thanks to Arvydas:
//
// http://www.arvydas.co.uk/2012/08/notification-icon-in-ubuntu-with-unity-and-mono-c-sharp-example/

using AppIndicator;
using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

public partial class TimesIndicator {
private String _ExecutableFolder = "";
private String ExecutableFolder {
    get {
        if (_ExecutableFolder == "")
            _ExecutableFolder = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        return _ExecutableFolder;
    }

} // END ExecutableFolder 

} // END TimesIndicator

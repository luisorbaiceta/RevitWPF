#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

#endregion

namespace RevitWPF
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;

            // Create and show the WPF window
            MainWindow window = new MainWindow(uiapp);
            window.ShowDialog();

            return Result.Succeeded;
        }
    }
}

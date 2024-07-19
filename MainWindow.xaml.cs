using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows;

namespace RevitWPF
{
    public partial class MainWindow : Window
    {
        private UIApplication _uiApp;

        public MainWindow(UIApplication uiApp)
        {
            InitializeComponent();
            _uiApp = uiApp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tx = new TextDrawer();
            tx.Execute(_uiApp);

            this.Close();
        }
    }

    public class TextDrawer : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            if (null == uidoc)
            {
                return; // no document, nothing to do
            }
            Document doc = uidoc.Document;
            using (Transaction tx = new Transaction(doc, "Create Text Note"))
            {
                XYZ origin = new XYZ(10, 10, 0);
                ElementId defaultTypeId = uidoc.Document.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);

                tx.Start();
                TextNote note = TextNote.Create(uidoc.Document, uidoc.Document.ActiveView.Id, origin, "Revit 2025 Sample Addin with WPF", defaultTypeId);
                tx.Commit();
            }
        }

        public string GetName()
        {
            return "Text Creation";
        }
    }
}

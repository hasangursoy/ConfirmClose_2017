using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace ConfirmClose
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideAutoLoad(UIContextGuids80.NoSolution)]
    public sealed class ConfirmClosePackage : Package
    {
        public const string PackageGuidString = "460ec947-d1d8-4b37-8ee8-259f4be14752";

        protected override int QueryClose(out bool canClose)
        {
            canClose = MessageBox.Show("Do you want to close Visual Studio?", "Confirm Close Extension",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK;

            return VSConstants.S_OK;
        }
    }
}
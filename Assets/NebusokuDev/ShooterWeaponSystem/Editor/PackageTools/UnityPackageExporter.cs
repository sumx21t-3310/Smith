using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Editor.PackageTools
{
    /// <summary>
    /// It is used to create the Vision package. It is not used by the user.
    /// </summary>
    public static class UnityPackageExporter
    {
        // The name of the unitypackage to output.
        const string PackageName = "Vision";

        // The path to the package under the `Assets/` folder.
        const string PackagePath = "MackySoft";

        // Path to export to.
        const string ExportPath = "Build";

        const string SearchPattern = "*";
        const string PackageToolsFolderName = "PackageTools";

        public static void Export() => ExportPackage($"{ExportPath}/{PackageName}.unitypackage");


        public static string ExportPackage(string exportPath)
        {
            // Ensure export path.
            var dir = new FileInfo(exportPath).Directory;

            if (dir is { Exists: false }) dir.Create();

            // Export
            AssetDatabase.ExportPackage(GetAssetPaths(), exportPath, ExportPackageOptions.Default);

            return Path.GetFullPath(exportPath);
        }


        public static string[] GetAssetPaths()
        {
            var path = Path.Combine(Application.dataPath, PackagePath);

            var assets = Directory.EnumerateFiles(path, SearchPattern, SearchOption.AllDirectories)
                                  .Where(x => x.Contains(PackageToolsFolderName) == false)
                                  .Select(x => "Assets" + x.Replace(Application.dataPath, "").Replace(@"\", "/"))
                                  .ToArray();

            return assets;
        }
    }
}
using UnityEditor;
using UnityEngine;
using System.IO;

/// <summary>
/// Folder creator wizard.
/// </summary>
public class SKC_FolderCreatorWizard : ScriptableWizard
{
    // Flags for folder creation.
    // Animations
    public bool CreateAnimationsFolder;
    // Data
    public bool CreateDataFolder;
    // Models
    public bool CreateModelsFolder;
    // Materials
    public bool CreateMaterialsFolder;
    // Plugins
    public bool CreatePluginsFolder;
    // Prefabs
    public bool CreatePrefabsFolder;
    // Resources
    public bool CreateResourcesFolder;
    // Scripts
    public bool CreateScriptsFolder;

    /// <summary>
    /// Creating and displaying wizard.
    /// </summary>
    [MenuItem("SKC/Create Default Folders")]
    public static void CreateWizard()
    {
        DisplayWizard<SKC_FolderCreatorWizard>("Create Default Folders", "Create");
    }

    /// <summary>
    /// Wizard Update.
    /// Runs when window need to be refreshed.
    /// </summary>
    private void OnWizardUpdate()
    {
        // Shows message what to do.
        helpString = "Select folders to create!";

        // Building error message if any of the selected folder exists.
        errorString = "";

        if (CreateAnimationsFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.AnimationsFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.AnimationsFolder);
        }

        if (CreateDataFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.ModelsFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.ModelsFolder);
        }

        if (CreateModelsFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.DataFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.DataFolder);
        }

        if (CreateMaterialsFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.MaterialsFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.MaterialsFolder);
        }

        if (CreatePluginsFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.PluginsFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.PluginsFolder);
        }

        if (CreatePrefabsFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.PrefabsFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.PrefabsFolder);
        }

        if (CreateResourcesFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.ResourcesFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.ResourcesFolder);
        }

        if (CreateScriptsFolder && Directory.Exists(Path.Combine(Application.dataPath, SKC_FolderKeys.ScriptsFolder)))
        {
            // check is folder exist and maybe set error.
            errorString += string.Format("Folder \"{0}\" already exists!\n", SKC_FolderKeys.ScriptsFolder);
        }

        // Set flag to enable Create button.
        isValid = (CreateAnimationsFolder || CreateMaterialsFolder ||
                   CreatePrefabsFolder || CreateResourcesFolder || CreateScriptsFolder || CreatePluginsFolder || CreateModelsFolder || CreateDataFolder)
                    && errorString.Length == 0;
    }

    /// <summary>
    /// Method called on Create button click.
    /// Used here to create selected folder.
    /// </summary>
    private void OnWizardCreate()
    {
        // Creating paths and new folders.

        // Animations
        string path = Path.Combine(Application.dataPath, SKC_FolderKeys.AnimationsFolder);
        if (CreateAnimationsFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Data
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.DataFolder);
        if (CreateDataFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Materials
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.ModelsFolder);
        if (CreateModelsFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Materials
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.MaterialsFolder);
        if (CreateMaterialsFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Materials
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.PluginsFolder);
        if (CreatePluginsFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Prefabs
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.PrefabsFolder);
        if (CreatePrefabsFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Resources
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.ResourcesFolder);
        if (CreateResourcesFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Scripts
        path = Path.Combine(Application.dataPath, SKC_FolderKeys.ScriptsFolder);
        if (CreateScriptsFolder && !Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.LogFormat("Directory created: {0}", path);
        }

        // Refresh Project view to see newly created folders.
        AssetDatabase.Refresh();
    }
}

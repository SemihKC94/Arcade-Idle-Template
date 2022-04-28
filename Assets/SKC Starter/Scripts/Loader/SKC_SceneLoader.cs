using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Script which animates progress bar in the UI with current loading bar process.
/// At the completion loads next scene.
/// </summary>
public class SKC_SceneLoader : MonoBehaviour
{
    // Reference to the load operation.
    private AsyncOperation loadOperation;

    // Reference to the progress bar in the UI.
    [SerializeField]
    private Slider progressBar;

    // Progress values.
    private float currentValue;
    private float targetValue;

    // Multiplier for progress animation speed.
    [SerializeField]
    [Range(0, 1)]
    private float progressAnimationMultiplier = 0.25f;

    /// <summary>
    /// Unity method called once at the start.
    /// Used here to start the loading progress.
    /// </summary>
    private void Start()
    {
        // Set 0 for progress values.
        progressBar.value = currentValue = targetValue = 0;

        // Load the next scene.
        var currentScene = SceneManager.GetActiveScene();
        loadOperation = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);

        // Don't active the scene when it's fully loaded, let the progress bar finish the animation.
        // With this flag set, progress will stop at 0.9f.
        loadOperation.allowSceneActivation = false;
    }

    /// <summary>
    /// Unity method called every frame.
    /// Used here to animate progress bar.
    /// </summary>
    private void Update()
    {
        // Assign current load progress, divide by 0.9f to stretch it to values between 0 and 1.
        targetValue = loadOperation.progress / 0.9f;

        // Calculate progress value to display.
        currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);
        progressBar.value = currentValue;

        // When the progress reaches 1, allow the process to finish by setting the scene activation flag.
        if (Mathf.Approximately(currentValue, 1))
        {
            loadOperation.allowSceneActivation = true;
        }
    }
}
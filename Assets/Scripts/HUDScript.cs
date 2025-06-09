///\\\==========================================///\\\
///\\\ Title    -   HUDScript.cs                ///\\\
///\\\ Author   -   Peter Phillips              ///\\\
///\\\ Date     -   First entry:    27.11.18    ///\\\
///\\\              Lastentry:      04.12.18    ///\\\
///\\\==========================================///\\\


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public bool hasGenerateBeenPressed = false;
    public bool hasResetBeenPressed = false;
    public Text warning;

    [SerializeField] private LSystemsGenerator TreeSpawner;
    [SerializeField] private InputField title;
    [SerializeField] private InputField iterations;
    [SerializeField] private InputField angle;
    [SerializeField] private InputField length;
    [SerializeField] private InputField width;
    [SerializeField] private InputField variance;

    [SerializeField] private InputField spawnRadiusInput;
    [SerializeField] private InputField spawnAreaXInput;
    [SerializeField] private InputField spawnAreaYInput;

    private int tempInt;
    private float tempFloat;

    public void Start()
    {
        title.text = TreeSpawner.title.ToString();
        iterations.text = TreeSpawner.iterations.ToString();
        angle.text = TreeSpawner.angle.ToString() + "°";
        length.text = TreeSpawner.length.ToString("F1");
        width.text = TreeSpawner.width.ToString("F1");
        variance.text = TreeSpawner.variance.ToString() + "%";
        spawnRadiusInput.text = TreeSpawner.spawnRadius.ToString("F1");
        spawnAreaXInput.text = TreeSpawner.spawnAreaSize.x.ToString("F1");
        spawnAreaYInput.text = TreeSpawner.spawnAreaSize.y.ToString("F1");

        warning.gameObject.SetActive(false);
    }

    public void TitleUp()
    {
        if (TreeSpawner.title < LSystemsGenerator.NUM_OF_TREES)
        {
            TreeSpawner.title++;
            TreeSpawner.hasTreeChanged = true;
            title.text = TreeSpawner.title.ToString();
        }
    }
    public void TitleDown()
    {
        if (TreeSpawner.title > 1)
        {
            TreeSpawner.title--;
            TreeSpawner.hasTreeChanged = true;
            title.text = TreeSpawner.title.ToString();
        }
    }

    public void IterationsUp()
    {
        if (TreeSpawner.iterations < LSystemsGenerator.MAX_ITERATIONS)
        {
            TreeSpawner.iterations++;
            iterations.text = TreeSpawner.iterations.ToString();
        }
    }
    public void IterationsDown()
    {
        if (TreeSpawner.iterations > 1)
        {
            TreeSpawner.iterations--;
            iterations.text = TreeSpawner.iterations.ToString();
        }
    }

    public void AngleUp()
    {
        TreeSpawner.angle++;
        angle.text = TreeSpawner.angle.ToString() + "°";
    }
    public void AngleDown()
    {
        TreeSpawner.angle--;
        angle.text = TreeSpawner.angle.ToString() + "°";
    }

    public void LengthUp()
    {
        TreeSpawner.length += .1f;
        length.text = TreeSpawner.length.ToString("F1");
    }
    public void LengthDown()
    {
        if (TreeSpawner.length > 0)
        {
            TreeSpawner.length -= .1f;
            length.text = TreeSpawner.length.ToString("F1");
        }
    }

    public void WidthUp()
    {
        TreeSpawner.width += .1f;
        width.text = TreeSpawner.width.ToString("F1");
    }
    public void WidthDown()
    {
        if (TreeSpawner.width > 0)
        {
            TreeSpawner.width -= .1f;
            width.text = TreeSpawner.width.ToString("F1");
        }
    }

    public void VarianceUp()
    {
        TreeSpawner.variance++;
        variance.text = TreeSpawner.variance.ToString() + "%";
    }
    public void VarianceDown()
    {
        if (TreeSpawner.variance > 0)
        {
            TreeSpawner.variance--;
            variance.text = TreeSpawner.variance.ToString() + "%";
        }
    }

    public void SpawnRadiusUp()
{
    TreeSpawner.spawnRadius += 0.1f;
    spawnRadiusInput.text = TreeSpawner.spawnRadius.ToString("F1");
}
public void SpawnRadiusDown()
{
    if (TreeSpawner.spawnRadius > 0.1f)
    {
        TreeSpawner.spawnRadius -= 0.1f;
        spawnRadiusInput.text = TreeSpawner.spawnRadius.ToString("F1");
    }
}

    public void SpawnAreaXUp()
{
    TreeSpawner.spawnAreaSize.x += 1f;
    spawnAreaXInput.text = TreeSpawner.spawnAreaSize.x.ToString("F1");
}
public void SpawnAreaXDown()
{
    if (TreeSpawner.spawnAreaSize.x > 1f)
    {
        TreeSpawner.spawnAreaSize.x -= 1f;
        spawnAreaXInput.text = TreeSpawner.spawnAreaSize.x.ToString("F1");
    }
}

    public void SpawnAreaYUp()
{
    TreeSpawner.spawnAreaSize.y += 1f;
    spawnAreaYInput.text = TreeSpawner.spawnAreaSize.y.ToString("F1");
}
public void SpawnAreaYDown()
{
    if (TreeSpawner.spawnAreaSize.y > 1f)
    {
        TreeSpawner.spawnAreaSize.y -= 1f;
        spawnAreaYInput.text = TreeSpawner.spawnAreaSize.y.ToString("F1");
    }
}


    public void GenerateNew()
    {
        hasGenerateBeenPressed = true;
    }

    public void ResetValues()
    {
        hasResetBeenPressed = true;
    }


    public void TitleInputOVC()
    {
        TreeSpawner.hasTreeChanged = true;

        if (int.TryParse(title.text, out tempInt))
        {
            TreeSpawner.title = Mathf.Clamp(tempInt, 1, LSystemsGenerator.NUM_OF_TREES);
        }
    }
    public void TitleInputOEE()
    {
        title.text = TreeSpawner.title.ToString();
    }

    public void IterationsInputOVC()
    {
        if (int.TryParse(iterations.text, out tempInt))
        {
            TreeSpawner.iterations = Mathf.Clamp(tempInt, 1, LSystemsGenerator.MAX_ITERATIONS);
        }
    }
    public void IterationsInputOEE()
    {
        iterations.text = TreeSpawner.iterations.ToString();
    }

    public void AngleInputOVC()
    {
        if (int.TryParse(angle.text, out tempInt))
        {
            TreeSpawner.angle = tempInt;
        }
    }
    public void AngleInputOEE()
    {
        angle.text = TreeSpawner.angle.ToString() + "°";
    }

    public void LengthInputOVC()
    {
        if (float.TryParse(length.text, out tempFloat))
        {
            TreeSpawner.length = tempFloat;
        }
    }
    public void LengthInputOEE()
    {
        length.text = TreeSpawner.length.ToString("F1");
    }

    public void WidthInputOVC()
    {
        if (float.TryParse(width.text, out tempFloat))
        {
            TreeSpawner.width = tempFloat;
        }
    }
    public void WidthInputOEE()
    {
        width.text = TreeSpawner.width.ToString("F1");
    }

    public void VarianceInputOVC()
    {
        if (int.TryParse(variance.text, out tempInt))
        {
            TreeSpawner.variance = tempInt;
        }
    }
    public void VarianceInputOEE()
    {
        variance.text = TreeSpawner.variance.ToString() + "%";
    }

    public void SpawnRadiusInputOVC()
    {
        if (float.TryParse(spawnRadiusInput.text, out tempFloat))
        {
            TreeSpawner.spawnRadius = Mathf.Max(0.1f, tempFloat);
        }
    }
    public void SpawnRadiusInputOEE()
    {
        spawnRadiusInput.text = TreeSpawner.spawnRadius.ToString("F1");
    }

    public void SpawnAreaXInputOVC()
    {
        if (float.TryParse(spawnAreaXInput.text, out tempFloat))
        {
            TreeSpawner.spawnAreaSize.x = Mathf.Max(1f, tempFloat);
        }
    }
    public void SpawnAreaXInputOEE()
    {
        spawnAreaXInput.text = TreeSpawner.spawnAreaSize.x.ToString("F1");
    }

public void SpawnAreaYInputOVC()
{
    if (float.TryParse(spawnAreaYInput.text, out tempFloat))
    {
        TreeSpawner.spawnAreaSize.y = Mathf.Max(1f, tempFloat);
    }
}
public void SpawnAreaYInputOEE()
{
    spawnAreaYInput.text = TreeSpawner.spawnAreaSize.y.ToString("F1");
}



}

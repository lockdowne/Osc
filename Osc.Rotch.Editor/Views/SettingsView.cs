using Osc.Rotch.Editor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Osc.Rotch.Editor.Views
{
    /// <summary>
    /// Represents the binding to the settings file
    /// Using anti pattern due to configuration already being static
    /// </summary>
    public partial class SettingsView : RadForm
    {        
        public SettingsView()
        {
            InitializeComponent();

            // Console
            numericMaxConsoleMessages.Value = Configuration.Settings.MaxNumberOfConsoleMessage;

            // Camera
            numericMaxZoom.Value = (decimal)Configuration.Settings.MaxCameraZoom;
            numericMinZoom.Value = (decimal)Configuration.Settings.MinCameraZoom;
            numericLerp.Value = (decimal)Configuration.Settings.CameraLerpAmount;
            numericZoomIncrement.Value =(decimal)Configuration.Settings.ZoomIncrement;

            // Scene
            numericSceneWidth.Value = Configuration.Settings.SceneWidth;
            numericSceneHeight.Value = Configuration.Settings.SceneHeight;

            this.FormClosed += (sender, e) =>
            {
                // Console
                Configuration.Settings.MaxNumberOfConsoleMessage = (int)numericMaxConsoleMessages.Value;

                // Camera
                Configuration.Settings.MaxCameraZoom = (float)numericMaxZoom.Value;
                Configuration.Settings.MinCameraZoom = (float)numericMinZoom.Value;
                Configuration.Settings.CameraLerpAmount = (float)numericLerp.Value;
                Configuration.Settings.ZoomIncrement = (float)numericZoomIncrement.Value;

                // Scene
                Configuration.Settings.SceneWidth = (int)numericSceneWidth.Value;
                Configuration.Settings.SceneHeight = (int)numericSceneHeight.Value;

                // Should be thread safe but expect a thread consuming a settings value when this gets changed
                Configuration.SaveSettings();
            };
        }
    }
}

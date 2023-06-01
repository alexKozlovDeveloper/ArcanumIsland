using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ArcanumIsland.MapViewer
{
    //public class StepController
    //{
    //    private IStep _step;
    //    private StackPanel _stepStackPanel;

    //    public StackPanel StepStackPanel { get { return _stepStackPanel; } }

    //    public StepController(IStep step) 
    //    {
    //        _step = step;

    //        _stepStackPanel = new StackPanel();

    //        var stepMainGrid = CreateStepMainGrid(step);
    //        var stepSettingGrid = CreateStepSettingGrid(step.StepParams);
    //        var stepResultGrid = new StackPanel();

    //        _stepStackPanel.Children.Add(stepMainGrid);
    //        _stepStackPanel.Children.Add(stepSettingGrid);
    //        _stepStackPanel.Children.Add(stepResultGrid);
    //    }

    //    public Grid CreateStepMainGrid(IStep step)
    //    {
    //        var stepMainGrid = new Grid();

    //        stepMainGrid.ColumnDefinitions.Add(new ColumnDefinition());

    //        stepMainGrid.RowDefinitions.Add(new RowDefinition());
    //        stepMainGrid.RowDefinitions.Add(new RowDefinition());

    //        var label = new Label
    //        {
    //            Content = step.Name
    //        };

    //        Grid.SetRow(label, 0);
    //        Grid.SetColumn(label, 0);

    //        stepMainGrid.Children.Add(label);

    //        var button = new Button()
    //        {
    //            Content = "Run"
    //        };

    //        Grid.SetRow(button, 1);
    //        Grid.SetColumn(button, 0);

    //        stepMainGrid.Children.Add(button);

    //        return stepMainGrid;
    //    }

    //    //public Grid CreateStepSettingGrid(IStepParams stepParams)
    //    //{
    //    //    var stepSettingGrid = new Grid();

    //    //    stepSettingGrid.ColumnDefinitions.Add(new ColumnDefinition());
    //    //    stepSettingGrid.ColumnDefinitions.Add(new ColumnDefinition());

    //    //    Type settingType = stepParams.GetType();
    //    //    var properties = settingType.GetProperties();

    //    //    for (int i = 0; i < properties.Length; i++)
    //    //    {
    //    //        stepSettingGrid.RowDefinitions.Add(new RowDefinition());

    //    //        var label = new Label
    //    //        {
    //    //            Content = properties[i].Name
    //    //        };

    //    //        var texBox = new TextBox
    //    //        {
    //    //            Name = properties[i].Name,
    //    //            Text = properties[i].GetValue(stepParams).ToString()
    //    //        };

    //    //        Grid.SetRow(label, i);
    //    //        Grid.SetRow(texBox, i);

    //    //        Grid.SetColumn(label, 0);
    //    //        Grid.SetColumn(texBox, 1);

    //    //        stepSettingGrid.Children.Add(label);
    //    //        stepSettingGrid.Children.Add(texBox);
    //    //    }

    //    //    return stepSettingGrid;
    //    //}
    //}
}

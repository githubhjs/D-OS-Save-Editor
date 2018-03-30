﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D_OS_Save_Editor
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class StatsTab : UserControl
    {
        private Player _player;
        private Brush DefaultTextBoxBorderBrush { get; }

        public Player Player
        {
            get => _player;

            set
            {
                _player = value;
                UpdateForm();
            }
        }

        public StatsTab()
        {
            InitializeComponent();
            DefaultTextBoxBorderBrush = ExpTextBox.BorderBrush;
        }

        public void UpdateForm()
        {
            ExpTextBox.Text = Player.Experience.ToString();
            ReputationTextBox.Text = Player.Reputation.ToString();
            HpCurrentTextBox.Text = Player.Vitality.ToString();
            HpMaxTextBox.Text = Player.MaxVitalityPatchCheck.ToString();
            AttributePointsTextBox.Text = Player.AttributePoints.ToString();
            AbilityPointsTextBox.Text = Player.AbilityPoints.ToString();
            TalentPointsTextBox.Text = Player.TalentPoints.ToString();
            StrengthTextBox.Text = Player.Attributes[(int)ConversionTable.Attributes.Strength].ToString();
            DexterityTextBox.Text = Player.Attributes[(int)ConversionTable.Attributes.Dexerity].ToString();
            IntelligenceTextBox.Text = Player.Attributes[(int)ConversionTable.Attributes.Intelligence].ToString();
            ConstitutionTextBox.Text = Player.Attributes[(int)ConversionTable.Attributes.Consitution].ToString();
            SpeedTextBox.Text = Player.Attributes[(int)ConversionTable.Attributes.Speed].ToString();
            PerceptionTextBox.Text = Player.Attributes[(int)ConversionTable.Attributes.Perception].ToString();
        }

        public void SaveEdits()
        {
            Player.Experience = int.Parse(ExpTextBox.Text);
            Player.Reputation = int.Parse(ReputationTextBox.Text);
            Player.Vitality = int.Parse(HpCurrentTextBox.Text);
            Player.MaxVitalityPatchCheck = int.Parse(HpMaxTextBox.Text);
            Player.AttributePoints = int.Parse(AttributePointsTextBox.Text);
            Player.AbilityPoints = int.Parse(AbilityPointsTextBox.Text);
            Player.TalentPoints = int.Parse(TalentPointsTextBox.Text);
            Player.Attributes[(int) ConversionTable.Attributes.Strength] = int.Parse(StrengthTextBox.Text);
            Player.Attributes[(int)ConversionTable.Attributes.Dexerity] = int.Parse(DexterityTextBox.Text);
            Player.Attributes[(int)ConversionTable.Attributes.Intelligence] = int.Parse(IntelligenceTextBox.Text);
            Player.Attributes[(int)ConversionTable.Attributes.Consitution] = int.Parse(ConstitutionTextBox.Text);
            Player.Attributes[(int)ConversionTable.Attributes.Speed] = int.Parse(SpeedTextBox.Text);
            Player.Attributes[(int)ConversionTable.Attributes.Perception] = int.Parse(PerceptionTextBox.Text);
        }

        private void TextBoxEventSetter_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox s)) return;

            var text = s.Text;
            var valid = int.TryParse(text, out int _);
            s.BorderBrush = !valid ? Brushes.Red : DefaultTextBoxBorderBrush;
        }

        private void TextBoxEventSetter_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(sender is TextBox s)) return;

            var text = s.Text.Insert(s.SelectionStart, e.Text);
            e.Handled = !int.TryParse(text, out int _);
        }
    }
}
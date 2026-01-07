using SDCPervomay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static SDCPervomay.AppData.SupportModels;

namespace SDCPervomay.View.Pages.ReceptionPages
{
    /// <summary>
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        List<ScheduleModel> schedule = new List<ScheduleModel>();
        List<SectionDayOfWeek> sectionDayOfWeeks = App.context.SectionDayOfWeek.ToList();
        TextBlock currentTbl = new TextBlock();
        public SchedulePage()
        {
            InitializeComponent();

            var today = MapDay(DateTime.Today.DayOfWeek);

            ScheduleOnToday(today);

        }

        public void ScheduleOnToday(int dayOfWeek)
        {
            schedule = new List<ScheduleModel>();
            foreach (var section in sectionDayOfWeeks.
                Where(x => x.DayOfWeekId == dayOfWeek))
            {
                schedule.Add(new ScheduleModel
                {
                    Name = section.Section.Name,
                    Time = section.Time.ToString() + " - " + section.Time.Add(TimeSpan.FromHours(2)).ToString(),
                    Coach = section.Section.User.FullName,
                    Image = section.Section.Image
                });
            }

            ScheduleLB.ItemsSource = schedule.OrderBy(x => x.Time).ToList();
        }

        public int MapDay(System.DayOfWeek dateTime)
        {
            switch (dateTime)
            {
                case System.DayOfWeek.Monday:
                    return 1;
                case System.DayOfWeek.Tuesday:
                    return 2;
                case System.DayOfWeek.Wednesday:
                    return 3;
                case System.DayOfWeek.Thursday:
                    return 4;
                case System.DayOfWeek.Friday:
                    return 5;
                case System.DayOfWeek.Saturday:
                    return 6;
                case System.DayOfWeek.Sunday:
                    return 7;
                default:
                    return 0;

            }

        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Pn;
            Pn.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(1);
        }

        private void TextBlock_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Vt;
            Vt.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(2);

        }

        private void TextBlock_MouseDown_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Sr;
            Sr.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(3);

        }

        private void TextBlock_MouseDown_3(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Cht;
            Cht.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(4);

        }

        private void TextBlock_MouseDown_4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Pt;
            Pt.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(5);

        }

        private void TextBlock_MouseDown_5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Sb;
            Sb.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(6);

        }

        private void TextBlock_MouseDown_6(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            currentTbl.TextDecorations = null;
            currentTbl = Vs;
            Vs.TextDecorations = TextDecorations.Underline;
            ScheduleOnToday(7);

        }
    }
}

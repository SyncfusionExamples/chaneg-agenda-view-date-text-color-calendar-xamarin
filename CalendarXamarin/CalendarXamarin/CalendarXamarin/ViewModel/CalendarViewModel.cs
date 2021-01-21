using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CalendarXamarin
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private CalendarEventCollection appointments;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> meetingSubjectCollection;
        public CalendarEventCollection Appointments
        {
            get
            {
                return this.appointments;
            }

            set
            {
                this.appointments = value;
                this.OnPropertyChanged("Appointments");
            }
        }
        public CalendarViewModel()
        {
            this.Appointments = new CalendarEventCollection();
            this.AddAppointmentDetails();
            this.AddAppointments();
        }
        private void AddAppointmentDetails()
        {
            meetingSubjectCollection = new ObservableCollection<string>();
            meetingSubjectCollection.Add("General Meeting");
            meetingSubjectCollection.Add("Plan Execution");
            meetingSubjectCollection.Add("Project Plan");
            meetingSubjectCollection.Add("Consulting");
            meetingSubjectCollection.Add("Support");
            meetingSubjectCollection.Add("Development Meeting");
            meetingSubjectCollection.Add("Scrum");
            meetingSubjectCollection.Add("Project Completion");
            meetingSubjectCollection.Add("Release updates");
            meetingSubjectCollection.Add("Performance Check");
        }
        private void AddAppointments()
        {
            var today = DateTime.Now.Date;
            var random = new Random();
            for (int month = -1; month < 2; month++)
            {
                for (int day = -5; day < 5; day++)
                {
                    for (int count = 0; count < 2; count++)
                    {
                        var appointment = new CalendarInlineEvent();
                        appointment.Subject = meetingSubjectCollection[random.Next(7)];
                        appointment.Color = Color.FromHex("889e81");
                        appointment.StartTime = today.AddMonths(month).AddDays(random.Next(1, 28)).AddHours(random.Next(9, 18));
                        appointment.EndTime = appointment.StartTime.AddHours(2);

                        CalendarInlineEvent event2 = new CalendarInlineEvent();
                        event2.StartTime = new DateTime(2019, 10, 28, 10, 0, 0);
                        event2.EndTime = new DateTime(2019, 10, 28, 12, 0, 0);
                        event2.Subject = "Planning";
                        event2.Color = Color.FromHex("889e81");

                        this.Appointments.Add(appointment);
                        this.Appointments.Add(event2);
                    }
                }
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
